using System.Collections.Generic;
namespace TheatricalPlayersRefactoringKata.Services;

public class StatementData
{
    public string Customer { get; set; }
    public List<PerformanceSummary> Performances { get; set; } = new List<PerformanceSummary>();
    public decimal TotalAmount { get; set; }
    public int VolumeCredits { get; set; }
}

public class PerformanceSummary
{
    public string PlayName { get; set; }
    public int Audience { get; set; }
    public decimal Amount { get; set; }
    public int EarnedCredits{get; set; }
}