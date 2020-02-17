using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTutorialTestCode.PageOBJ
{
   public class LyraTesting2Pages
    {
        public Browser browser;
        public LyraTesting2HomePage homepage;
        public LyricTesting2LoginPage loginPage;
        public LyraTesting2ListPage listPage; 

        public LyraTesting2Pages(BrowserType browserType= BrowserType.Firefox, string URL= "http://lyratesting2.co.nz/")
        {
            browser = new Browser(browserType, URL);
            homepage = new LyraTesting2HomePage(browser.GetDriver());
            loginPage = new LyricTesting2LoginPage(browser.GetDriver());
            listPage = new LyraTesting2ListPage(browser.GetDriver());
        }
    }
}
