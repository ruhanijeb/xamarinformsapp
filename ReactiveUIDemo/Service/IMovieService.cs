using DynamicData;
using ReactiveUIDemo.Models;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

namespace ReactiveUIDemo.Service
{
    public interface IMovieService
    {
        /// <summary>
        /// Gets an observable which contains upcoming movies.
        /// </summary>
        IObservableCache<Movie, int> UpcomingMovies { get; }

        /// <summary>
        /// Loads the upcoming movies.
        /// </summary>
        /// <param name="index">The paging index.</param>
        /// <returns>An observable which signals when the update is complete.</returns>
        IObservable<Unit> LoadUpcomingMovies(int index);
    }
}
