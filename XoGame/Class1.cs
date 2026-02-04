public class Player
{
    public string Name;
    public char Symbol;
    public bool IsRobot;

    public Player(string name, char symbol, bool isRobot = false)
    {
        Name = name;
        Symbol = symbol;
        IsRobot = isRobot;
    }
}
