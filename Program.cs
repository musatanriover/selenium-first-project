using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = null!; // Null başlangıcı uyarıyı temizler

        try
        {
            // Chrome tarayıcısını başlat
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // Google'a git
            driver.Navigate().GoToUrl("https://www.google.com");

            // Arama kutusunu bul ve arama yap
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium C#");
            searchBox.Submit();

            // Sonuçları kontrol et ve başlığı yazdır
            if (driver.Title.Contains("Selenium C#"))
            {
                Console.WriteLine("Test başarılı: Sayfa başlığı doğru.");
            }
            else
            {
                Console.WriteLine("Test başarısız: Sayfa başlığı beklenmiyor.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Hata: " + e.Message);
        }
        finally
        {
            // Tarayıcıyı kapat
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
