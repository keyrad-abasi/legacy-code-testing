using FluentAssertions;
using MovieRental.Domain;

namespace Test.Domain
{
    public class RentMovieTest
    {
        [Fact]
        public void Statement_WithNoRentals_GeneratesReportWithJustHeaderAndFooetrAndNoBody()
        {
            var aCustomer = new Customer("Mahdi");

            var theStatement = aCustomer.Statement();

            theStatement
                .Should()
                .Be("Rental Statement for Mahdi\nAmount owed is $0\nYou earned 0 FRP");
        }

        [Fact]
        public void Statement_WithSingleRegualr_GenerateCompleteReportWithOneDetailLine()
        {
            var aCustomer = new Customer("Mahdi");
            var theMatrix = new Movie("The Matrix", MoviePriceCode.Regular);
            aCustomer.AddRental(new Rental(theMatrix, 7));

            var theStatement = aCustomer.Statement();

            theStatement
                .Should()
                .Be("Rental Statement for Mahdi\n\tThe Matrix\t$9.5\nAmount owed is $9.5\nYou earned 1 FRP");
        }

        [Fact]
        public void Statement_WithSingleNewRelease_GenerateCompleteReportWithOneDetailLine()
        {
            var aCustomer = new Customer("Mahdi");
            var theLordOfTheRings = new Movie("The Lord of the Rings", MoviePriceCode.NewRelease);
            aCustomer.AddRental(new Rental(theLordOfTheRings, 7));

            var theStatement = aCustomer.Statement();

            theStatement
                .Should()
                .Be("Rental Statement for Mahdi\n\tThe Lord of the Rings\t$21\nAmount owed is $21\nYou earned 2 FRP");
        }

        [Fact]
        public void Statement_WithSingleChildrens_GenerateCompleteReportWithOneDetailLine()
        {
            var aCustomer = new Customer("Mahdi");
            var wishDragon = new Movie("Wish Dragon", MoviePriceCode.Childrens);
            aCustomer.AddRental(new Rental(wishDragon, 7));

            var theStatement = aCustomer.Statement();

            theStatement
                .Should()
                .Be("Rental Statement for Mahdi\n\tWish Dragon\t$7.5\nAmount owed is $7.5\nYou earned 1 FRP");
        }
    }
}
