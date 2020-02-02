using ReactiveUI;
using ReactiveUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ReactiveUIDemo.ViewModels
{
    public class UpcomingMoviesCellViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpcomingMoviesCellViewModel"/> class.
        /// </summary>
        /// <param name="movie">The movie information.</param>
        /// <param name="hostScreen">The screen for routing operations.</param>
        public UpcomingMoviesCellViewModel(Movie movie, IScreen hostScreen = null)
            : base(movie.Title, hostScreen: hostScreen)
        {
            Movie = movie;
        }

        /// <summary>
        /// Gets the movie information.
        /// </summary>
        public Movie Movie { get; }

        /// <summary>
        /// Gets the title of the movie.
        /// </summary>
        public string Title => Movie.Title;

        /// <summary>
        /// Gets the path to the poster.
        /// </summary>
        public string PosterPath => Movie.ThumbnailUrl;

        /// <summary>
        /// Gets the genres for the movie.
        /// </summary>
        public string Genres => string.Join(", ", Movie.Genres);

        /// <summary>
        /// Gets the release date of the movie.
        /// </summary>
        public string ReleaseDate => Movie.ReleaseDate.ToString("D", CultureInfo.CurrentCulture);
    }
}
