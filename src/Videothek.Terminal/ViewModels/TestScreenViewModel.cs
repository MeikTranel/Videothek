using System;
using Stylet;

namespace Videothek.Terminal.ViewModels
{
    public class TestScreenViewModel : Screen
    {
        public string Test { get; private set; }


        public TestScreenViewModel(string test)
        {
            Test = test;
        }
    }
}
