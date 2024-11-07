using OpenQA.Selenium;
using System;
using System.Collections.Generic;

public static class WindowFrameAlertUtilities
{
    // WINDOWS UTILITIES

    // Method to switch to a new tab
    public static void SwitchToNewTab(IWebDriver driver)
    {
        var originalWindow = driver.CurrentWindowHandle;
        var allWindows = driver.WindowHandles;

        foreach (var window in allWindows)
        {
            if (window != originalWindow)
            {
                driver.SwitchTo().Window(window);
                Console.WriteLine("Switched to new tab: " + window);
            }
        }
    }

    // Method to switch to a new window
    public static void SwitchToNewWindow(IWebDriver driver)
    {
        var originalWindow = driver.CurrentWindowHandle;
        var allWindows = driver.WindowHandles;
        var count = driver.WindowHandles.Count;
        Console.WriteLine("Number of windows: " + count);

        foreach (var window in allWindows)
        {
            if (window != originalWindow)
            {
                driver.SwitchTo().Window(window);
                Console.WriteLine("Switched to new window: " + window);
                driver.Manage().Window.Maximize();


            }
        }
    }

    // FRAMES UTILITIES

    // Method to print all available frames on the page
    public static void PrintAllFrames(IWebDriver driver)
    {
        IList<IWebElement> frames = driver.FindElements(By.TagName("iframe"));
        Console.WriteLine("Number of frames: " + frames.Count);
        foreach (var frame in frames)
        {
            Console.WriteLine("Frame ID/Name: " + frame.GetAttribute("id") + " / " + frame.GetAttribute("name"));
        }
    }

    // Method to switch to a frame using frame name
    public static void SwitchToFrameByName(IWebDriver driver, string frameName)
    {
        driver.SwitchTo().Frame(frameName);
        Console.WriteLine("Switched to frame: " + frameName);
    }

    // Method to switch back to the default content
    public static void SwitchToDefaultContent(IWebDriver driver)
    {
        driver.SwitchTo().DefaultContent();
        Console.WriteLine("Switched back to default content");
    }

    // ALERT UTILITIES

    // Method to check for an alert, print the message, and accept it
    public static void HandleAlert(IWebDriver driver)
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert message: " + alert.Text);
            alert.Accept();
            Console.WriteLine("Alert accepted.");
        }
        catch (NoAlertPresentException)
        {
            Console.WriteLine("No alert present.");
        }
    }

    public static void CancelAlert(IWebDriver driver)
    {
        try
        {
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Alert message: " + alert.Text);
            alert.Dismiss();
            Console.WriteLine("Alert dismissed.");
        }
        catch (NoAlertPresentException)
        {
            Console.WriteLine("No alert present.");
        }
    }



    public static void promptBoxAlert(IWebDriver driver, string input)
    {
        IAlert promptalert = driver.SwitchTo().Alert();
        promptalert.SendKeys(input);
        promptalert.Accept();
    }
}