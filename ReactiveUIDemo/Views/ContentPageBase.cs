using ReactiveUI;
using ReactiveUI.XamForms;
using ReactiveUIDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ReactiveUIDemo.Views
{

    public class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel>
        where TViewModel : ViewModelBase
    {
        public ContentPageBase()
        {
            this.WhenActivated(disposable =>
            {
                ViewModel
                .ShowAlert
                .RegisterHandler(interaction =>
                {
                    AlertViewModel input = interaction.Input;
                    DisplayAlert(input.Title, input.Message, input.ButtonText);
                    interaction.SetOutput(Unit.Default);
                }
                ).DisposeWith(disposable);
                ViewModel
                .OpenBrowser
                .RegisterHandler(interaction =>
                {
                    Launcher.TryOpenAsync(new Uri(interaction.Input));
                    interaction.SetOutput(Unit.Default);
                });
            }

            );
        }
    }
}
