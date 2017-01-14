namespace PetStore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PetStoreDataGenerator
    {
        private Random rnd = new Random();

        public PetStoreDataGenerator(int countriesToGenerate, int speciesToGenerate, int petsToGenerate, int categoriesGenerate, int productsToGenerate)
        {
            CountriesToGenerate = countriesToGenerate;
            SpeciesToGenerate = speciesToGenerate;
            PetsToGenerate = petsToGenerate;
            CategoriesGenerate = categoriesGenerate;
            ProductsToGenerate = productsToGenerate;

        }

        public int CountriesToGenerate { get; set; }
        public int SpeciesToGenerate { get; set; }
        public int PetsToGenerate { get; set; }
        public int CategoriesGenerate { get; set; }
        public int ProductsToGenerate { get; set; }

        public List<Country> GenerateCountries()
        {
            var countries = new List<Country> { };
            var existingCountries = this.GetCountries();
            int count = 1;
            while (countries.Count < CountriesToGenerate)
            {
                string countryName = "countryName" + count.ToString();
                bool DbContainsCountryName = existingCountries.Any(c => c.Name == countryName);

                if (!DbContainsCountryName)
                {
                    var country = new Country()
                    {
                        Name = countryName
                    };
                    countries.Add(country);
                }
                count++;
            }

            return countries;
        }

        public List<Species> GenerateSpecies()
        {
            var species = new List<Species> { };
            var existingSpecies = this.GetSpecies();
            int count = 1;

            while (species.Count < SpeciesToGenerate)
            {
                string speciesName = "speciesName" + count.ToString();
                bool DbContainsSpeciesName = existingSpecies.Any(s => s.Name == speciesName);

                var countryIDs = this.GetCountriesIDs();
                int countryIdIndex = rnd.Next(0, countryIDs.Count);
                int countryID = countryIDs[countryIdIndex];

                if (!DbContainsSpeciesName)
                {
                    var newSpecies = new Species()
                    {
                        Name = speciesName,
                        CountryID = countryID
                    };
                    species.Add(newSpecies);
                }
                count++;
            }

            return species;
        }

        public List<Pet> GeneratePets()
        {
            var pets = new List<Pet> { };
            int count = 1;
            while (pets.Count < PetsToGenerate)
            {
                string petBreed = "petBreed" + count.ToString();
                int price = rnd.Next(5, 2500 + 1);
                DateTime randomDate = new DateTime(rnd.Next(2010, 2015), rnd.Next(1, 12), rnd.Next(1, 28));

                var colorIDs = this.GetColorIDs();
                int colorIdIndex = rnd.Next(0, colorIDs.Count);
                int colorID = colorIDs[colorIdIndex];

                var speciesIDs = this.GetSpeciesIDs();
                int speciesIdIndex = rnd.Next(0, speciesIDs.Count);
                int speciesID = speciesIDs[speciesIdIndex];

                var newPet = new Pet()
                {
                    Breed = petBreed,
                    Price = price,
                    DateBirth = randomDate,
                    ColorID = colorID,
                    SpeciesID = speciesID
                };

                pets.Add(newPet);
                count++;
            }


            return pets;
        }

        public List<Product> GenerateProducts()
        {
            var products = new List<Product> { };
            int count = 1;
            while (products.Count < ProductsToGenerate)
            {
                string productName = "productName" + count.ToString();
                int price = rnd.Next(10, 1000 + 1);

                var categoryIDs = this.GetCategoryIDs();
                int categoryIdIndex = rnd.Next(0, categoryIDs.Count);
                int categoryID = categoryIDs[categoryIdIndex];
                
                var newProduct = new Product()
                {
                    Name = productName,
                    Price = price,
                    CategoryID = categoryID
                };
                var speciesList = this.GetSpecies();

                //int numSpeciesToBeAdded = rnd.Next(2, 10 + 1);
                //for (int i = 1; i <= numSpeciesToBeAdded; i++)
                //{
                //    int speciesIndex = rnd.Next(0, speciesList.Count);
                //    newProduct.Species.Add(speciesList[speciesIndex]);
                //}

                products.Add(newProduct);
                count++;
            }

            return products;
        }

        public List<ProductCategory> GenerateCategories()
        {
            var categories = new List<ProductCategory> { };
            for (int i = 1; i <= CategoriesGenerate; i++)
            {
                string categoryName = "categoryName" + i.ToString();
                var category = new ProductCategory()
                {
                    Name = categoryName
                };
                categories.Add(category);
            }

            return categories;
        }

        private List<Country> GetCountries()
        {
            var db = new PetStoreEntities();
            using (db)
            {
                var enteredCountries = db.Countries
                    .ToList();
                return enteredCountries;
            }
        }

        private List<Species> GetSpecies()
        {
            var db = new PetStoreEntities();
            using (db)
            {
                var enteredSpecies = db.Species
                    .ToList();
                return enteredSpecies;
            }
        }

        private List<int> GetColorIDs()
        {
            var db = new PetStoreEntities();
            using (db)
            {
                var colorIDs = db.Colors
                    .Select(c => c.ColorID)
                    .ToList();
                return colorIDs;
            }
        }

        private List<int> GetSpeciesIDs()
        {
            var db = new PetStoreEntities();
            using (db)
            {
                var speciesIDs = db.Species
                    .Select(s => s.SpeciesID)
                    .ToList();
                return speciesIDs;
            }
        }

        private List<int> GetCountriesIDs()
        {
            var db = new PetStoreEntities();
            using (db)
            {
                var countryIDs = db.Countries
                    .Select(c => c.CountryID)
                    .ToList();
                return countryIDs;
            }
        }

        private List<int> GetCategoryIDs()
        {
            var db = new PetStoreEntities();
            using (db)
            {
                var categoryIDs = db.ProductCategories
                    .Select(c => c.CategoryID)
                    .ToList();
                return categoryIDs;
            }
        }
    }
}
