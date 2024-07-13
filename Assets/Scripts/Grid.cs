
public class Grid<TGridType>
{
    public int X { get; private set; }
    public int Y { get; private set; }
    private readonly TGridType[,] _grid;

    public Grid(int x, int y)
    {
        X = x;
        Y = y;
        _grid = new TGridType[X, Y];
    }

    public bool SetValue(int x, int y, TGridType value)
    {
        if (x >= X || y >= Y || x < 0 || y < 0) return false;
        _grid[x, y] = value;
        return true;
    }

    public TGridType GetValue(int x, int y)
    {
        return _grid[x, y];
    }
}