ReadMe file for AzureAPITestCaseUpdate Project

This project allows for individual test cases to be updated in Azure DevOps

Requirements to get the testcases updated.

Implementation in the runsettings file 
******************************
    <Parameter name="BrowserType" value="Chrome" />
    <Parameter name="PAT" value="j7c5wxdbimp7ufoz5crmrtsxygaamlv7vbvkgbexwjyfokkurcfa"/>
    <Parameter name="ServerUrl" value="https://rymanhealthcare.visualstudio.com/"/>
    <Parameter name="ProjectName" value="MyRyman%20Development"/>
    <Parameter name="TestRunName" value="Selenium Automation Test Run"/>
    <Parameter name="ApiCallVersion" value="?api-version=6.0"/>
******************************
******************************
Implementation in the Test Base File 

        public static string PAT { get; set; }
        public static string ServerUrl { get; set; }
        public static string ProjectName { get; set; }
        public static string ApiCallVersion { get; set; }
        public static string TestRunName { get; set; }
        public static string ApiEndPoint { get; set; }
		
		
	Assebly Initialize
	
	        PAT = TestContextLoader.GetProperty("PAT", "SamplePAT$%^&*()");
            ServerUrl = TestContextLoader.GetProperty("ServerUrl", "Https://SampleURL.com");
            ProjectName = TestContextLoader.GetProperty("ProjectName", "Sample Poject Name");
            ApiCallVersion = TestContextLoader.GetProperty("ApiCallVersion", "?api-version=6.0");
            TestRunName = TestContextLoader.GetProperty("TestRunName", "SampleTestName_99999");
			
*******************************
*******************************
Test Case implementation

        [TestMethod]
        public void PassTest()
        {
            AzureUpdateTestCase.PostTestResults(
             PAT,
             ServerUrl,
             ProjectName,
             "myRyman - Master",
            "101659 - Progress notes race condition",
            101743,
            "Jun Fernandez",
            "Passed", ApiCallVersion);
        }
        [TestMethod]
        public void FailTest()
        {
            AzureUpdateTestCase.PostTestResults(
             PAT,
             ServerUrl,
             ProjectName,
             "myRyman - Master",
            "101659 - Progress notes race condition",
             101743,
            "Jun Fernandez",
            "Failed", ApiCallVersion);
        }
		
*********************************