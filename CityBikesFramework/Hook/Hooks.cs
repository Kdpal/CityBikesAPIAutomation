using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CityBikesFramework.Hook
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //TODO: implement logic that has to run before/after the entire test run
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //TODO: implement logic that has to run before/after executing each feature
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        //[BeforeStep]
        //public void BeforeStep()
        //{
        //    System.Console.WriteLine("BeforeStep- Start Timer");
        //}

        //[AfterStep]
        //public static void AfterStep()
        //{
        //    System.Console.WriteLine("BeforeStep- Log something in DB.");
        //}

        [AfterScenario]
        public static void AfterTestRun()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
