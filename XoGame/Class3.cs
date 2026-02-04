using System;

public class Game
{
    private Board board;
    private Player human;
    private Player robot;
    private Player currentPlayer;

    private Random rnd = new Random();

    public Game()
    {
        board = new Board();

        Console.Write("nam bazikon: ");
        human = new Player(Console.ReadLine()!, 'X', false);

        robot = new Player("Robot", 'O', true);

        currentPlayer = human;
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            board.Print();

            if (currentPlayer.IsRobot)
                RobotMove();
            else
                HumanMove();

            if (board.CheckWin(currentPlayer.Symbol))
            {
                Console.Clear();
                board.Print();
                Console.WriteLine($"\n {currentPlayer.Name} barande shod");
                break;
            }

            if (board.IsFull())
            {
                Console.Clear();
                board.Print();
                Console.WriteLine("\n mosavi shod");
                break;
            }

            SwitchPlayer();
        }
    }
    private void HumanMove()
    {
        Console.WriteLine($"\nnobat {human.Name}");

        int row = GetNumber("satr (0-2): ");
        int col = GetNumber("soton (0-2): ");

        if (!board.PlaceMove(row, col, human.Symbol))
        {
            Console.WriteLine("khane por ast");
            Console.ReadKey();
            HumanMove();
        }
    }
    private void RobotMove()
    {
        Console.WriteLine("\nrobot dar hal fekr kardan");
        System.Threading.Thread.Sleep(500);

        var emptyCells = board.GetEmptyCells();

        var choice = emptyCells[rnd.Next(emptyCells.Count)];

        board.PlaceMove(choice.Item1, choice.Item2, robot.Symbol);
    }

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == human) ? robot : human;
    }

    private int GetNumber(string msg)
    {
        int num;
        while (true)
        {
            Console.Write(msg);
            if (int.TryParse(Console.ReadLine(), out num) && num >= 0 && num <= 2)
                return num;

            Console.WriteLine("adad motabar vared kon");
        }
    }
}
