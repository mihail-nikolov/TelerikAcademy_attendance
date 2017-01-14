namespace MatrixTests
{
    using NUnit.Framework;
    using Matrix;
    using System.Text;

    [TestFixture]
    public class MatrixCrawlerTests
    {
        [Test]
        public void FillInTheMatrix_ShouldThrowArgumentException_WhenInputArrayDiffersFromMatrixSize()
        {
            int sizeX = 2;
            int sizeY = 2;
            MatrixCrawler mycrawler = new MatrixCrawler(sizeX, sizeY);

            int[] arr = new int[] { 1, 2, 3 };

            Assert.That(() => mycrawler.FillInTheMatrix(arr), Throws.ArgumentException.With.Message.Contains("numbers to add != sizeX * sizeY"));
        }

        [Test]
        public void FillInTheMatrix_ShouldThrowArgumentNullException_WhenNullObjectPassed()
        {
            int sizeX = 2;
            int sizeY = 2;
            MatrixCrawler mycrawler = new MatrixCrawler(sizeX, sizeY);

            Assert.That(() => mycrawler.FillInTheMatrix(null), Throws.ArgumentNullException.With.Message.Contains("pass a valid int[]"));
        }

        [Test]
        public void FillInTheMatrix_FilledCorrectly()
        {
            int sizeX = 2;
            int sizeY = 2;
            MatrixCrawler mycrawler = new MatrixCrawler(sizeX, sizeY);

            int[] arr = new int[] { 1, 2, 3, 4 };
            mycrawler.FillInTheMatrix(arr);

            StringBuilder sb = new StringBuilder();
            sb.Append("1 ");
            sb.Append("2");
            sb.AppendLine();
            sb.Append("3 ");
            sb.Append("4");

            Assert.AreEqual(mycrawler.PrintMatrix(), sb.ToString().TrimEnd());
        }

        [Test]
        public void GetCellNumber_ShouldThrowArgumentException_WhenOutOfBorders()
        {
            int sizeX = 2;
            int sizeY = 2;
            MatrixCrawler mycrawler = new MatrixCrawler(sizeX, sizeY);

            Assert.That(() => mycrawler.GetCellNumber(0, 0), Throws.ArgumentException.With.Message.Contains("the cell has to be in matrix borders"));
        }

        [Test]
        public void GetCellNumber_ReturnCorrectNumber()
        {
            int sizeX = 2;
            int sizeY = 2;
            MatrixCrawler mycrawler = new MatrixCrawler(sizeX, sizeY);

            int[] arr = new int[] { 1, 2, 3, 4 };
            mycrawler.FillInTheMatrix(arr);

            Assert.AreEqual(mycrawler.GetCellNumber(1, 1), 1);
        }
    }
}
