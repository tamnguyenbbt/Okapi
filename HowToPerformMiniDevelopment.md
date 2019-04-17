# How To Perform A Mini Development
Imagine the web application under test has 10 pages and you have automated the first 9 pages.

Now you need to automate page 10 (capture web objects, save them into test object repository, check if they are working fine, etc.).

You don't want to step through the first 9 pages just to perform the script development and test the script for page 10 because it is painful.

Okapi has 2 methods helping you to perform a mini development.

````
DriverPool.Instance.CreateReusableDriver(Uri serverUri, SessionId sessionId, bool setAsActive = true);
DriverPool.Instance.CreateReusableDriverFromLastRun(bool setAsActive = true)
````
## Sample Usage
Assume you have already built 90% of the script to test automate Google SignIn page.

Now you just captured an XPATH for **UserNameTextBox** and want to test if it is working fine.

And you don't want to attach it to the end of that test script to run everything again.

Just run your already built script without **UserNameTextBox** which you know it works fine. When it finishes, do not close the browser.

Run the development supportive code similar to the one below to test your newly developed code which is the code for **UserNameTextBox** in this example. 

It will help to confirm if the newly developed code/xpath information is correct without to run the whole thing again and again. 

When it is confirmed to be good, plug it to your existing script. This is extremely helpful for progressive automation scripting.

````
public class DevelopmentSupport
{
    [Test]        
    public void TestTheScript()
    {
        IManagedDriver driver = DriverPool.Instance
        .CreateReusableDriverFromLastRun()
        .SetTimeoutInSeconds(10);
            
        GoogleSignInPageObjectModel.UserNameTextBox.Highlight().Click();
    }
}

public class GoogleSignInPageObjectModel
{
    public static TestObject UserNameTextBox => TestObject.New("//tbody[tr/td[text()='User Name']]/tr/td/div[2]");
}
````
