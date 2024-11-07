using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Internal;
using SpecFlowProject.Hooks;
using Utilities;

namespace FrameworkPractice.Hooks
{
    [Binding]
    public sealed class ExtentReportsAndLoggersHooks
    {
        private static ExtentTest _featureName;
        private static ExtentTest _scenario;
        private static ExtentReports extent;
        private readonly Loggerss log = new Loggerss("Logger.xml");

        public ExtentReportsAndLoggersHooks()
        {
            log.GetLogger<SauceDemoHooks>();
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var htmlReporter = new ExtentSparkReporter(@"C:\Users\sasidhar_nemmani\Desktop\Daily Practice - Copy (2)\GcSpecflow\SpecFlowProject - API - Copy\SpecFlowProject\Report\Report.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            _featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext _scenarioContext)
        {
            _scenario = _featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            log.LogInfo($"Starting Scenario: {_scenarioContext.ScenarioInfo.Title}");
        }
        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //PropertyInfo propertyInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo methodInfo = propertyInfo.GetGetMethod(nonPublic: true);
            //object TestResult = methodInfo.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            }
            //_scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
            //if(TestResult.ToString()== "StepDefinitionPending")
            //{
            //    if (stepType == "Given")
            //        _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //    else if (stepType == "When")
            //        _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //    else if (stepType == "Then")
            //        _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //}
        }
    }
}