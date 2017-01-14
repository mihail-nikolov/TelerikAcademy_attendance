using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16.CPBuilderExample
{
    public enum MaterialType
    {
        Wooden,
        Glass,
        Marble,
        Plastic
    }

    public enum TabletopShape
    {
        Circle,
        Oval,
        Rectangular,
        Triangle,
    }
    public class Table
    {
        private MaterialType material;
        private uint legs;
        private TabletopShape shape;
        private string madeBy;
        

        public Table( MaterialType material, string madeBy)
        {
            this.Material = material;
            this.MadeBy = madeBy;            
        }

        public MaterialType Material
        {
            get { return this.material; }
            set { this.material = value; }
        }

        public uint Legs
        {
            get { return this.legs; }
            set { this.legs = value; }
        }

        public TabletopShape Shape
        {
            get { return this.shape; }
            set { this.shape = value; }
        }

        public string MadeBy
        {
            get { return this.madeBy; }
            set { this.madeBy = value; }
        }

        public override string ToString()
        {
            return String.Format(@"Table from material: {0},
with {1} legs,
{2} shape of the tabletop,
- made by --{3}--",
            this.Material, this.Legs, this.Shape, this.MadeBy);
        }

    }
}
