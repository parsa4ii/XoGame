public class Board
{
    private char[,] grid = new char[3, 3];

    public Board()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                grid[i, j] = ' ';
    }

    public void Print()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {grid[i, 0]} | {grid[i, 1]} | {grid[i, 2]} ");
            if (i < 2)
                Console.WriteLine("---+---+---");
        }
    }

    public bool PlaceMove(int r, int c, char s)
    {
        if (grid[r, c] != ' ')
            return false;

        grid[r, c] = s;
        return true;
    }

    public bool CheckWin(char p)
    {
        for (int i = 0; i < 3; i++)
            if (grid[i, 0] == p && grid[i, 1] == p && grid[i, 2] == p)
                return true;

        for (int j = 0; j < 3; j++)
            if (grid[0, j] == p && grid[1, j] == p && grid[2, j] == p)
                return true;

        if (grid[0, 0] == p && grid[1, 1] == p && grid[2, 2] == p) return true;
        if (grid[0, 2] == p && grid[1, 1] == p && grid[2, 0] == p) return true;

        return false;
    }

    public bool IsFull()
    {
        foreach (char c in grid)
            if (c == ' ')
                return false;

        return true;
    }

    public List<(int, int)> GetEmptyCells()
    {
        List<(int, int)> list = new List<(int, int)>();

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (grid[i, j] == ' ')
                    list.Add((i, j));

        return list;
    }
}
