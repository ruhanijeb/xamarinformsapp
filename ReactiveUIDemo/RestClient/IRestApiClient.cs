using ReactiveUIDemo.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;


namespace ReactiveUIDemo.RestClient
{
    [Headers("Content-type:application/json")]
    public interface IRestApiClient
    {
        [Get("/movie/upcomig/apikey={apikey}&language={language}&page={page}&sort_by=release_date")]
        IObservable<MovieDto> FetchUpcomingMovies(string apiKey, int page, string language);
        [Get("/configuration?apikey={apikey}")]
        IObservable<ImageConfigurationDto> FetchImageConfiguration(string apiKey);

        [Get("/genre/movie/list?api_key={apiKey}&language={language}")]
        IObservable<GenresDto> FetchGenres(string apiKey, string language);
    }
}
