namespace PetStore.Importer
{
    using PetStore.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PetStoreDataImporter
    {
        public void ImportCountries(List<Country> countries)
        {
            var db = new PetStoreEntities();
            
            using (db)
            {
                foreach (var country in countries)
                {
                    db.Countries.Add(country);
                }
                db.SaveChanges();
            }
        }

        public void ImportCategories(List<ProductCategory> categories)
        {
            var db = new PetStoreEntities();
            using (db)
            {
                foreach (var category in categories)
                {
                    db.ProductCategories.Add(category);
                }
                db.SaveChanges();
            }
        }

        public void ImportPets(List<Pet> pets)
        {
            var db = new PetStoreEntities();
            using (db)
            {
                foreach (var pet in pets)
                {
                    db.Pets.Add(pet);
                }
                db.SaveChanges();
            }
        }

        public void ImportSpecies(List<Species> species)
        {
            var product = new Product();
            //product.Species.Add
            var db = new PetStoreEntities();
            using (db)
            {
                foreach (var specie in species)
                {
                    db.Species.Add(specie);
                }
                db.SaveChanges();
            }
        }

        public void ImportProducts(List<Product> products)
        {
            var db = new PetStoreEntities();
            using (db)
            {
                foreach (var product in products)
                {
                    db.Products.Add(product);
                }
                db.SaveChanges();
            }
        }
    }
}
