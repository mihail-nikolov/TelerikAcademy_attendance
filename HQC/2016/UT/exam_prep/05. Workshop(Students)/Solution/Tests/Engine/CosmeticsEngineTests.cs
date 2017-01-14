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
    public class CosmeticsEngineTests
    {
        Mock<ICosmeticsFactory> mockedFactory;
        Mock<IShoppingCart> mockedCart;
        Mock<ICommandParser> mockedParser;
        Mock<ICommand> mockedCommand;
        Mock<ICategory> mockedCategory;
        MockedCosmeticsEngine engine;

        [SetUp]
        public void StartSetup()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.mockedFactory = new Mock<ICosmeticsFactory>();
            this.mockedCart = new Mock<IShoppingCart>();
            this.mockedParser = new Mock<ICommandParser>();
            this.mockedCommand = new Mock<ICommand>();
            this.mockedCategory = new Mock<ICategory>();
            this.engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedCart.Object, mockedParser.Object);
        }

        [Test]
        public void Start_WhenInputStringIsValidCreateCategoryCommand_CategoryShouldBeAddedToList()
        {
            var categoryName = "Formale";

            this.mockedCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            this.mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            this.mockedCategory.SetupGet(x => x.Name).Returns(categoryName);
            this.mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);
            this.mockedParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            this.engine.Start();

            Assert.IsTrue(engine.Categories.ContainsKey("Formale"));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenAddToCategoryValid_ProductShouldBeAddedInThisCategory()
        {
            var categoryName = "Formale";
            var productName = "White+";
            var mockedShampoo = new Mock<IShampoo>();
            this.engine.Categories.Add(categoryName, this.mockedCategory.Object);
            this.engine.Products.Add(productName, mockedShampoo.Object);

            this.mockedCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            this.mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName , productName});
            this.mockedParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            this.engine.Start();

            mockedCategory.Verify(x => x.AddProduct(mockedShampoo.Object), Times.Once);
        }

        [Test]
        public void Start_WhenRemoveFromCategoryValid_ProductShouldRemovedFromThisCategory()
        {
            var categoryName = "Formale";
            var productName = "White+";
            var mockedShampoo = new Mock<IShampoo>();
            this.engine.Categories.Add(categoryName, this.mockedCategory.Object);
            this.engine.Products.Add(productName, mockedShampoo.Object);

            this.mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            this.mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });
            this.mockedParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            this.engine.Start();

            mockedCategory.Verify(x => x.RemoveProduct(mockedShampoo.Object), Times.Once);
        }

        [Test]
        public void Start_WhenShowCategoryValid_ShouldCallPrint()
        {
            var categoryName = "Formale";
            this.engine.Categories.Add(categoryName, this.mockedCategory.Object);

            this.mockedCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            this.mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            this.mockedParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            this.engine.Start();

            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_WhenCreateShampooValid_ShampooShouldBeAdded()
        {
            var shampooName = "Nivea";

            var mockedShampoo = new Mock<IShampoo>();

            mockedShampoo.SetupGet(x => x.Name).Returns("Nivea");
            this.mockedCommand.SetupGet(x => x.Name).Returns("CreateShampoo");
            this.mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>()
            {
                shampooName,"Nivea", "0.50", "men", "500", "everyday"});

            this.mockedFactory.Setup(x => x.CreateShampoo(
                shampooName, It.IsAny<string>(),
                It.IsAny<decimal>(), It.IsAny<GenderType>(),
                It.IsAny<uint>(), It.IsAny<UsageType>())).Returns(mockedShampoo.Object);
            this.mockedParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            this.engine.Start();

            Assert.IsTrue(engine.Products.ContainsKey("Nivea"));
            Assert.AreSame(mockedShampoo.Object, engine.Products[shampooName]);
        }

        // TODO CreateToothpaste - same as shampoo

        // TODO AddToShoppingCart - same as addtocategory
        // TODO RemoveFromShoppingCart - same as removeFromCategory
        // TODO TotalPrice - same as the once up (should call totalPrice)
    }
}