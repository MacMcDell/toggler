using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace Toggler.Tests
{
    [TestFixture]
    public class ToggleRepoTests
    {
        private IToggleData iData;
        private List<Toggle> togglelist;

        private ToggleRepository repo;


        [OneTimeSetUp]
        public void Setup()
        {
            togglelist = new ToggleTestData().TestData();
            iData = Substitute.For<IToggleData>();
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
            var result = "first".FeatureIsEnabled(repository: repo);
            Assert.IsTrue(result);
        }
        [Test]
        public void FeatureIsEnabledWorks_WhenToggleIsNotFound()
        {
            var result = "adfafds".FeatureIsEnabled(repository: repo);
            Assert.IsTrue(result);
        }

        [Test]
        public void FeatureIsEnabledReturnsFalse_WhenOutsideDate()
        {
            var result = "DateExpired".FeatureIsEnabled(repository: repo);
            Assert.IsFalse(result);
        }

        [Test]
        public void FeatureIsEnabledWorksWhenNoEndDate()
        {
            var result = "NoEndDate".FeatureIsEnabled(repository: repo);
            Assert.IsTrue(result);
        }
        [Test]
        public void FeatureIsEnabledWorksWhenNoStartdDate()
        {
            var result = "NoStartDate".FeatureIsEnabled(repository: repo);
            Assert.IsTrue(result);
        }

        [Test]
        public void FeatureIsFalseWhenEndExpiredAndNoStartDate()
        {
            var result = "NoStartDateEndExpired".FeatureIsEnabled(repository: repo);
            Assert.IsFalse(result);
        }
        [Test]
        public void FeatureIsEnabledNoStartDateAndPriorToEndDate()
        {
            var result = "NoStartDateEndNotExpired".FeatureIsEnabled(repository: repo);
            Assert.IsTrue(result);
        }

        [Test]
        public void FeatureIsFalseDueToDependancy()
        {
            var result = "firstDependsOnSecond".FeatureIsEnabled(repository: repo);
            Assert.IsFalse(result);
        }
        [Test]
        public void FeatureIsFalseCascadingDependancy()
        {
            var result = "SecondDependsOnThird".FeatureIsEnabled(repository: repo);
            Assert.IsFalse(result);
        }

        [Test]
        public void SetData()
        {
            var repo = new ToggleRepository();
            var t = new Toggle()
            {
                Name = "inserttest",
                IsEnabled = true
            };
            repo.SetToggle(t);
        }
    }
}
