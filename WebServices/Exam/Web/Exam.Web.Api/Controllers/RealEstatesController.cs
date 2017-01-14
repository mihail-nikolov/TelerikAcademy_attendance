namespace Exam.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.RealEstate;
    using Services.Data;

    public class RealEstatesController : ApiController
    {
        private readonly RealEstatesService realEstates;

        public RealEstatesController(RealEstatesService realEstates)
        {
            this.realEstates = realEstates;
        }

        public IHttpActionResult Get(string skip = "0", string take = "10")
        {
            int skipRealEstates;
            if (!int.TryParse(skip, out skipRealEstates))
            {
                skipRealEstates = 0;
            }

            int takeRealEstates;
            if (!int.TryParse(take, out takeRealEstates))
            {
                takeRealEstates = 0;
            }

            if (takeRealEstates > 100)
            {
                takeRealEstates = 100;
            }

            var publicRealEstates = this.realEstates.GetPublicRealEstates(skipRealEstates, takeRealEstates)
              .AsQueryable()
              .ProjectTo<CreatedRealEstateResponseModel>();

            return this.Ok(publicRealEstates);
        }

        [Authorize]
        public IHttpActionResult Post(CreateRealEstateRequestModel model)
        {
            var newRealEstate = this.realEstates.CreateRealEstate(
                model.Title,
                model.Description,
                model.Address,
                model.Contact,
                model.ConstructionYear,
                model.SellingPrice,
                model.RentingPrice,
                model.Type,
                this.User.Identity.GetUserId());

            var realEstateResult = realEstates
                .GetRealEstateDetails(newRealEstate.Id)
                .ProjectTo<CreatedRealEstateResponseModel>()
                .FirstOrDefault();

            return this.Created(
                string.Format("/api/RealEstates/{0}", newRealEstate.Id),
                realEstateResult);

        }

        public IHttpActionResult Get(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                var realEstateResult = this.realEstates
                    .GetRealEstateDetails(id)
                    .ProjectTo<RealEstatePublicDetailsResponseModel>()
                    .FirstOrDefault();

                return this.Ok(realEstateResult);
            }
            else
            {
                var realEstateResult = this.realEstates
                   .GetRealEstateDetails(id)
                   .ProjectTo<RealEstatePrivateDetailsResponseModel>()
                   .FirstOrDefault();

                return this.Ok(realEstateResult);
            }
        }
    }
}