namespace MovieRental.Domain
{
    public class Customer
    {
        private List<Rental> Rentals { get; }
        public string Name { get; }

        public Customer(string name) => (Name, Rentals) = (name, new());
        public void AddRental(Rental aRental) => Rentals.Add(aRental);
        public string Statement()
        {
            var totalAmount = 0D;
            var frequentRenterPoints = 0;
            var result = $"Rental Statement for {Name}\n";

            foreach (var each in Rentals)
            {
                var thisAmount = 0D;

                //determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case MoviePriceCode.Regular:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case MoviePriceCode.NewRelease:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case MoviePriceCode.Childrens:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;

                }

                // add frequent renter points
                frequentRenterPoints++;

                // add bonus for a two day new release rental
                if ((each.Movie.PriceCode == MoviePriceCode.NewRelease) && each.DaysRented > 1)
                {
                    frequentRenterPoints++;
                }

                //show figures for this rental
                result += $"\t{each.Movie.Title}\t${thisAmount}\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += $"Amount owed is ${totalAmount}\n";
            result += $"You earned {frequentRenterPoints} FRP";
            return result;
        }
    }
}
