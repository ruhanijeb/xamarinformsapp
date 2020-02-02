using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveUIDemo.ViewModels
{
    public class AlertViewModel
    {
        public String Title { get; set; }
        public string Message{get;set;}
        public string ButtonText { get; set; }
        public AlertViewModel(string title,string message,string buttonText)
        {
            Title = title;
            Message = message;
            ButtonText = buttonText;
        }
    }
}
