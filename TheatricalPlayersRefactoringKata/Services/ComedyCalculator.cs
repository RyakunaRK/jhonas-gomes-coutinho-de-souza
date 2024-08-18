using System;
using TheatricalPlayersRefactoringKata.Domain; 
namespace TheatricalPlayersRefactoringKata.Services;

public class ComedyCalculator : ICalculator
{
    public decimal CalculateAmount(Performance performance, Play play)
    {
        decimal lines = play.Lines;
        if(play.Lines > 4000) lines = 4000;
        if(play.Lines < 1000) lines = 1000;

        decimal baseAmount = lines / 10;
        decimal result = baseAmount + (3 * performance.Audience);
        if (performance.Audience > 20)
        {
            result += 100 + 5 * (performance.Audience - 20);
        }
        return result;
    }

    public int CalculateVolumeCredits(Performance performance, Play play)
    {
        return Math.Max(performance.Audience - 30, 0) + (int)Math.Floor((decimal)performance.Audience / 5);
    }
}