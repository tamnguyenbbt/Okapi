# Handle Difficult Web Applications

Okapi API fundamental methods handle most of the cases nicely. However, when you encounter difficult-to-automate web applications. Okapi advanced methods would come into help.
Below are some of them

## WaitUntilClickable()
* Click() method waits until web element to be enabled then does one click. That would be enough for most of the cases with taking performance into consideration.
* There are scenarios such as a single page web application is reloaded or after an ajax call, the web element under test is still enabled but click action does not have effect on the element.
In such cases, adding WaitUntilClickable() would be helpful.

````
TestObject
  .New("//span[text()='Here to help']")
  .WaitUntilClickable()
  .Click();
````
## WaitUntilPageReady()
* There are scenarios such as a single page web application is reloaded or after an ajax call, the web element under test is not ready in DOM yet.
* WaitUntilPageReady() will wait for javascript, angular, jquery, ajax, etc. to be complete.

````
TestObject
  .New(SearchInfo.New("h2", "Customer Checklist"), SearchInfo.New("span"))
  .WaitUtilPageReady(10)
  .Click();
````
## ClickAndWaitForThisGone()
* Under Okapi.Extensions namespace
* Example: click a Save button once and a new page is loaded. We want to make sure that the Save button is gone before doing something else.

````
 Dynamic
   .Find("<span> `Save`")
   .WaitUntilClickable()
   .ClickAndWaitForThisGone();
````

## ClickAndWaitForOtherTestObjectEnabledAndDisplayed()
* Under Okapi.Extensions namespace
* Example: click on a button once and wait for other web element to be enabled and displayed before doing something else.

````
TestObject
  .New(SearchInfo.New("h2", "Customer Checklist"), SearchInfo.New("span"))
  .ClickAndWaitForOtherTestObjectEnabledAndDisplayed(Dynamic.Find("<span> `Save`"));
````

## RetryToClickUntilOtherTestObjectEnabledAndDisplayed()
* Under Okapi.Extensions namespace
* Similar to ClickAndWaitForOtherTestObjectEnabledAndDisplayed() but with click retries

## RetryToClickUntilAttributeValueContains()
* Under Okapi.Extensions namespace
* Retries to click on a web element until the value of an atribute of that web element changes and contains an expected text

````
TestObject
  .New("//div[label[contains(text(),'{0}')]]/div/div/div[2]");
  .SetDynamicContents("Students")
  .RetryToClickUntilAttributeValueContains("class", "ui-state-active");
````

##ClearWithBackspaceKey()
* For some web applications, normal Clear() method does not work effectively. ClearWithBackspaceKey(int numberOfBackspaces = 20) and ClearAllWithBackspaceKey() will be helpful

````
TestObject
  .New("//div[label[text()='End Date']]/x-calendar/span/input");
  .ClearAllWithBackspaceKey()
  .SendKeys(DateTime.Now.ToString("h:mm tt"));
````

## Others
- Check namespace Okapi.Extensions and Okapi.Elements.ITestObject for more methods
