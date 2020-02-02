using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Text;

namespace ReactiveUIDemo.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        public AboutViewModel(IScheduler mainThreadScheduler = null,
                IScheduler taskPoolScheduler = null,
                IScreen hostScreen = null) : base("About", mainThreadScheduler, taskPoolScheduler, hostScreen)
        {
            ShowIconCredits = ReactiveCommand.CreateFromObservable<string, Unit>(url => OpenBrowser.Handle(url));
            ShowIconCredits.Subscribe();
        }
        public ReactiveCommand<string, Unit> ShowIconCredits
        {
            get;
        }
    }
}
