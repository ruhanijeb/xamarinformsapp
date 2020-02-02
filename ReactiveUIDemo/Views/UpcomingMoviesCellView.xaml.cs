using ReactiveUI;
using ReactiveUI.XamForms;
using ReactiveUIDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactiveUIDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesCellView : ReactiveViewCell<UpcomingMoviesCellViewModel>
    {

        private readonly CompositeDisposable _subscriptionDisposables = new CompositeDisposable();
        public UpcomingMoviesCellView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Title, x => x.Title.Text).DisposeWith(_subscriptionDisposables);
                this.OneWayBind(ViewModel, x => x.Genres, x => x.Genres.Text, x => x).DisposeWith(_subscriptionDisposables);
                this.OneWayBind(ViewModel, x => x.ReleaseDate, x => x.ReleaseDate.Text, x => x).DisposeWith(_subscriptionDisposables);
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _subscriptionDisposables.Clear();
        }

        /// <inheritdoc/>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            Poster.Source = null;

            if (!(BindingContext is UpcomingMoviesCellViewModel item))
            {
                return;
            }

            Poster.Source = item.PosterPath;
        }
    }
}