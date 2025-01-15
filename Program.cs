using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = null!; // Null initialization to suppress warning

        try
        {
            // Start the Chrome browser
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize(); // Maximize the browser window

            // Navigate to Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // Find the search box and perform a search
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium C#"); // Enter "Selenium C#" into the search box
            searchBox.Submit(); // Submit the search form

            // Check the results and print the title
            if (driver.Title.Contains("Selenium C#"))
            {
                Console.WriteLine("Test passed: Page title is correct.");
            }
            else
            {
                Console.WriteLine("Test failed: Page title is not as expected.");
            }
        }
        catch (Exception e)
        {
            // Print the error message
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            // Close the browser
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
