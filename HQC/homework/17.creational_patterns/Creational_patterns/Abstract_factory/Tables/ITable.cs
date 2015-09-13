namespace Abstract_factory
{
    public interface ITable
    {
        Material Material{get;}
        ShapeEnum Shape{get;}
        uint NumLegs{get; }
        string toString();
    }
}
