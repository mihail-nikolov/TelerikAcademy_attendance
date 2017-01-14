namespace Matrix
{
    using System;
    using System.Text;
    public class MatrixCrawler
    {
        int sizeX;
        int sizeY;
        int[,] theMatrix;

        public MatrixCrawler(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.theMatrix = new int[this.SizeX, this.SizeY];
        }

        public int SizeX
        {
            get { return this.sizeX; }
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException("size [0,100]");
                }
                this.sizeX = value;
            }
        }

        public int SizeY
        {
            get { return this.sizeY; }
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException("size [0,100]");
                }
                this.sizeY = value;
            }
        }

        public void FillInTheMatrix(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("pass a valid int[]");
            }

            if (input.Length != this.SizeX * this.SizeY)
            {
                throw new ArgumentException("numbers to add != sizeX * sizeY");
            }

            int k = 0;
            for (int i = 0; i < this.SizeX; i++)
            {
                for (int j = 0; j < this.SizeY; j++)
                {
                    this.theMatrix[i, j] = input[k];
                    k++;
                }
            }
        }

        public int GetCellNumber(int i, int j)
        {
            if (i <= 0 || i > this.sizeX || j <= 0 || j > this.sizeY)
            {
                throw new ArgumentException("the cell has to be in matrix borders");
            }

            return this.theMatrix[i - 1, j - 1];
        }

        public string PrintMatrix()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.SizeX; i++)
            {
                for (int j = 0; j < this.SizeY; j++)
                {
                    int num = this.theMatrix[i, j];
                    if (j == this.SizeY - 1)
                    {
                        sb.Append(string.Format("{0}", num));
                    }
                    else
                    {
                        sb.Append(string.Format("{0} ", num));
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
