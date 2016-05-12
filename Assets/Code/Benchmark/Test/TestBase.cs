using System;

namespace IoCBenchmark
{
    public abstract class TestBase
    {
        public abstract string Name { get; }

        public virtual bool Supported(IContainer container)
        {
            return true;
        }

        public abstract void Prepare(IContainer container);
        public abstract void Run(IContainer container);
        public abstract bool Validate(int count);
    }
}
