using System;

using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public class TestTransient : TestBase
    {
        public override string Name { get { return "Transient"; } }

        public override void Prepare(IContainer container)
        {
            Transient1.Instances = 0;
            Transient2.Instances = 0;
            Transient3.Instances = 0;

            container.Register<ITransient1, Transient1>();
            container.Register<ITransient2, Transient2>();
            container.Register<ITransient3, Transient3>();
        }

        public override void Run(IContainer container)
        {
            var transient1 = (ITransient1)container.Resolve(typeof(ITransient1));
            var transient2 = (ITransient2)container.Resolve(typeof(ITransient2));
            var transient3 = (ITransient3)container.Resolve(typeof(ITransient3));
        }

        public override bool Validate(int count)
        {
            return Transient1.Instances == count && Transient2.Instances == count && Transient3.Instances == count;
        }
    }
}
