using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;

namespace PomModelPlaywright.PageClasses
{
    public class CheckoutClass:LoginClass
    {
        public IPage _page;
        public ILocator AddCart;
        public ILocator Checkout;
        public ILocator Fname;
        public ILocator Lname;
        public ILocator Zcode;
        public ILocator ContinueCheck;
        public ILocator Cart;
        public ILocator Checktext;

        public string CheckoutText = "Thank you for your order!";
        public ILocator Finish;
        public JObject jsonLocatorData = JObject.Parse(File.ReadAllText("E:\\Working Repositories\\SQA\\PomModelPlaywright\\PomModelPlaywright\\Json\\data.json"));

        public CheckoutClass(IPage page) :base(page) {

            _page = page;
            AddCart = page.Locator("//button[@id='add-to-cart-sauce-labs-backpack']");
            Checkout = page.Locator("//button[@id='checkout']");
            Fname = page.Locator("//input[@id='first-name']");
            Lname = page.Locator("//input[@id='last-name']");
            Zcode = page.Locator("//input[@id='postal-code']");
            ContinueCheck = page.Locator("//input[@id='continue']");
            Cart = page.Locator("//body/div[@id='root']/div[@id='page_wrapper']/div[@id='contents_wrapper']/div[@id='header_container']/div[1]/div[3]/a[1]");
            Finish = page.Locator("//button[@id='finish']");
            Checktext = page.Locator("//h2[contains(text(),'Thank you for your order!')]");

        }
        public async Task CheckoutFunction() {

            await gotoURL(jsonLocatorData["url"].ToString());
            await LoginSucessesful("standard_user", "secret_sauce");
            await AddCart.ClickAsync();
            await Cart.ClickAsync();
            await Checkout.ClickAsync();
            await Fname.FillAsync("usman");
            await Lname.FillAsync("usman");
            await Zcode.FillAsync("75300");
            await ContinueCheck.ClickAsync();
            await Finish.ClickAsync();
            var text= await Checktext.InnerTextAsync();

            Thread.Sleep(10000);
            Assert.That(CheckoutText, Is.EqualTo(text));



        }
    }
}
