namespace Abstract_factory
{
    public class PlasticTable : Table, ITable
    {
        public PlasticTable(ShapeEnum shape, uint numberLegs, string madeBy)
            : base(shape, numberLegs, madeBy)
        {
            this.Material = Material.plastic;
        }
    }
}
