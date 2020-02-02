using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUIDemo.Models;
using Splat;

namespace ReactiveUIDemo.Service
{
    public class MovieService : IMovieService, IDisposable
    {
        private const string ApiKey = "1f54bd990f1cdfb230adb312546d765d";
        private readonly IApiService _movieApiService;
        private readonly ICache _movieCache;
        private readonly SourceCache<Movie, int> _internalSourceCache;

        public MovieService(IApiService apiService = null, ICache cache = null)
        {
            _movieApiService = apiService ?? Locator.Current.GetService<IApiService>();
            _movieCache = cache ?? Locator.Current.GetService<ICache>();
            _internalSourceCache = new SourceCache<Movie, int>(o => o.Id);
        }
        public int PageSize { get; } = 20;
        protected string Language { get; } = "en-US";
        IObservableCache<Movie, int> IMovieService.UpcomingMovies => _internalSourceCache;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _internalSourceCache?.Dispose();
        }
        public IObservable<Unit> LoadUpcomingMovies(int index)
        {
            return _movieCache
                .GetAndFetchLatest($"upcoming_movies_{index}", () => FetchUpcomingMovies(index))
                .Select(x =>
                {
                    _internalSourceCache.Edit(innerCache => innerCache.AddOrUpdate(x));
                    return Unit.Default;
                });
        }
        private IObservable<IEnumerable<Movie>> FetchUpcomingMovies(int index)
        {
            int page = (int)Math.Ceiling(index / (double)PageSize) + 1;
            return _movieApiService
                .UserInitiated
                .FetchUpcomingMovies(ApiKey, page, Language)
              .CombineLatest(
                _movieApiService.UserInitiated.FetchGenres(ApiKey, Language),
                (movies, genres) =>
                {
                    return movies
                    .Results
                    .Select(movieDto => MovieMapper.ToModel(genres, movieDto, Language));
                });
        }
    }
}
