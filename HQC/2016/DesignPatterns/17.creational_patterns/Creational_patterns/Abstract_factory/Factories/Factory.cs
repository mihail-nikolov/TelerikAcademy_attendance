namespace Abstract_factory.Factories
{

    using System;
    public abstract class Factory:IFactory
    {
        private string name;
        private const uint MIN_FACTORY_NAME_LENGTH = 3;

        public Factory(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (value.Length <= 0)
                {
                    string error = string.Format("name length > {0}", Factory.MIN_FACTORY_NAME_LENGTH);
                    throw new ArgumentException(error);
                }
                this.name = value;
            }
        }
        public virtual GlassTable createGlassTable()
        {
            return new GlassTable(ShapeEnum.square, 4, this.Name);
        }

        public virtual TimberTable createTimberTable()
        {
            return new TimberTable(ShapeEnum.square, 4, this.Name);
        }

        public virtual PlasticTable createPlasticTable()
        {
            return new PlasticTable(ShapeEnum.square, 4, this.Name);
        }
    }
}
