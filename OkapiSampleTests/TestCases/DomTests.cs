using System.Collections.Generic;
using System.Linq;
using ExtSelenium.DomCore;
using ExtSelenium.XPaths;
using NUnit.Framework;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Report;
using Okapi.Support.Report.NUnit;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.TestCases
{
    [TestFixture]
    public class DomTests
    {
        private IManagedDriver driver = null;

        [OneTimeSetUp]
        public void ClassInit()
        {
            driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            DriverPool.Instance.QuitActiveDriver();
        }

        [TearDown]
        public void TestCleanup()
        {
            TestReport.Report(TestContext.CurrentContext.ToOkapiTestContext());
        }

        [Test]
        [TestCase]
        public void Get_unverified_managed_xpaths_for_document()
        {
            string html = driver.Html;
            Dom dom = new Dom(html);
            ManagedXPaths managedXPaths = dom.UnverifiedDocumentManagedXPaths;
            List<string> allRecomendedUnverifiedXPaths = managedXPaths?.Select(x => x.RecomendedUnverifiedLocator)?.ToList();
        }

        [Test]
        [TestCase]
        public void Get_verified_managed_xpaths_for_document()
        {
            driver = DriverPool.Instance.GetReusableDriver();
            ManagedXPaths verifiedManagedXPaths = driver.GetDocumentManagedXPaths();
            List<string> allVerifiedXPaths = verifiedManagedXPaths?.Select(x => x.VerifiedLocator)?.ToList();
        }
    }
}