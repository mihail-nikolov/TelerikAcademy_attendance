namespace DSA_efficiency_HW
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(string barcode, string vendor, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public int Price { get; set; }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("Barcode: {0}, Price: {1}", this.Barcode, this.Price);
        }
    }
}
