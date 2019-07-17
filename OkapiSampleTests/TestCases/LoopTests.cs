using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okapi.Attributes;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Report;
using Okapi.Runners;
using OkapiSampleTests.Steps;
using OkapiSampleTests.TestData;

namespace OkapiSampleTests.TestCases
{
    [TestClass]
    public class LoopTests
    {
        [TestMethod]
        [TestCase]
        public void Loop_test_with_data_set()
        {
            IDataSet<Registration> dataSet = new RegistrationDataSet();
            TestExecutor.Loop(SampleSteps.Loop_scenario, dataSet);
            TestReport.Report();
        }

        [TestMethod]
        [TestCase]
        public void Loop_test_with_data_list()
        {
            IList<Registration> testData = new List<Registration>
            {
                new Registration()
                {
                    UserName = "Automation1"
                },
                new Registration()
                {
                    UserName = "Automation2"
                },
            };

            TestExecutor.Loop(SampleSteps.Loop_scenario, testData);
            TestReport.Report();
        }

        [TestMethod]
        [TestCase]
        public void Parallel_test_with_data_list()
        {
            IList<Registration> testData = new List<Registration>
            {
                new Registration()
                {
                    UserName = "Automation1"
                },
                new Registration()
                {
                    UserName = "Automation2"
                },
            };

            TestExecutor.Parallel(SampleSteps.Loop_scenario, testData);
            TestReport.Report();
        }

        [TestMethod]
        [TestCase]
        public void Parallel_test_with_data_set()
        {
            TestExecutor.Parallel(SampleSteps.Loop_scenario, new RegistrationDataSet());
            TestReport.Report();
        }

        [TestMethod]
        [TestCase]
        public void Parallel_test_with_data_set_in_line()
        {
            TestExecutor.Parallel(
                new Action<Registration>(x =>
                {
                    DriverPool.Instance.ActiveDriver.LaunchPage("https://www.xero.com/au/signup/");
                    var userName = TestObject.New("//label[span[contains(text(),'First name')]]/input");
                    userName.SendKeys(x.UserName);
                    DriverPool.Instance.QuitActiveDriver();
                })
            , new RegistrationDataSet());

            TestReport.Report();
        }
    }
}