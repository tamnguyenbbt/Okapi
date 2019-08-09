using NUnit.Framework;
using Okapi.Drivers;
using Okapi.Report;
using Okapi.Support.Report.NUnit;
using OkapiSampleTests.PageObjectModelSample.Data;
using OkapiSampleTests.PageObjectModelSample.DTOs;
using OkapiSampleTests.PageObjectModelSample.POMs;
using OkapiSampleTests.PageObjectModelSample.Steps;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.PageObjectModelSample.TestCases
{
    [TestFixture]
    public class SignUpTestCases
    {
        private readonly AccountDataSet accountDataSet = new AccountDataSet();

        [SetUp]
        public void TestInit()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");
        }

        [TearDown]
        public void TestCleanup()
        {
            TestReport.Report(TestContext.CurrentContext.ToOkapiTestContext());
            DriverPool.Instance.QuitActiveDriver(); //Force closing browser
        }

        [Test]
        //[@TestCase] //Decorated with Okapi 'TestCase' attribute and closed with TestReport.Report() so that this test case gets reported
        public void Fail_to_create_a_new_account_when_password_is_not_secure()
        {
            //Arrange
            AccountDTO account = accountDataSet.PasswordNotSecureTestAccount;

            //Act
            SignUpSteps.Create_a_new_account(account);

            //Assert
            SignUpPage.ErrorMessage.SetDynamicContents("Please choose a more secure password").WaitUntilEnabled(5);
        }

        [Test]
        [@TestCase]
        public void Long_first_name_chopped_after_clicking_sign_up_button()
        {
            //Arrange
            AccountDTO account = accountDataSet.LongFirstNameTestAccount;

            //Act
            SignUpSteps.Create_a_new_account(account);

            //Assert
            var a = SignUpPage
                .ErrorMessage
                .SetDynamicContents("There is a limit on the number of characters in first names").AllLocators;

            SignUpPage
                .ErrorMessage
                .SetDynamicContents("There is a limit on the number of characters in first names")
                .WaitUntilEnabled();
        }

        [Test]
        [@TestCase]
        public void Fail_to_create_a_new_account_when_first_name_is_not_provided()
        {
            //Arrange
            AccountDTO account = accountDataSet.NonProvidedFirstNameTestAccount;

            //Act
            SignUpSteps.Create_a_new_account(account);

            //Assert
            bool displayed = SignUpPage.WhatIsYourNameToolTip.Displayed;
            TestReport.IsTrue(displayed, $"Expected: 'What's your name' tool tip displayed. Actual: {displayed}");
        }

        [Test]
        [@TestCase]
        public void Fail_to_create_a_new_account_when_custom_gender_pronoun_is_not_provided()
        {
            //Arrange
            AccountDTO account = accountDataSet.NonProvidedPronounTestAccount;

            //Act
            SignUpSteps.Create_a_new_account(account);

            //Assert
            bool displayed = SignUpPage.PleaseSelectYourPronounToolTip.Displayed;
            TestReport.IsTrue(displayed, $"Expected: 'Please select your pronoun' tool tip displayed. Actual: {displayed}");
        }
    }
}
