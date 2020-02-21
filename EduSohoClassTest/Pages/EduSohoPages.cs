using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSohoClassTest.Common;


namespace EduSohoClassTest.Pages
{
   public class EduSohoPages
    {
        public Browser browser;
        public EduSohoHomePage homepage;
        public EduSohoLoginPage loginPage;
        public EduSohoListPage listPage; 

        public EduSohoPages(BrowserType browserType= BrowserType.Firefox, string URL= "http://lyratesting2.co.nz/")
        {
            browser = new Browser(URL,browserType);
            //homepage = new EduSohoHomePage(browser.GetDriver());
            //loginPage = new EduSohoLoginPage(browser.GetDriver());
            //listPage = new EduSohoListPage(browser.GetDriver());
        }

        public EduSohoPages(Browser br)
        {
            browser = br;
            //homepage = new EduSohoHomePage(br.GetDriver());
            //loginPage = new EduSohoLoginPage(br.GetDriver());
            //listPage = new EduSohoListPage(br.GetDriver());
        }

        public void GotoHomePage()
        {
            browser.GoToURL("http://lyratesting2.co.nz/");
        }
    }
}
