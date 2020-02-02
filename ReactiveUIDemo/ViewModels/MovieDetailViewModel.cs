using ReactiveUI;
using ReactiveUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reactive.Concurrency;
using System.Text;

namespace ReactiveUIDemo.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase
    {
        private readonly Movie _movie;
        public string Title => _movie.Title;
        public string Thumbnail => _movie.ThumbnailUrl;
        public string FullImage => _movie.FullImage;
        public string Genres => string.Join(",", _movie.Genres);
        public string ReleaseDate => _movie.ReleaseDate.ToString("D", CultureInfo.CurrentCulture);
        public string Review => _movie.Review;
        public MovieDetailViewModel(Movie movie, IScheduler mainThreadScheduler = null, IScheduler taskPoolScheduler = null, IScreen hostScreen = null)
            : base(movie.Title, mainThreadScheduler, taskPoolScheduler, hostScreen)
        {
            _movie = movie;
        }

    }
}
