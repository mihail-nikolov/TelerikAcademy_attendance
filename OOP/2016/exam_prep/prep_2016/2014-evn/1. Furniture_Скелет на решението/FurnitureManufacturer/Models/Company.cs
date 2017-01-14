using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        public ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new Collection<IFurniture>();
        }
        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            set
            {
                this.furnitures = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new Exception("name cannot be null or < 5 sym");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length != 10)
                {
                    throw new Exception("registrationNumber cannot be null or != 10 sym");
                }
                this.registrationNumber = value;
            }
        }

        public void Add(IFurniture furniture)
        {
            if (furniture == null)
            {
                throw new Exception("furniture cannot be null");
            }
            this.Furnitures.Add(furniture);
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name, this.RegistrationNumber, this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
                ));
            foreach (var furn in this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model))
            {
                sb.AppendLine(furn.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public IFurniture Find(string model)
        {
            if (this.Furnitures.Any(f => f.Model.ToLower() == model.ToLower()))
            {
                return this.Furnitures.First(f => f.Model.ToLower() == model.ToLower());
            }
            return null;
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }
    }
}
