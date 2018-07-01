using AutomationTrial.Helper;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using log4net.Config;

namespace AutomationTrial.StepDefinition
{

    [Binding]
    public class RestApiValidationSteps
    {
        RestHelper Rest = new RestHelper();
        private int ExpectedObjectCount = 100;
        

        [Given(@"I have  access the Rest Api endpoint https://jsonplaceholder\.typicode\.com/Posts")]
        public void GivenIHaveAccessTheRestApiEndpointHttpsJsonplaceholder_Typicode_ComPosts()
        {

            Rest.SetEndpoint();
        }
        
        [Given(@"retreive the content")]
        public void GivenRetreiveTheContent()
        {
            Rest.RetrieiveTheData();
        }
        
        [Then(@"it should return the http reponse code OK")]
        public void ThenItShouldReturnTheHttpReponseCodeOK()
        {
            Assert.AreEqual("OK",Convert.ToString( Rest.GetTheResponse()));
        }
        
        [Then(@"the total retreived objects count should match to (.*)")]
        public void ThenTheTotalRetreivedObjectsCountShouldMatchTo(int p0)
        {
            
            Assert.AreEqual(ExpectedObjectCount, Rest.ObjCount());
        }
    }
}
