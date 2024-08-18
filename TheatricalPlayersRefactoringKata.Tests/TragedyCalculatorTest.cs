using Xunit;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Services;
namespace TheatricalPlayersRefactoringKata.Tests;

public class TragedyCalculatorTest{
    [Fact]
    public void CalculateAmount_TestTragedyCalculator(){

        var calculator = new TragedyCalculator();
        var tragedyPlay = new Play("Romeu e Julieta",1000,"tragedy");
        var performance = new Performance("romeu-e-julieta",50);

        var amount = calculator.CalculateAmount(performance,tragedyPlay);

        Assert.Equal(300m,amount);
    }

    [Fact]
    public void CalculateVolumeCredits_TestTragedyCalculator(){

        var calculator = new TragedyCalculator();
        var tragedyPlay = new Play("Romeu e Julieta",1000,"tragedy");
        var performance = new Performance("romeu-e-julieta",50);

        var credits = calculator.CalculateVolumeCredits(performance,tragedyPlay);

        Assert.Equal(20,credits);
    }
}