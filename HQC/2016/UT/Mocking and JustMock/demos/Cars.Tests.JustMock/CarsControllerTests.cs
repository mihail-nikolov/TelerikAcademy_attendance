namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    
    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        public CarsControllerTests()
            //: this(new JustMockCarsRepository())
             : this(new MoqCarsRepository())
        {
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(2, model.Id);
            Assert.AreEqual("BMW", model.Make);
            Assert.AreEqual("325i", model.Model);
            Assert.AreEqual(2008, model.Year);
        }

        [TestMethod]
        public void SortByMakeShouldWorkCorrectly()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            int id = 1;
            foreach (var car in model)
            {
                Assert.AreEqual(car.Id, id);
                id++;
            }
        }

        [TestMethod]
        public void SortByYearShouldWorkCorrectly()
        {
            var model = (List<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(model[0].Id, 1);
            Assert.AreEqual(model[1].Id, 3);
            Assert.AreEqual(model[2].Id, 2);
            Assert.AreEqual(model[3].Id, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortShouldThrowException()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("model"));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
