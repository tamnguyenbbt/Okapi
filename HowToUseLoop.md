# How To Use Loop

## Example Scenario
Need to enter several emails into a contact page. Test data is from data set

## Example Page Object Model
````
public class ContactPage
{
    public static void AddEmail(string email)
    {
        TestObject.New("//input[@placeholder='Email']").SendKeys(email);
        TestObject.New(SearchInfo.OwnText("{0}")).SetDynamicContents(email).Click();
    }
}
````

## Example Data Template
````
  public class ContactDTO
    {
        public string Email { get; set; }
    }
````

## Example DataSet

````
public class ContactDataSet : IDataSet<ContactDTO>
    {
        public IList<ContactDTO> Get()
        {
            return new List<ContactDTO>
            {
                new ContactDTO
                {
                    Email = "tester1@gmail.com"
                },
                new ContactDTO
                {
                    Email = "tester2@yahoo.com"
                }
            };
        }
    }
````

# Example Step
````
[Step]
public static void Add_emails(ContactDataSet contactDataSet)
{
    MainPage.ClickSelectContactLink();
    TestExecutor.Loop((contact) => ContactPage.AddEmail(contact.Email), contactDataSet);            
    CommonObjects.SaveButton.Click();
    TestReport.Report();
}
        
````

You then can call this Add_emails step from any test script and pass contactDataSet in, where:
````
var contactDataSet = new ContactDataSet();
````
