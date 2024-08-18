using System;
using System.Text;
namespace TheatricalPlayersRefactoringKata.Services;

public class TextFormatter : IFormatter
{
    public string Format(StatementData statementData)
    {
        var cultureInfo = new System.Globalization.CultureInfo("en-US");
        var result = new StringBuilder($"Statement for {statementData.Customer}\n");

        foreach (var performance in statementData.Performances)
        {
            result.Append(String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", performance.PlayName, performance.Amount, performance.Audience));
        }

        result.Append(String.Format(cultureInfo, "Amount owed is {0:C}\n", statementData.TotalAmount));
        result.Append(String.Format(cultureInfo, "You earned {0} credits\n",statementData.VolumeCredits));

        return result.ToString();
    }
}