namespace Infestation
{
    class Parasite : InfestingUnit
    {
        public Parasite(string id) 
            : base(id, UnitClassification.Biological, 1)
        {
        }
    }
}
