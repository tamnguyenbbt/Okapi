# Get Returned XPaths

````
IList<string> xpaths = "<button> `Save`".GetTestObject().AllLocatorsBrowserFriendly; --> xpaths ready to be pasted to browser to test
IList<string> xpaths = "<button> `Save`".GetTestObject().AllLocators; --> xpaths as C# strings
````
