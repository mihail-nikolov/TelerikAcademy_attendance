


namespace Shapes
{
	using System;
    public class Hexagon: Shape
	{
		 		    private double side1;
			public double Side1
			{
				get { return this.side1; }
				private set
				{
				    if (value < 0)
				    {
				        throw new ArgumentException("length > 0");
				    }
				    this.side1 = value;
				}
			}
				    private double side2;
			public double Side2
			{
				get { return this.side2; }
				private set
				{
				    if (value < 0)
				    {
				        throw new ArgumentException("length > 0");
				    }
				    this.side2 = value;
				}
			}
				    private double side3;
			public double Side3
			{
				get { return this.side3; }
				private set
				{
				    if (value < 0)
				    {
				        throw new ArgumentException("length > 0");
				    }
				    this.side3 = value;
				}
			}
				    private double side4;
			public double Side4
			{
				get { return this.side4; }
				private set
				{
				    if (value < 0)
				    {
				        throw new ArgumentException("length > 0");
				    }
				    this.side4 = value;
				}
			}
				public Hexagon(double height, double width,double side1, double side2, double side3, double side4) :
            base(width, height) 
		{ 
		     				this.Side1 = side1;
		    				this.Side2 = side2;
		    				this.Side3 = side3;
		    				this.Side4 = side4;
		    		}
	}
}
