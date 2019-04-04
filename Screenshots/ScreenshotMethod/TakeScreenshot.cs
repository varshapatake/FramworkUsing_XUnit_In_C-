using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitFramworkSameAsPytest.Screenshots.ScreenshotMethod
{
    class TakeScreenshot
    {
        public static void takeScreenshotAs(IWebDriver driver,string screenshotName)
        {
           
            
             String path = @"D:\\C#Practice\\SeleniumStudy\\xUnitFramworkSameAsPytest\\xUnitFramworkSameAsPytest\\Screenshots\\FailureScreenshot\\";
            /* var location = path + screenshotName + ".png";
             Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
             ss.SaveAsFile(location);*/
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path + screenshotName + ".png", ScreenshotImageFormat.Png);
          
        }
    }
}
