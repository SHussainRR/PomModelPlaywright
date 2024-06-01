using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PomModelPlaywright.PageClasses
{
   public class ShipmentClass:CheckoutClass
    {

        public IPage _Page { get; set; }

        public ShipmentClass(IPage page) : base(page) {
            _Page=page;
        }





        //await Checkout.ClickAsync();
        //await Fname.FillAsync("usman");
        //await Lname.FillAsync("usman");
        //await Zcode.FillAsync("75300");
        //await ContinueCheck.ClickAsync();
        //await Finish.ClickAsync();
        //var text = await Checktext.InnerTextAsync();

        //Thread.Sleep(10000);
        //    Assert.That(CheckoutText, Is.EqualTo(text));
    }
}
