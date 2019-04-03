# How To Test With Chrome Driver

## Download
* Download chromedriver_win32.zip (version 73) from here https://chromedriver.storage.googleapis.com/index.html?path=73.0.3683.68/
* Unzip to get '**chromedriver.exe**' and save it into any folder

## Setup Environment PATH Variable
* Add the path to '**chromedriver.exe**' to your Windows machine environment PATH variable (Control Panel > System > Advanced System Settings > Environment Variables > System Variables)

## Config For Okapi To Pick Chrome Driver
There are 2 options - via App.config of your test project or via 
````
 public DriverFlavour DriverFlavour => DriverFlavour.Chrome;
````

of your class which implements ITestEnvironment interface

## Testing
Write a test method calling
````
  DriverPool.Instance.ActiveDriver.LaunchPage("http://www.google.com");
````
and run. Local Chrome driver will be launched 
