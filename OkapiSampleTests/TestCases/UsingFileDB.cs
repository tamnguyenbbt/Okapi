using System.IO;
using NUnit.Framework;
using Okapi.Extensions;
using Okapi.Report;
using Okapi.Utils;
using Okapi.Utils.DB;
using OkapiSampleTests.PageObjectModelSample.Data;
using OkapiSampleTests.PageObjectModelSample.DTOs;
using TestCase = Okapi.Attributes.TestCaseAttribute;

namespace OkapiSampleTests.TestCases
{
    [TestFixture]
    //File Database utility for sharing test data between tests and between execution sessions
    public class UsingFileDB
    {
        [Test]
        [@TestCase]
        public void Test1_some_simple_operations()
        {
            //Arrange
            FileDB fileDB = new FileDB($"{Util.CurrentProjectDirectory}{Path.DirectorySeparatorChar}DataBase{Path.DirectorySeparatorChar}SharedDB.txt");

            //Act
            fileDB.Insert(new AccountDataSet().PasswordNotSecureTestAccount, "Password not secure account");

            DbObject<AccountDTO> record = fileDB.GetLastInsertedRecordInTheSameExecutionThread<AccountDTO>();

            AccountDTO payload = fileDB.GetLastInsertedPayloadInTheSameExecutionThread<AccountDTO>();
            payload.FirstName = "Will";

            fileDB.Update(record.Id, payload, "Change name to Will");

            fileDB.AddStatus<AccountDTO>(record.Id, "Will is on his holidays", "He will be back soon");

            record = fileDB.GetLastInsertedRecordByStatus<AccountDTO>(FileDBSearchMethod.StringContainIgnoreCase, "password not secure", "be back soon");

            fileDB.ReplaceStatus<AccountDTO>(record.Id, "Will is now back to work");

            record = fileDB.GetLastInsertedRecordByStatus<AccountDTO>(FileDBSearchMethod.Exact, "Will is now back to work");

            fileDB.Delete<AccountDTO>(record.Id);

            var allRecords = fileDB.FindAll<AccountDTO>();

            var lastRecord = fileDB.FindById<AccountDTO>(record.Id);

            //Assert
            TestReport.IsFalse(allRecords.HasAny());
            TestReport.IsTrue(lastRecord == null);
        }
    }
}