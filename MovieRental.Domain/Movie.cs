namespace MovieRental.Domain
{
    public class Movie
    {
        public Movie(string title, MoviePriceCode priceCode) => (Title, PriceCode) = (title, priceCode);
        public MoviePriceCode PriceCode { get; set; }
        public string Title { get; }
    }
}
