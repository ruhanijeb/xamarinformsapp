using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ReactiveUIDemo.Models
{
    public static class MovieMapper
    {
        private const string BaseUrl = "http://image.tmdb.org/t/p/";
        private const string ThumbnailSize = "w185";
        private const string FullImageSize = "w500";
        public static Movie ToModel(GenresDto genres, MovieResult movieDto, string language)
        {
            return new Movie
            {
                Id = movieDto.Id,
                Title = movieDto.Title,
                ThumbnailUrl = string.Concat(BaseUrl, ThumbnailSize, movieDto.PosterPath),
                FullImage = string.Concat(BaseUrl, FullImageSize, movieDto.PosterPath),
                Genres = genres.Genres.Where(g => movieDto.GenreIds.Contains(g.Id)).Select(j => j.Name).ToList(),
                ReleaseDate = DateTime.Parse(movieDto.ReleaseDate, new CultureInfo(language)),
                Review = movieDto.Review
            };
        }

    }
}
