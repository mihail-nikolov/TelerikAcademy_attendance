using System;

public class Size
{
    public double width, height;
    public Size(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public static Size GetRotatedSize(Size currentSize, double angleOfRotation)
    {
        double rotatedWidth = (Math.Abs(Math.Sin(angleOfRotation) + Math.Abs(Math.Cos(angleOfRotation)))) * currentSize.width;
        double rotatedHeight = (Math.Abs(Math.Sin(angleOfRotation) + Math.Abs(Math.Cos(angleOfRotation)))) * currentSize.height;
        Size rotatedSize = new Size(rotatedWidth, rotatedHeight);
        return rotatedSize;
    }
}