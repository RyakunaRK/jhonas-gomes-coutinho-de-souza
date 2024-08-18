using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Services;
using Xunit;
namespace TheatricalPlayersRefactoringKata.Tests;

public class CalculateFactoryTest{
    [Fact]
    public void TestCalculatorFactory()
    {
        var calculateFactory = new CalculatorFactory();
        var comedyPlay = new Play("Auto da Compadecida",1000,"comedy");
        var tragedyPlay = new Play("Romeu e Julieta",1000,"tragedy");
        var historyPlay = new Play("Pompeia",1000,"history");

        var comedyCalculator = calculateFactory.CreateCalculator(comedyPlay);
        var tragedyCalculator = calculateFactory.CreateCalculator(tragedyPlay);
        var historyCalculator = calculateFactory.CreateCalculator(historyPlay);

        Assert.IsType<ComedyCalculator>(comedyCalculator);
        Assert.IsType<TragedyCalculator>(tragedyCalculator);
        Assert.IsType<HistoryCalculator>(historyCalculator);

    }
}