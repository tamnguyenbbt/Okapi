using System.Collections.Generic;
using Okapi.Runners;

namespace OkapiSampleTests.TestData
{
    public class RegistrationDataSet : IDataSet<Registration>
    {
        public IList<Registration> Get()
        {
            var data = new List<Registration>
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

            return data;
        }
    }
}