using Xunit;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Services;
namespace TheatricalPlayersRefactoringKata.Tests;

public class ComedyCalculatorTest{
    [Fact]
    public void CalculateAmount_TestComedyCalculator(){

        var calculator = new ComedyCalculator();
        var comedyPlay = new Play("O Auto da Compadecida",1000,"tragedy");
        var performance = new Performance("o-auto-da-compadecida",50);

        var amount = calculator.CalculateAmount(performance,comedyPlay);

        Assert.Equal(500m,amount);
    }

    [Fact]
    public void CalculateVolumeCredits_TestComedyCalculator(){

        var calculator = new ComedyCalculator();
        var comedyPlay = new Play("O Auto da Compadecida",1000,"tragedy");
        var performance = new Performance("o-auto-da-compadecida",50);

        var credits = calculator.CalculateVolumeCredits(performance,comedyPlay);

        Assert.Equal(30,credits);
    }
}