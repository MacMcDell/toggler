using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Toggler.Tests
{
    [TestFixture]
    public class ToggleRepoTests
    {
        private IToggleData iData;
        private List<Toggle> togglelist;
        private IToggleRepository iRepo; 
        private ToggleRepository repo;


        [OneTimeSetUp]
        public void Setup()
        {

            togglelist = new ToggleTestData().TestData();
            iData = Substitute.For<IToggleData>();
            iRepo = Substitute.For<IToggleRepository>();
            iData.Data().Returns(togglelist);
            repo = new ToggleRepository(iData);
        }


        [Test]
        public void GetTogglesReturnsToggles()
        {
            var setup = repo.GetToggles();
            Assert.IsTrue(setup.Count() > 1);

        }

        [Test]
        public void FeatureIsEnabledWorks_basic()
        {
            var result = "first".FeatureIsEnabled(repository:repo);
            Assert.IsTrue(result);
        }
        [Test]
        public void FeatureIsEnabledWorks_WhenToggleIsNotFound()
        {
            var result = "adfafds".FeatureIsEnabled(repository:repo);
            Assert.IsTrue(result);
        }

        [Test]
        public void FeatureIsEnabledWorks_WhenOutsideDate()
        {
            var result = "adfafds".FeatureIsEnabled(repository:repo);
            Assert.IsTrue(result);
        }
    }
}
