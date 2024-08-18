using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata.Services;

public class StatementPrinter
{
    private readonly IFormatter _formatter;
    private readonly CalculatorFactory _calculatorFactory = new CalculatorFactory();
    public StatementPrinter(IFormatter formatter, CalculatorFactory calculatorFactory)
    {
        _formatter = formatter;
        _calculatorFactory = calculatorFactory;
    }
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var statementData = new StatementData
        {
            Customer = invoice.Customer
        };
        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            var calculator = _calculatorFactory.CreateCalculator(play);
            var thisAmount = calculator.CalculateAmount(perf,play);
            var thisCredits = calculator.CalculateVolumeCredits(perf,play);

            statementData.Performances.Add(new PerformanceSummary{
                PlayName = play.Name,
                Amount = thisAmount,
                Audience = perf.Audience,
                EarnedCredits = thisCredits
            });

            statementData.TotalAmount += thisAmount;
            statementData.VolumeCredits += thisCredits; 
        }
        
        return _formatter.Format(statementData);
    }

    public string PrintXml(Invoice invoice, Dictionary<string, Play> plays)
    {
        var statementData = new StatementData
        {
            Customer = invoice.Customer
        };

        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            var calculator = _calculatorFactory.CreateCalculator(play);
            var thisAmount = calculator.CalculateAmount(perf, play);
            var thisCredits = calculator.CalculateVolumeCredits(perf, play);

            statementData.Performances.Add(new PerformanceSummary
            {
                PlayName = play.Name,
                Amount = thisAmount,
                Audience = perf.Audience,
                EarnedCredits = thisCredits
            });

            statementData.TotalAmount += thisAmount;
            statementData.VolumeCredits += thisCredits;
        }

            return _formatter.Format(statementData);
        }
}
