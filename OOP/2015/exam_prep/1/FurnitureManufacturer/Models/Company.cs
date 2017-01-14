using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string regNumber;
        private ICollection<IFurniture> furnitures;


        public Company(string name, string regNumber)
        {
            this.Name = name;
            this.RegistrationNumber = regNumber;
            this.Furnitures = new List<IFurniture> { };
        }

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (value == null || value == "" || value.Length < 5)
                {
                    throw new ArgumentException("enter valid name with len > 5");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get { return this.regNumber; }
            protected set
            {
                if (value.Length != 10 || !IsDigitsOnly(value))
                {
                    throw new ArgumentException("enter valid name with len > 5");
                }
                this.regNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
            protected set
            {
                this.furnitures = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furn in this.Furnitures)
            {
                if (furn.Model.ToLower() == model.ToLower())
                {
                    return furn;
                }
            }
            return null;
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();
            string companyInfo = string.Format("{0} - {1} - {2} {3}",
                    this.Name,
                    this.RegistrationNumber,
                    this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                    this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            sb.AppendLine(companyInfo);
            foreach (var furn in this.Furnitures.OrderBy(f=>f.Price).ThenBy(f=>f.Model))
            {
                sb.AppendLine(furn.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
