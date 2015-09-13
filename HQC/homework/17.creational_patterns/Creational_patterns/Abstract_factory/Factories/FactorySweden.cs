namespace Abstract_factory.Factories
{
    public class FactorySweden: Factory, IFactory
    {
        public FactorySweden(string name) : base(name) { }

        public override GlassTable createGlassTable()
        {
            return new GlassTable(ShapeEnum.ellipse, 3, this.Name);
        }

        public override  TimberTable createTimberTable()
        {
            return new TimberTable(ShapeEnum.rectangle, 4, this.Name);
        }

        public override  PlasticTable createPlasticTable()
        {
            return new PlasticTable(ShapeEnum.circle, 3, this.Name);
        }
    }
}
