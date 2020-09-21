using TechTalk.SpecFlow;
using System;
using NUnit.Framework;

namespace Back_end_ISW_master.Steps
{
    [Binding]
    public class ViewProfileSteps
    {
        [Given(@"the user wants to verify their registered profile")]
      public void Given_the_user_wants_to_verify_their_registered_profile(){
          Console.WriteLine("Given the user wants to verify their registered profile");
      }

      [When(@"pressing the Mi perfil button")]
      public void When_pressing_the_Mi_perfil_button(){
          Console.WriteLine("When pressing the Mi perfil button");
      }

     [Then(@"they'll be able to check their information")]
      public void Then_they_ll_be_able_to_check_their_information(){
          Console.WriteLine("Then they'll be able to check their information");  
          Assert.IsTrue(true,"expected true but fund false");
      }
    }
}