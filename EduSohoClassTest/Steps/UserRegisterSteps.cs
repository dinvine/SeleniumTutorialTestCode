
using EduSohoClassTest.Pages;
using TechTalk.SpecFlow;

namespace EduSohoClassTest.Steps
{
    [Binding]
    public class UserRegisterSteps: BasePageSteps
    {
        EduSohoRegisterPage registerPage;
        public UserRegisterSteps(ScenarioContext scenarioContext):base(scenarioContext)
        {
            registerPage = new EduSohoRegisterPage(context);
        }

        [Then(@"inputValue to the fieldName as table and should get msg below the field")]
        public void ThenInputValueToTheFieldNameAsBelowAndShouldGetMsg(Table table)
        {
            string inputString = "";
            string expectMsg = "";
            string fieldName = "";
            foreach (var row in table.Rows)
            {
                 inputString = row["inputValue"].ToString();
                 expectMsg = row["msg"].ToString();
                fieldName= row["fieldName"].ToString();

                switch (fieldName)
                {
                    case "email":
                        registerPage.EmailEnter(inputString);
                        registerPage.LoginErrMsgDisplayed(expectMsg, fieldName);
                        break;
                    case "username":
                        registerPage.UsernameEnter(inputString);
                        registerPage.LoginErrMsgDisplayed(expectMsg, fieldName);
                        break;
                    case "password":
                        registerPage.PasswordEnter(inputString);
                        registerPage.LoginErrMsgDisplayed(expectMsg, fieldName);
                        break;
                    case "captchaCode":
                        registerPage.CaptchaCodeEnter(inputString);
                        registerPage.LoginErrMsgDisplayed(expectMsg, fieldName);
                        break;
                    case "userterm":
                        registerPage.UserTermsSelect(inputString);
                        registerPage.RegisterBtnClick();
                        registerPage.LoginErrMsgDisplayed(expectMsg, fieldName);
                        break;
                }
            }
        }


        /// <summary>
        /// enter "inputStr" string to "fieldName" inputfield
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="fieldName"></param>
        [When(@"enter ""(.*)""inputValue to the ""(.*)"" fieldName to the form and press Enter key")]
        public void WhenEnterInputValueToTheFieldNameToTheFormAndPressEnterKey(string inputStr, string fieldName)
        {
            switch (fieldName)
            {
                case "email":
                    registerPage.EmailEnter(inputStr);
                    break;
                case "username":
                    registerPage.UsernameEnter(inputStr);
                    break;
                case "password":
                    registerPage.PasswordEnter(inputStr);
                    break;
                case "captchaCode":
                    registerPage.CaptchaCodeEnter(inputStr);
                    break;
                case "userterm":
                    registerPage.UserTermsSelect(inputStr);
                    break;
            }
             
        }

        ///// <summary>
        ///// press Enter key in the email input
        ///// in order to activate the error message label to display.
        ///// </summary>
        //[When(@"press Enter key in the email input")]
        //public void WhenPressEnterKeyInTheEmailInput()
        //{
        //    registerPage.EmailEnter(Keys.Enter);
        //    //registerPage.clickBlankArea();
        //}

        /// <summary>
        /// Assert that msg shown below  the field 
        /// </summary>
        /// <param name="expectMsg"></param>
        /// <param name="fieldName"></param>
        [Then(@"there should be ""(.*)""msg shown below  ""(.*)"" fieldName")]
        public void ThenThereShouldBeMsgShownBelowFieldName(string expectMsg, string fieldName)
        {
            registerPage.LoginErrMsgDisplayed(expectMsg, fieldName);
        }



        //[When(@"enter the ""(.*)""email,""(.*)""usrname,""(.*)""password,""(.*)""captchaCode,(.*) userterm  to the form")]
        //public void WhenEnterTheEmailUsrnamePasswordCaptchaCodeUsertermToTheForm(string p0, string p1, string p2, string p3, string p4)
        //{
        //    registerPage.EmailEnter(p0);
        //    registerPage.UsernameEnter(p1);
        //    registerPage.PasswordEnter(p2);
        //    registerPage.CaptchaCodeEnter(p3);
        //    registerPage.UserTermsSelect(p4);
        //}

        
        [When(@"click register button")]
        public void WhenClickRegisterButton()
        {
            registerPage.RegisterBtnClick();
        }
        
        [Then(@"there should be ""(.*)""msg shown in the ""(.*)"" msgLabel")]
        public void ThenThereShouldBeMsgShownInTheMsgLabel(string expectMsg, string labelName)
        {
            registerPage.LoginErrMsgDisplayed(expectMsg, labelName);
        }
    }
}
