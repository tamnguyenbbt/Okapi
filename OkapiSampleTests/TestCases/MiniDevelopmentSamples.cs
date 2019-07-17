using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Attributes;
using Okapi.Dom;
using Okapi.Drivers;
using Okapi.Enums;
using Okapi.Report;
using Okapi.Utils;

namespace OkapiSampleTests.TestCases
{
    [TestClass]
    public class MiniDevelopmentSamples
    {
        [TestMethod]
        [TestCase]
        //run this one first and do not close the browser
        public void Open_a_page_to_record()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("http://www.google.com");
        }

        [TestMethod]
        public void CodeGen_record_on_the_reusable_driver_from_last_run()
        {
            IList<string> usings = new List<string>
            {
                "System",
                "Okapi.Enums"
            };

            string nameSpace = "OkapiSampleTests.TestCases";
            IManagedDriver driver = ManagedDriver.ReusableInstanceFromLastRun.SetTimeoutInSeconds(5);
            new CodeGen(driver, usings, nameSpace).Include(ElementStatus.Enabled).Record("GoogleSearchPage_Generated", Util.CurrentProjectDirectory);
        }

        [TestMethod]
        public void CodeGen_record_on_the_reusable_driver_from_last_run_managed_by_pool()
        {
            IList<string> usings = new List<string>
            {
                "System",
                "Okapi.Enums"
            };

            string nameSpace = "OkapiSampleTests.TestCases";
            IManagedDriver driver = DriverPool.Instance.CreateReusableDriverFromLastRun();
            new CodeGen(driver, usings, nameSpace).Record("GoogleSearchPage_Generated", Util.CurrentProjectDirectory);
        }

        [TestMethod]
        public void CodeGen_record_on_the_driver_managed_by_pool()
        {
            IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");

            IList<string> usings = new List<string>
            {
                "System",
                "Okapi.Enums"
            };

            string nameSpace = "OkapiSampleTests.TestCases";
            new CodeGen(driver, usings, nameSpace).Record("GoogleSearchPage_Generated", Util.CurrentProjectDirectory);
        }

        [TestMethod]
        public void CodeGen_use_GeneratePOMFile()
        {
            IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");

            IList<string> usings = new List<string>
            {
                "System",
                "Okapi.Enums"
            };

            string nameSpace = "OkapiSampleTests.TestCases";
            //non-user intervention
            new CodeGen(driver, usings, nameSpace).GeneratePOMFile("GoogleSearchPage_Generated", Util.CurrentProjectDirectory);
        }

        [TestMethod]
        public void CodeGen_use_GeneratePOMFileUserProvidedPropertyNames()
        {
            IManagedDriver driver = DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");

            IList<string> usings = new List<string>
            {
                "System",
                "Okapi.Enums"
            };

            string nameSpace = "OkapiSampleTests.TestCases";
            //users intervention: pick which web elements (highlighted) to record and set their names or accept default names
            new CodeGen(driver, usings, nameSpace).GeneratePOMFileUserProvidedPropertyNames("GoogleSearchPage_Generated", Util.CurrentProjectDirectory);
        }
    }
}