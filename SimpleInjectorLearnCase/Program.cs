namespace SimpleInjectorLearnCase
{
    using System;
    using SimpleInjector;

    internal class Program
    {
        private static void Main()
        {
            var container = new Container();
            BuildContainer(container);

        }

        private static void BuildContainer(Container container)
        {
            container.Register<ISayHello, SayHello>(Lifestyle.Singleton);
            container.Verify();
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