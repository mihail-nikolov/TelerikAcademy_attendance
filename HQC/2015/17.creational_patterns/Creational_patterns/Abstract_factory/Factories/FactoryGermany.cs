namespace Abstract_factory.Factories
{
    public class FactoryGermany:Factory, IFactory
    {
        public FactoryGermany(string name) : base(name) { }

        public override GlassTable createGlassTable()
        {
            return new GlassTable(ShapeEnum.circle, 3, this.Name);
        }

        public override  TimberTable createTimberTable()
        {
            return new TimberTable(ShapeEnum.square, 5, this.Name);
        }

        public override  PlasticTable createPlasticTable()
        {
            return new PlasticTable(ShapeEnum.ellipse, 4, this.Name);
        }
    }
}
