using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections;
using System;

namespace Selenium_Robot_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.PageLoadStrategy = PageLoadStrategy.Eager; // discards loading of stylesheets, images and subframes

            IWebDriver driver = new ChromeDriver(options);

            ArrayList lista = new ArrayList();
            lista.Add("https://store.steampowered.com/app/1172620/Sea_of_Thieves/");
            lista.Add("https://store.steampowered.com/app/892970/Valheim/");
            lista.Add("https://store.steampowered.com/app/264710/Subnautica/");
            lista.Add("https://store.steampowered.com/app/526870/Satisfactory/");

            foreach (string link in lista)
            {
                driver.Navigate().GoToUrl(link);

                IWebElement NameProduct = driver.FindElement(By.XPath("/html/body/div[1]/div[7]/div[4]/div[1]/div[3]/div[2]/div[2]/div/div[3]"));
                Console.WriteLine(NameProduct.Text);

                IWebElement Promotion = driver.FindElement(By.ClassName("game_area_purchase_game"));
                IWebElement PriceProduct;

                if (Promotion.Text.Contains("PROMO"))
                {
                    Console.WriteLine(Promotion.Text);
                    PriceProduct = driver.FindElement(By.ClassName("discount_final_price"));
                    Console.WriteLine(PriceProduct.Text);
                }
                else {
                    PriceProduct = driver.FindElement(By.ClassName("game_purchase_action_bg"));
                    Console.WriteLine(PriceProduct.Text);
                }
                
                
            }
        }
    }
}
