using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveUIDemo.Models
{
    public class Movie : IEquatable<Movie>
    {
        public string ThumbnailUrl { get; set; }
        public string FullImage { get; set; }
        public string Review { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<string> Genres { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        public bool Equals(Movie movie)
        {
            if (ReferenceEquals(null, movie))
                return false;
            if (ReferenceEquals(this, movie))
                return true;
            var equals = Id == movie.Id
                && ThumbnailUrl == movie.ThumbnailUrl
                && FullImage == movie.FullImage
                && Review == movie.Review
                && ReleaseDate == movie.ReleaseDate
                && Title == movie.Title;
            return equals;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Movie)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 942074158;
            hashCode = (hashCode * -1611243274) + EqualityComparer<string>.Default.GetHashCode(ThumbnailUrl);
            hashCode = (hashCode * -1611243274) + EqualityComparer<string>.Default.GetHashCode(FullImage);
            hashCode = (hashCode * -1611243274) + EqualityComparer<string>.Default.GetHashCode(Review);
            hashCode = (hashCode * -1611243274) + ReleaseDate.GetHashCode();
            hashCode = (hashCode * -1611243274) + Id.GetHashCode();
            hashCode = (hashCode * -1611243274) + EqualityComparer<string>.Default.GetHashCode(Title);
            return hashCode;
        }

    }
}
