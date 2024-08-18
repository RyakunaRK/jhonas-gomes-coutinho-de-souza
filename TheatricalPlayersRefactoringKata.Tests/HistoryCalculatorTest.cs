using Xunit;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Services;
namespace TheatricalPlayersRefactoringKata.Tests;

public class HistoryCalculatorTest{
    [Fact]
    public void CalculateAmount_TestHistoryCalculator(){

        var calculator = new HistoryCalculator();
        var historyPlay = new Play("As Bruxas de Salem",1000,"history");
        var performance = new Performance("as-bruxas-de-salem",50);

        var amount = calculator.CalculateAmount(performance,historyPlay);

        Assert.Equal(800m,amount);
    }

    [Fact]
    public void CalculateVolumeCredits_TestHistoryCalculator(){

        var calculator = new HistoryCalculator();
        var historyPlay = new Play("As Bruxas de Salem",1000,"history");
        var performance = new Performance("as-bruxas-de-salem",50);

        var credits = calculator.CalculateVolumeCredits(performance,historyPlay);

        Assert.Equal(20,credits);
    }
}