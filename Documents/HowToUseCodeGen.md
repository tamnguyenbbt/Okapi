# How To Use CodeGen To Create Page Object Model (POM) Class File

## Sample Usage
````
[TestMethod]
public void Codegen()
{
    DriverPool.Instance.ActiveDriver.LaunchPage("https://www.google.com");
            
    IList<string> usings = new List<string>
    {
        "System",
        "Okapi.Enums"
    };

    string nameSpace = "Okapi.SampleTests";
    new CodeGen(usings, nameSpace).GeneratePOMFile("GoogleSearchPage.Generated", Util.CurrentProjectDirectory);            
}
````

and run the test.

## Outcome
* Check for the C# file created. In the above example, it is 'GoogleSearchPage.Generated.cs' created in current project folder

```
using System;
using Okapi.Enums;

namespace Okapi.SampleTests
{
    public class GoogleSearchPage.Generated
    {		
	public static ITestObject About => TestObject.New("//div[div[1]/div[1]/a[1][text()='About']]");
	public static ITestObject About_0 => TestObject.New("//div[div[1]/a[1][text()='About']]");
	public static ITestObject About_1 => TestObject.New("//div[a[1][text()='About']]");
	public static ITestObject About_2 => TestObject.New("//a[text()='About']");
	public static ITestObject Store => TestObject.New("//a[text()='Store']");
	...
```

## Use The Generated POM
* The best is creating your own POM class, i.e. 'GoogleSearchPage' and set it to inherit the generated class, i.e. GoogleSearchPage.Generated class
