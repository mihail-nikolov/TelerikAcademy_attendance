//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetStore.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Species
    {
        public Species()
        {
            this.Pets = new HashSet<Pet>();
            this.Products = new HashSet<Product>();
        }
    
        public int SpeciesID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
