namespace Abstract_factory.Factories
{
    public interface IFactory
    {
        string Name { get;}
        GlassTable createGlassTable();
        TimberTable createTimberTable();
        PlasticTable createPlasticTable();
    }
}
