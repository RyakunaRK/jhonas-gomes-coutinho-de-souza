using System;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata.Services;

public class TragedyCalculator : ICalculator
{
    public decimal CalculateAmount(Performance performance, Play play)
    {
        decimal lines = play.Lines;
        if(play.Lines > 4000) lines = 4000;
        if(play.Lines < 1000) lines = 1000;

        decimal baseAmount = lines / 10;
        if (performance.Audience > 30)
        {
            return baseAmount + 10 * (performance.Audience - 30);
        }
        return baseAmount;
    }

    public int CalculateVolumeCredits(Performance performance, Play play)
    {
        return Math.Max(performance.Audience - 30, 0);
    }
}
