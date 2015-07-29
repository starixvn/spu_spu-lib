namespace FD.Lib.Core
{
    using Fanex.Data.Configuration;
    using NUnit.Framework;

    [TestFixture]
    public class IntegrationTest
    {
        [SetUp]
        public virtual void SetUp()
        {
            DbSettingProviderManager.Current.Start();
        }
    }
}