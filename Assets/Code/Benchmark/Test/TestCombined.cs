using System;

using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public class TestCombined : TestBase
    {
        public override string Name { get { return "Combined"; } }

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
            Singleton2.Instances = 0;

            container.Register<ICombined1, Combined1>();
            container.Register<ICombined2, Combined2>();
            container.Register<ICombined3, Combined3>();
            container.Register<ITransient1, Transient1>();
            container.Register<ITransient2, Transient2>();
            container.Register<ITransient3, Transient3>();
            container.RegisterSingleton<ISingleton1, Singleton1>();
            container.RegisterSingleton<ISingleton2, Singleton2>();
            container.RegisterSingleton<ISingleton3, Singleton3>();
        }

        public override void Run(IContainer container)
        {
            var combined1 = (ICombined1)container.Resolve(typeof(ICombined1));
            var combined2 = (ICombined2)container.Resolve(typeof(ICombined2));
            var combined3 = (ICombined3)container.Resolve(typeof(ICombined3));
        }

        public override bool Validate(int cycles)
        {
            if (Combined1.Instances != cycles
                   || Combined2.Instances != cycles
                   || Combined3.Instances != cycles)
            {
                //throw new Exception(string.Format("Combined count must be {0}", this.LoopCount));
                return false;
            }

            if (Transient1.Instances != cycles
                || Transient2.Instances != cycles
                || Transient3.Instances != cycles)
            {
                //throw new Exception(string.Format("Transient count must be {0}", this.LoopCount));
                return false;
            }

            if (Singleton1.Instances > 1 || Singleton2.Instances > 1 || Singleton2.Instances > 1)
            {
                //hrow new Exception("Singleton instance count must be 1. Container: " + container.Name);
                return false;
            }
            return true;
        }
    }
}
