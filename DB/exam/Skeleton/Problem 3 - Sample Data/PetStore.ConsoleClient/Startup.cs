namespace PetStore.ConsoleClient
{
    using System;
    using System.Linq;
    using PetStore.Data;
    using PetStore.Importer;


    public class Startup
    {
        public static void Main()
        {
            int countriesToAdd = 20;
            int speciesToAdd = 100;
            int petsToAdd = 5000;
            int categoriesToAdd = 50;
            int productsToAdd = 200; //add it with 20 000 but it will be veeery slow
            //IT is better idea to run all of the importers separately

            var dataGenerator = new PetStoreDataGenerator(countriesToAdd, speciesToAdd, petsToAdd, categoriesToAdd, productsToAdd);
            var dataImporter = new PetStoreDataImporter();


            var categories = dataGenerator.GenerateCategories();
            Console.WriteLine(categories.Count);
            foreach (var cat in categories)
            {
                Console.WriteLine("{0}", cat.Name);
            }
            dataImporter.ImportCategories(categories);


            var countries = dataGenerator.GenerateCountries();
            foreach (var c in countries)
            {
                Console.WriteLine("{0}", c.Name);
            }
            dataImporter.ImportCountries(countries);


            var species = dataGenerator.GenerateSpecies();
            foreach (var item in species)
            {
                Console.WriteLine("{0} {1} ", item.Name, item.CountryID);
            }
            dataImporter.ImportSpecies(species);


            var pets = dataGenerator.GeneratePets();
            foreach (var pet in pets)
            {
                Console.WriteLine("{0} {1} {2} {3},", pet.Breed, pet.SpeciesID, pet.ColorID, pet.DateBirth);
            }
            dataImporter.ImportPets(pets);


            var products = dataGenerator.GenerateProducts();
            foreach (var item in products)
            {
                Console.WriteLine("{0}, {1}, {2}", item.CategoryID, item.Price, item.Name);
            }
            dataImporter.ImportProducts(products);
        }
    }
}
