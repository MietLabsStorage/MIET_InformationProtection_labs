namespace lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Coder coder = new Coder();
            
            coder.Decode(@"src/3.bmp", @"src/3.txt");
            
            coder.Encode(@"src/14.bmp");
            coder.Decode();
        }
    }
}