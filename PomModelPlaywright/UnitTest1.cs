using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PomModelPlaywright.PageClasses;

namespace PomModelPlaywright
{
    public class Tests
    {

        IPlaywright playwright;
        IPage page;
        LoginClass logincLass = null;
        CheckoutClass CheckoutAsync = null;
        public JObject jsonLocatorData = JObject.Parse(File.ReadAllText("E:\\Working Repositories\\SQA\\PomModelPlaywright\\PomModelPlaywright\\Json\\data.json"));

        [Test]
        public async Task Test1()
        {




            playwright = await Playwright.CreateAsync();
            { 
            
            
                var browse= await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { 
                
                    Headless = false,
                
                });
                page= await browse.NewPageAsync();
                logincLass = new LoginClass(page);
                await logincLass.gotoURL(jsonLocatorData["url"].ToString());
                await logincLass.LoginSucessesful(jsonLocatorData["username"].ToString(), jsonLocatorData["password"].ToString());
                
            }
            Assert.Pass();

        }
        [Test]
        public async Task Test2()
        {
            playwright = await Playwright.CreateAsync();
            {


                var browse = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {

                    Headless = false,

                });
                page = await browse.NewPageAsync();
               
                CheckoutAsync = new CheckoutClass(page);
                await CheckoutAsync.gotoURL(jsonLocatorData["url"].ToString());
                await CheckoutAsync.CheckoutFunction();
                //await logincLass.("standard_user", "secret_sauce");

            }
            Assert.Pass();
        }
    }
}