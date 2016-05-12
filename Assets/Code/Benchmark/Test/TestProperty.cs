using System;

using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public class TestProperty : TestBase
    {
        public override string Name { get { return "Property"; } }

        public override void Prepare(IContainer container)
        {
            container.RegisterSingleton<IServiceA, ServiceA>();
            container.RegisterSingleton<IServiceB, ServiceB>();
            container.RegisterSingleton<IServiceC, ServiceC>();
            container.Register<ISubObjectA, SubObjectA>();
            container.Register<ISubObjectB, SubObjectB>();
            container.Register<ISubObjectC, SubObjectC>();
            container.Register<IComplexPropertyObject1, ComplexPropertyObject1>();
            container.Register<IComplexPropertyObject2, ComplexPropertyObject2>();
            container.Register<IComplexPropertyObject3, ComplexPropertyObject3>();
        }

        public override void Run(IContainer container)
        {
            var complex1 = (IComplexPropertyObject1)container.Resolve(typeof(IComplexPropertyObject1));
            var complex2 = (IComplexPropertyObject2)container.Resolve(typeof(IComplexPropertyObject2));
            var complex3 = (IComplexPropertyObject3)container.Resolve(typeof(IComplexPropertyObject3));

            complex1.Verify("");
            complex2.Verify("");
            complex3.Verify("");
        }

        public override bool Validate(int cycles)
        {
            if (ComplexPropertyObject1.Instances != cycles
                || ComplexPropertyObject2.Instances != cycles
                || ComplexPropertyObject3.Instances != cycles)
            {
                return false;
            }
            return true;
        }
    }
}
