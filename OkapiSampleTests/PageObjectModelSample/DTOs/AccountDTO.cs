using System;

namespace OkapiSampleTests.PageObjectModelSample.DTOs
{
    //Looking at https://www.facebook.com/reg to get information to create this class
    public class AccountDTO
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public string CustomPronoun { get; set; }
        public string CustomGender { get; set; }
    }
}
