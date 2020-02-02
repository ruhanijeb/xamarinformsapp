using ReactiveUI;
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
    public partial class MovieDetailView : ContentPageBase<MovieDetailViewModel>
    {
        public MovieDetailView()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.FullImage, x => x.Poster.Source, x => x).DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.Thumbnail, x => x.Poster.LoadingPlaceholder, x => x).DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.Genres, x => x.Genres.Text, x => x).DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.ReleaseDate, x => x.ReleaseDate.Text, x => x).DisposeWith(disposables);
                this.OneWayBind(ViewModel, x => x.Review, x => x.Overview.Text, x => x).DisposeWith(disposables);
            });
        }
    }
}