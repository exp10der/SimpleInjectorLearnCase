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

            var hello1 = container.GetInstance<ISayHello>();
            var hello2 = container.GetInstance<ISayHello>();

            Console.WriteLine(ReferenceEquals(hello1, hello2));
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