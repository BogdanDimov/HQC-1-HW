using System;

namespace Test_Size_Class
{
    public class Startup
    {
        public static void Main()
        {
            var sampleSize = new Size(5, 4);
            var rotatedSize = Size.GetRotatedSize(sampleSize, 30);
            Console.WriteLine($"Rotated width: {rotatedSize.Width:f3}");
            Console.WriteLine($"Rotated height: {rotatedSize.Height:f3}");
        }
    }
}
