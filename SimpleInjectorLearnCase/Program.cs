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

            var helloCtor1 = container.GetInstance<ISayHelloWithCtor>();
            var helloCtor2 = container.GetInstance<ISayHelloWithCtor>();

            Console.WriteLine(ReferenceEquals(helloCtor1, helloCtor2));
        }

        private static void BuildContainer(Container container)
        {
            container.Register<ISayHello, SayHello>(Lifestyle.Singleton);
            container.Register<ISayHelloWithCtor>(() => new SayHelloWithCtor("ctor"), Lifestyle.Transient);
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

    public interface ISayHelloWithCtor
    {
        void Hello();
    }

    public class SayHelloWithCtor : ISayHelloWithCtor
    {
        private readonly string _message;

        public SayHelloWithCtor(string message)
        {
            _message = message;
        }

        public void Hello()
        {
            Console.WriteLine(_message);
        }
    }
}