using System;
using System.Globalization;
using Okapi.Attributes;
using Okapi.Elements;
using Okapi.Report;
using OkapiSampleTests.PageObjectModelSample.DTOs;
using OkapiSampleTests.PageObjectModelSample.POMs;

namespace OkapiSampleTests.PageObjectModelSample.Steps
{
    public class SignUpSteps
    {
        [Step]
        //Decorated with Okapi attribute 'Step' and closed with TestReport.Report() so activities within this step are reported
        public static void Create_a_new_account(AccountDTO account)
        {
            SignUpPage.FirstNameInputBox.SendKeys(account.FirstName);
            SignUpPage.SurNameInputNox.SendKeys(account.Surname);
            SignUpPage.ContactInputBox.SendKeys(account.Contact);
            SignUpPage.PasswordInputBox.SendKeys(account.Password);
            Set_birth_day(account.Birthday);
            Set_gender(account.Gender);
            Set_custom_gender(account.CustomPronoun, account.CustomGender);
            SignUpPage.SignUpButton.Click();
            TestReport.Report();
        }

        [Step]
        public static void Set_birth_day(DateTime birthday)
        {
            if (birthday != default(DateTime))
            {
                string day = birthday.Day.ToString();
                string month = birthday.ToString("MMM", CultureInfo.InvariantCulture);
                string year = birthday.Year.ToString();

                (SignUpPage.BirthDayDropDown as ListBox).SelectByValue(day);
                (SignUpPage.BirthMonthDropDown as ListBox).SelectByText(month);
                (SignUpPage.BirthYearDropDown as ListBox).SelectByText(year);
            }

            TestReport.Report();
        }

        [Step]
        public static void Set_gender(Gender gender)
        {
            if (gender != Gender.NotSet)
            {
                SignUpPage.GenderRadioButton.SetAnchorDynamicContents(gender.ToString()).Click();
            }

            TestReport.Report();
        }

        [Step]
        public static void Set_custom_gender(string pronoun, string optionalGender)
        {
            (SignUpPage.PronounDropDown as ListBox).SelectByText(pronoun);
            SignUpPage.OptionalGenderInputBox.SendKeys(optionalGender);
            TestReport.Report();
        }
    }
}