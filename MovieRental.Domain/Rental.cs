namespace MovieRental.Domain
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented) => (Movie, DaysRented) = (movie, daysRented);
        public int DaysRented { get; }
        public Movie Movie { get; }
    }
}
