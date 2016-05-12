using System;

using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public class TestFactory : TestBase
    {
        public override string Name { get { return "Factory"; } }

        public override bool Supported(IContainer container)
        {
            return container.SupportsFunctionRegistration;
        }

        public override void Prepare(IContainer container)
        {
            Combined1.Instances = 0;
            Combined2.Instances = 0;
            Combined3.Instances = 0;
            Transient1.Instances = 0;
            Transient2.Instances = 0;
            Transient3.Instances = 0;
            Singleton1.Instances = 0;
            Singleton2.Instances = 0;
            Singleton3.Instances = 0;

            container.Register<ITransient1>((IContainer ctx) =>
            {
                return new Transient1();
            });
            container.Register<ITransient2>((IContainer ctx) =>
            {
                return new Transient2();
            });
            container.Register<ITransient3>((IContainer ctx) =>
            {
                return new Transient3();
            });

            var singleton1 = new Singleton1();
            var singleton2 = new Singleton2();
            var singleton3 = new Singleton3();

            container.Register<ISingleton1>((IContainer ctx) =>
            {
                return singleton1;
            });
            container.Register<ISingleton2>((IContainer ctx) =>
            {
                return singleton2;
            });
            container.Register<ISingleton3>((IContainer ctx) =>
            {
                return singleton3;
            });
        }

        public override void Run(IContainer container)
        {
            var transient1 = (ITransient1)container.Resolve(typeof(ITransient1));
            var transient2 = (ITransient2)container.Resolve(typeof(ITransient2));
            var transient3 = (ITransient3)container.Resolve(typeof(ITransient3));

            var singleton1 = (ISingleton1)container.Resolve(typeof(ISingleton1));
            var singleton2 = (ISingleton2)container.Resolve(typeof(ISingleton2));
            var singleton3 = (ISingleton3)container.Resolve(typeof(ISingleton3));
        }

        public override bool Validate(int count)
        {
            return Transient1.Instances == count && Transient2.Instances == count && Transient3.Instances == count && 
                Singleton1.Instances == 1 && Singleton2.Instances == 1 && Singleton3.Instances == 1;
        }
    }
}