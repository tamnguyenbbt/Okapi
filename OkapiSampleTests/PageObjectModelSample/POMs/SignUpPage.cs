using Okapi.Elements;
using Okapi.Enums;

namespace OkapiSampleTests.PageObjectModelSample.POMs
{
    //Looking at https://www.facebook.com/reg to have information to build this POM class. More of 'what you see is what you get'.
    public class SignUpPage
    {
        public static ITestObject AnyInputBox => TestObject.New(SearchInfo.New(HtmlTag.input, "{0}"));

        //Easier to create at development time but takes longer time to run because the Search by anchor engine has to do more jobs
        public static ITestObject AnyInputBoxV2 => TestObject.New(SearchInfo.OwnText("{0}"));

        public static ITestObject AnyBirthdayListBox => ListBox.New(SearchInfo.New(HtmlTag.div, "Birthday"), SearchInfo.New(HtmlTag.select, "{0}"));

        public static ITestObject FirstNameInputBox => AnyInputBox.SetAnchorDynamicContents("First name");
        public static ITestObject SurNameInputNox => AnyInputBox.SetAnchorDynamicContents("surname");
        public static ITestObject ContactInputBox => AnyInputBox.SetAnchorDynamicContents("Mobile number or email address");
        public static ITestObject PasswordInputBox => AnyInputBox.SetAnchorDynamicContents("New password");
        public static ITestObject BirthDayDropDown => AnyBirthdayListBox.SetSearchElementDynamicContents("Day");
        public static ITestObject BirthMonthDropDown => AnyBirthdayListBox.SetSearchElementDynamicContents("Month");
        public static ITestObject BirthYearDropDown => AnyBirthdayListBox.SetSearchElementDynamicContents("Year");
        public static ITestObject GenderRadioButton => TestObject.New(SearchInfo.New(HtmlTag.label, "{0}"), SearchInfo.New(HtmlTag.input));
        public static ITestObject PronounDropDown => ListBox.New(SearchInfo.New(HtmlTag.select, "Select your pronoun"));
        public static ITestObject OptionalGenderInputBox => TestObject.New(SearchInfo.New(HtmlTag.input, "Gender (optional)"));
        public static ITestObject SignUpButton => TestObject.New(SearchInfo.New("button", "Sign Up"));
        public static ITestObject ErrorMessage => TestObject.New(SearchInfo.New(HtmlTag.div, "{0}"));
        public static ITestObject WhatIsYourNameToolTip => TestObject.New(SearchInfo.OwnText("What's your name?"));
        public static ITestObject PleaseSelectYourPronounToolTip => TestObject.New(SearchInfo.OwnText("Please select your pronoun"));
    }
}