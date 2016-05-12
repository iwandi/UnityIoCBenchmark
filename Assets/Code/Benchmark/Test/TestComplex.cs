using System;

using IoCBenchmark.Classes;

namespace IoCBenchmark
{
    public class TestComplex : TestBase
    {
        public override string Name { get { return "Complex"; } }

        public override void Prepare(IContainer container)
        {
            Complex1.Instances = 0;
            Complex2.Instances = 0;
            Complex3.Instances = 0;

            container.RegisterSingleton<IFirstService, FirstService>();
            container.RegisterSingleton<ISecondService, SecondService>();
            container.RegisterSingleton<IThirdService, ThirdService>();
            container.Register<ISubObjectOne, SubObjectOne>();
            container.Register<ISubObjectTwo, SubObjectTwo>();
            container.Register<ISubObjectThree, SubObjectThree>();
            container.Register<IComplex1, Complex1>();
            container.Register<IComplex2, Complex2>();
            container.Register<IComplex3, Complex3>();
        }

        public override void Run(IContainer container)
        {
            var complex1 = (IComplex1)container.Resolve(typeof(IComplex1));
            var complex2 = (IComplex2)container.Resolve(typeof(IComplex2));
            var complex3 = (IComplex3)container.Resolve(typeof(IComplex3));
        }

        public override bool Validate(int cycles)
        {
            if (Complex1.Instances != cycles
                || Complex2.Instances != cycles
                || Complex3.Instances != cycles)
            {
                return false;
            }
            return true;
        }
    }
}
