using TheatricalPlayersRefactoringKata.Domain;

public interface ICalculator{

    decimal CalculateAmount(Performance performance, Play play);
    int CalculateVolumeCredits(Performance performance, Play play);

}