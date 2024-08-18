using System;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata.Services
{
    public class CalculatorFactory
    {
        public ICalculator CreateCalculator(Play play)
        {
            switch (play.Type)
            {
                case "tragedy":
                    return new TragedyCalculator();
                case "comedy":
                    return new ComedyCalculator();
                case "history":
                    return new HistoryCalculator();
                default:
                    throw new Exception($"Unknown play type: {play.Type}");
            }
        }
    }
}