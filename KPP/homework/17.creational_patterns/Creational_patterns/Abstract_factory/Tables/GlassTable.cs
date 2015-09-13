
namespace Abstract_factory
{
    public class GlassTable : Table, ITable
    {
        public GlassTable(ShapeEnum shape, uint numberLegs, string madeBy)
            : base(shape, numberLegs, madeBy)
        {
            this.Material = Material.glass;
        }
    }
}
