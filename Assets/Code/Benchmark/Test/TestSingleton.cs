using System;

using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public class TestSingleton : TestBase
    {
        public override string Name {  get { return "Singleton"; } }

        public override void Prepare(IContainer container)
        {
            Singleton1.Instances = 0;
            Singleton2.Instances = 0;
            Singleton3.Instances = 0;

            container.RegisterSingleton<ISingleton1, Singleton1>();
            container.RegisterSingleton<ISingleton2, Singleton2>();
            container.RegisterSingleton<ISingleton3, Singleton3>();
        }

        public override void Run(IContainer container)
        {
            var singleton1 = (ISingleton1)container.Resolve(typeof(ISingleton1));
            var singleton2 = (ISingleton2)container.Resolve(typeof(ISingleton2));
            var singleton3 = (ISingleton3)container.Resolve(typeof(ISingleton3));
        }

        public override bool Validate(int cycles)
        {
            return Singleton1.Instances == 1 && Singleton2.Instances == 1 && Singleton2.Instances == 1;
        }
    }
}
