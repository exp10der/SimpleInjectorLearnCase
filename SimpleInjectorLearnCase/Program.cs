namespace SimpleInjectorLearnCase
{
    using System;

    internal class Program
    {
        private static void Main()
        {
        }
    }

    public interface ISayHello
    {
        void Hello();
    }

    public class SayHello : ISayHello
    {
        public void Hello()
        {
            Console.WriteLine("Hello");
        }
    }
}