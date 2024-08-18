namespace TheatricalPlayersRefactoringKata.Domain;

public class Play
{
    public string Name { get; }
    public int Lines { get; }
    public string Type { get; }

    public Play(string name, int lines, string type) {
        Name = name;
        Lines = lines;
        Type = type;
    }
}