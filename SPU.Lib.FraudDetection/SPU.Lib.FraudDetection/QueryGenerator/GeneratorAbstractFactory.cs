namespace FD.Lib.QueryGenerator
{
    public abstract class GeneratorAbstractFactory
    {
        public abstract void CreatePreconditionGenerator();

        public abstract void CreateRuleGenerator();
    }
}