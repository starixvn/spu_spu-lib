namespace FD.Lib.QueryGenerator
{
    public abstract class GeneratorAbstractFactory
    {
        public abstract void CreatePreconditionGenerator();

        public abstract void CreateRuleGenerator();
    }

    public class GeneratorAbstractFactoryForFindBettingGroup : GeneratorAbstractFactory
    {
        public override void CreatePreconditionGenerator()
        {
            throw new System.NotImplementedException();
        }

        public override void CreateRuleGenerator()
        {
            throw new System.NotImplementedException();
        }
    }
}