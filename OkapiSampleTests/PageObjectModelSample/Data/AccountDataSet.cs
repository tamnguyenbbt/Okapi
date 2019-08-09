using System;
using System.Collections.Generic;
using OkapiSampleTests.PageObjectModelSample.DTOs;
using Okapi.Extensions;
using Okapi.Runners;
using Okapi.Utils;

namespace OkapiSampleTests.PageObjectModelSample.Data
{
    public class AccountDataSet : INamedDataSet<AccountDTO>
    {
        public AccountDTO PasswordNotSecureTestAccount => Get()["Password Not Secure"];
        public AccountDTO NonProvidedFirstNameTestAccount => Get()["First Name Not Provided"];
        public AccountDTO NonProvidedPronounTestAccount => Get()["Pronoun Not Provided"];
        public AccountDTO LongFirstNameTestAccount => Get()["Long First Name"];

        public IDictionary<string, AccountDTO> Get()
        {
            var data = new Dictionary<string, AccountDTO>();

            data.Append(new NamedDataItem<AccountDTO>
            {
                Name = "Password Not Secure",
                Data = new AccountDTO
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Birthday = new DateTime(2000, 12, 24),
                    Contact = "0434 857 768",
                    Password = "Password",
                    Gender = Gender.Custom,
                    CustomPronoun = "He: \"Wish him a happy birthday!\"",
                    CustomGender = "Beautiful"
                }
            });

            data.Append(new NamedDataItem<AccountDTO>
            {
                Name = "First Name Not Provided",
                Data = new AccountDTO
                {
                    FirstName = null,
                    Surname = Util.RandomText(5, 20),
                    Birthday = DateTime.Now.AddYears(-20),
                    Contact = Util.RandomNumber(8, 10),
                    Password = Util.RandomText(20, 30),
                    Gender = Gender.Female
                }
            });

            data.Append(new NamedDataItem<AccountDTO>
            {
                Name = "Pronoun Not Provided",
                Data = new AccountDTO
                {
                    FirstName = Util.RandomText(5, 10),
                    Surname = "Doe",
                    Birthday = new DateTime(2000, 12, 24),
                    Contact = "0434 857 768",
                    Password = "Password1$5238#!",
                    Gender = Gender.Custom,
                    CustomPronoun = null,
                    CustomGender = "Beautiful"
                }
            });

            data.Append(new NamedDataItem<AccountDTO>
            {
                Name = "Long First Name",
                Data = new AccountDTO
                {
                    FirstName = Util.RandomText(500, 1000),
                    Surname = "Doe",
                    Birthday = new DateTime(2000, 12, 24),
                    Contact = "0434 857 768",
                    Password = "1P@ssw01rd!@3",
                    Gender = Gender.Male
                }
            });

            return data;
        }
    }
}
