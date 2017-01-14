namespace Abstract_factory
{
    using System;
    public abstract class Table : ITable
    {
        private Material material;
        private ShapeEnum shape;
        private uint numberLegs;
        private string madeBy;
        private const uint MAX_LEGS = 5;
       

        public Table(ShapeEnum shape, uint numberLegs, string madeBy)
        {
            this.Shape = shape;
            this.NumLegs = numberLegs;
            this.madeBy = madeBy;
        }

        public Material Material
        {
            get
            {
                return this.material;
            }
            protected set
            {
                this.material = value;
            }
        }

        public ShapeEnum Shape
        {
            get
            {
                return this.shape;
            }
            protected set
            {
                this.shape = value;
            }
        }

        public uint NumLegs
        {
            get
            {
                return this.numberLegs;
            }
            protected set
            {
                if (value > 5)
                {
                    string error = string.Format("R u crazy! too many legs. Max {0}", Table.MAX_LEGS);
                    throw new ArgumentException(error);
                }
                this.numberLegs = value;
            }
        }


        public string toString()
        {
            string tableInformation = string.Format(@"material: {0}
shape:{1} 
legsNumber:{2},
madeBy:{3}"
, this.Material, this.Shape, this.NumLegs, this.madeBy);
            return tableInformation;
        }
    }
}
