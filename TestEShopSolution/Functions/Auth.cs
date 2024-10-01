using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace TestEShopSolution.Functions
{
    public class Auth
    {
        private IWebDriver driver;

        public Auth(IWebDriver webDriver = null)
        {
            driver = webDriver ?? new ChromeDriver();
        }

        // Hàm đăng nhập
        public void PerformLogin(string username, string password)
        {
            // Mở website cần kiểm thử
            driver.Navigate().GoToUrl("https://localhost:5003/vi-VN/account/login");
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);

            // Nhấp vào nút đăng nhập
            driver.FindElement(By.ClassName("register-button")).Click();
            if (string.IsNullOrEmpty(username))
            {
                var spanElement = driver.FindElement(By.CssSelector("#input-username>span"));
                string text = spanElement.Text;
                Console.WriteLine(text);
                return;
            } else if (string.IsNullOrEmpty(password))
            {
                var spanElement = driver.FindElement(By.CssSelector("#input-password>span"));
                string text = spanElement.Text;
                Console.WriteLine(text);
                return;
            } else
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.UrlToBe("https://localhost:5003/"));

                    // Kiểm tra cookie chứa token
                    var authTokenCookie = driver.Manage().Cookies.GetCookieNamed("Token");

                    // Kiểm tra xem cookie có tồn tại và không rỗng
                    if (authTokenCookie != null && !string.IsNullOrEmpty(authTokenCookie.Value))
                    {
                        // Nếu cả URL và cookie đều hợp lệ
                        Console.WriteLine("Hợp lệ");
                    }
                    else
                    {
                        Console.WriteLine("Không hợp lệ");
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("Không hợp lệ");
                }
            }
        }

        public void Clean()
        {
            // Đóng trình duyệt sau khi test hoàn thành
            if (driver != null)
            {
                driver.Quit(); // Giải phóng tài nguyên
                driver.Dispose(); // Gọi Dispose để đảm bảo tất cả tài nguyên được giải phóng
                driver = null; // Đặt driver về null để tránh lỗi
            }
        }
    }
}
