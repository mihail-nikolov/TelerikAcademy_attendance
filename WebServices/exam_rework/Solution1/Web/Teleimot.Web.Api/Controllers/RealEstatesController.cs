namespace Teleimot.Web.Api.Controllers
{
    using System.Web.Http;
    using Services.Contracts;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using System;
    using Models.RealEstates;
    using System.Linq;
    using Common;
    using System.Net.Http;
    using System.Net;
    using AutoMapper;
    using Data.Models;

    public class RealEstatesController : ApiController
    {
        private readonly IRealEstatesService realEstates;

        public RealEstatesController(IRealEstatesService realEstates)
        {
            this.realEstates = realEstates;
        }

        // GET: api/RealEstates/5
        public IHttpActionResult Get(int id)
        {
            var realEstate = this.realEstates.GetDetailsById(id)
                                             .AsQueryable();

            if (!realEstate.Any())
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                                        WebApiConstants.NoSuchARealSetate));
            }

            GetRealEstateDetailsReponseModel realEstateResult;

            if (User.Identity.IsAuthenticated)
            {
                realEstateResult = realEstate
                                       .ProjectTo<GetRealEstatePrivateDetailsReponseModel>()
                                       .FirstOrDefault();
            }
            else
            {
                realEstateResult = realEstate
                                        .ProjectTo<GetRealEstateDetailsReponseModel>()
                                        .FirstOrDefault();
            }

            return this.Ok(realEstateResult);
        }

        // GET: api/RealEstates
        public IHttpActionResult Get(int skip = 0, int take = 10)
        {
            if (take > WebApiConstants.MaxEntitiesToTake)
            {
                take = WebApiConstants.MaxEntitiesToTake;
            }

            var realEstates = this.realEstates.Get(take, skip)
                                    .AsQueryable()
                                    .ProjectTo<CreateRealEstateResponseModel>();

            return this.Ok(realEstates);
        }

        // POST: api/RealEstates
        [Authorize]
        public IHttpActionResult Post(CreateRealEstateRequestModel model)
        {
            try
            {
                var newRealEstate = Mapper.Map<RealEstate>(model);
                newRealEstate.UserId = this.User.Identity.GetUserId();

                var createdRealEstateId = this.realEstates.Create(newRealEstate);

                var realEstateResult = this.realEstates.GetDetailsById(createdRealEstateId)
                                                       .AsQueryable()
                                                       .ProjectTo<CreateRealEstateResponseModel>()
                                                       .FirstOrDefault();

                return this.Created("/api/RealEstates", realEstateResult);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                                                        e.Message));
            }
        }
    }
}
