using ReactiveUI;
using ReactiveUIDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveUIDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesListView : ContentPageBase<UpcomingMoviesListViewModel>
    {
        public UpcomingMoviesListView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                ViewModel.SelectedItem = null;

                this.OneWayBind(ViewModel, x => x.Movies, x => x.UpcomingMoviesList.ItemsSource).DisposeWith(disposables);
                this.Bind(ViewModel, x => x.SelectedItem, x => x.UpcomingMoviesList.SelectedItem).DisposeWith(disposables);
                this.OneWayBind(ViewModel, vm => vm.OpenAboutView, view => view.About.Command).DisposeWith(disposables);

                UpcomingMoviesList
                    .Events()
                    .ItemAppearing
                    .Select((e) => e.Item as UpcomingMoviesCellViewModel)
                    .BindTo(this, x => x.ViewModel.ItemAppearing)
                    .DisposeWith(disposables);
            });

            this.WhenAnyValue(x => x.ViewModel)
                .Where(vm => vm != null)
                .SubscribeOn(RxApp.TaskpoolScheduler)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Select(_ => 0)
                .InvokeCommand(this, x => x.ViewModel.LoadMovies);
        }
    }
}