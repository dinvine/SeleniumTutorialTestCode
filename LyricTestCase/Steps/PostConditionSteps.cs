using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace EStoreShoppingSys.Steps
{
    [Binding]
    public sealed class PostConditionSteps
    {


        PostConditionSteps(ScenarioContext scenarioContext)
        {



        }

        [AfterScenario()]
        public void ScenarioTearDown()
        {

        }
    }
}
