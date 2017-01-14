namespace Abstract_factory
{
    public class TimberTable : Table, ITable
    {
        public TimberTable(ShapeEnum shape, uint numberLegs, string madeBy)
            : base(shape, numberLegs, madeBy)
        {
            this.Material = Material.timber;
        }
    }
}
