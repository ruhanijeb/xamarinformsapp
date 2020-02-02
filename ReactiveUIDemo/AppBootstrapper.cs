using DynamicData;
using ReactiveUI;
using ReactiveUI.XamForms;
using ReactiveUIDemo.Service;
using ReactiveUIDemo.ViewModels;
using ReactiveUIDemo.Views;
using Splat;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReactiveUIDemo
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.Register(() => new UpcomingMoviesListView(), typeof(IViewFor<UpcomingMoviesListViewModel>));
            Locator.CurrentMutable.Register(() => new UpcomingMoviesCellView(), typeof(IViewFor<UpcomingMoviesCellViewModel>));
            Locator.CurrentMutable.Register(() => new MovieDetailView(), typeof(IViewFor<MovieDetailViewModel>));
            Locator.CurrentMutable.Register(() => new AboutView(), typeof(IViewFor<AboutViewModel>));

            Locator.CurrentMutable.Register(() => new Cache(), typeof(ICache));
            Locator.CurrentMutable.Register(() => new ApiService(), typeof(IApiService));
            Locator.CurrentMutable.Register(() => new MovieService(), typeof(IMovieService));

            Router
                .NavigateAndReset
                .Execute(new UpcomingMoviesListViewModel())
                .Subscribe();
        }
        public RoutingState Router { get; protected set; }
        public static Page CreateMainPage()
        {
            return new RoutedViewHost();
        }
    }
}
