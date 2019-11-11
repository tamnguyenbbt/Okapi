using NUnit.Framework;
using Okapi.Drivers;
using Okapi.Elements;
using Okapi.Extensions;
using Okapi.Report;
using Okapi.Runners;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.TestCases
{
    public class SignUpPageObjectModel
    {
        //See https://okapi4automation.wordpress.com
        public const string AnyInputBox = "<input> `{0}`";
        public const string AnyBirthdayListBox = "anchor <div> `Birthday` search <select> `{0}`";
        public const string GenderRadioButton = "Anchor `{0}` <label>, search <input>";
        public const string PronounDropDown = "<select> `Select your pronoun`";
        public const string OptionalGenderInputBox = "<input> `Gender (optional)`";
        public const string SignUpButton = "<button> `Sign Up`";
        public const string ErrorMessage = "<div> `{0}`";
        public const string WhatIsYourNameToolTip = "`What's your name?`";
        public const string PleaseSelectYourPronounToolTip = "`Please select your pronoun`";
        public const string InvalidMobileNumberToolTip = "`Please enter a valid mobile number or email address.`";
    }

    [TestFixture]
    public class FullTextPOM
    {
        [Test]
        [@TestCase]
        public void TestA()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");
        }

        [Test]
        [@TestCase]
        public void TestB()
        {
            DriverPool.Instance.CreateReusableDriverFromLastRun();
            string inputText = SignUpPageObjectModel.AnyInputBox.GetTestObject("First name").Clear().SendKeys("John").Value;

            TestReport.AreEqual("John", inputText);
        }

        [Test]
        [@TestCase]
        public void TestC()
        {
            DriverPool.Instance.CreateReusableDriverFromLastRun();
            string inputText = null;

            TestExecutor.Run(true, () =>
            {
                inputText = SignUpPageObjectModel.AnyInputBox.GetTestObject("First name").Clear().SendKeys("John").Value;
            });
            

            TestReport.AreEqual("John", inputText);
        }

        [Test]
        [@TestCase]
        public void Test1()
        {
            //Arrange
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");

            //Act
            SignUpPageObjectModel.AnyInputBox.GetTestObject("First name").SendKeys("John");
            SignUpPageObjectModel.AnyInputBox.GetTestObject("surname").SendKeys("Doe");
            SignUpPageObjectModel.AnyInputBox.GetTestObject("Mobile number or email address").SendKeys("123456789");
            SignUpPageObjectModel.AnyInputBox.GetTestObject("New password").SendKeys("987654321");

            SignUpPageObjectModel.GenderRadioButton.GetTestObject().SetAnchorDynamicContents("Male").Click();

            "<button> `Sign Up`".GetTestObject().Click();

            //Assert
            bool displayed = SignUpPageObjectModel.InvalidMobileNumberToolTip.GetTestObject().Displayed;
            TestReport.IsTrue(displayed, $"Expected: tool tip displayed. Actual: {displayed}");
            TestReport.Report();
            DriverPool.Instance.QuitActiveDriver();
        }

        [Test]
        [@TestCase]
        public void Test2_I_am_a_lazy_tester()
        {
            //Arrange
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");

            //Act
            ListBox birthDayListBox = "anchor <div> `Birthday` search <select> `{0}`".GetListBox("Day");
            birthDayListBox.SelectByValue("7");
            "<button> `Sign Up`".GetTestObject().Click();
            DriverPool.Instance.QuitActiveDriver();
        }

        [Test]
        [@TestCase]
        public void Test3_a_bit_lazier()
        {
            //Arrange
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");

            //Act
            ListBox birthDayListBox = "anchor `Birthday` search `{0}` <select>".GetListBox("Day");
            birthDayListBox.SelectByValue("7");
            "`Sign Up`".GetTestObject().Click();
            DriverPool.Instance.QuitActiveDriver();
        }

        [Test]
        [@TestCase]
        public void Facebook_registration()
        {
            DriverPool.Instance.ActiveDriver.LaunchPage("https://www.facebook.com/reg");

            "<input> `{0}`".GetTestObject("First name").SendKeys("John");
            "<input> `surname`".GetTestObject().SendKeys("Doe");

            "anchor `Birthday` search `{0}` <select>".GetListBox("Day").SelectByValue("1");
            "anchor `Birthday` search `Day` <select>".GetListBox().SelectByValue("2");
            "anchor `Birthday` search <select>".GetListBox().SelectByValue("3");
            "anchor `Birthday` search `{0}`".GetListBox("Day").SelectByValue("4");
            "anchor `Birthday` search `Day`".GetListBox().SelectByValue("5");
            "anchor `Birthday`".GetListBox().SelectByValue("6");
            "<div> `Birthday`".GetListBox().SelectByValue("7");
            "`Birthday`".GetListBox().SelectByValue("8");
            "Birthday".GetListBox().SelectByValue("9");

            "Sign Up".GetTestObject().Click();

            DriverPool.Instance.QuitActiveDriver();
        }
    }
}
