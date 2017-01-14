namespace Tests.Engine
{
    using NUnit.Framework;
    using Cosmetics.Engine;
    using Moq;
    using Cosmetics.Contracts;
    using System.Collections.Generic;
    using Cosmetics.Products;
    using Mocks;
    using Cosmetics.Common;
    using System.Threading;
    using System.Globalization;

    [TestFixture]
    public class CosmeticsFactoryTests
    {
       ICosmeticsFactory Factory;

        [SetUp]
        public void StartSetup()
        {
            this.Factory = new CosmeticsFactory();
        }

        [Test]
        public void CreateCategory_shouldReturnNewCategoryWithGivenParameters()
        {
            var categoryName = "Formale";

            var cat = this.Factory.CreateCategory(categoryName);

            Assert.IsInstanceOf<Category>(cat);
            Assert.AreEqual(cat.Name, categoryName);
        }
    }
}
