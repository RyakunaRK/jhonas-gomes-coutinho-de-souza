using System;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata.Services;

public class HistoryCalculator : ICalculator
{
    public decimal CalculateAmount(Performance performance, Play play)
    {
        var tragedyCalculator = new TragedyCalculator();
        var comedyCalculator = new ComedyCalculator();

        var tragedyAmount = tragedyCalculator.CalculateAmount(performance, play);
        var comedyAmount = comedyCalculator.CalculateAmount(performance, play);

        return tragedyAmount + comedyAmount;
    }

    public int CalculateVolumeCredits(Performance performance, Play play)
    {
        return Math.Max(performance.Audience - 30, 0);
    }
}