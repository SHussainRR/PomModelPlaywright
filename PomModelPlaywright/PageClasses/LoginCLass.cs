using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PomModelPlaywright.PageClasses
{
    public class LoginClass
    {
        public IPage _page;
        public ILocator UserName;
        public ILocator Password;
        public ILocator LoginButton;
        public ILocator ProductText;
        string expectedText = "Products";
        string actualText = string.Empty;


        



        public LoginClass (IPage page)
        {
            _page = page;
            UserName = page.Locator("#user-name");
            Password= page.Locator("#password");
            LoginButton = page.Locator("#login-button");
            ProductText = page.Locator("//span[contains(text(),'Products')]");


           


        }

        public async Task gotoURL(string home)
        {
            await _page.GotoAsync(home);
        }

        public async Task LoginSucessesful(string user, string passcode)
        {
            await UserName.FillAsync(user);
            await Password.FillAsync(passcode);
            await LoginButton.ClickAsync();
            actualText = await ProductText.InnerTextAsync();
            Assert.That(expectedText, Is.EqualTo(actualText));


        }


    }
}