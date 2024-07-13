using UnityEngine;

public class UnityGrid<TGridType> : Grid<TGridType>
{
    public float CellSize { get; private set; }
    public Vector2 StartVec { get; private set; }
    public UnityGrid(int x, int y, Vector2 startingVec, float cellSize) : base(x, y)
    {
        CellSize = cellSize;
        StartVec = startingVec;
    }

    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x, -y) * CellSize + StartVec;
    }

    public void GetXYByWorldPosition(Vector2 pos, out int x, out int y)
    {
        x = Mathf.FloorToInt((pos.x - StartVec.x) / CellSize);
        y = Mathf.FloorToInt((StartVec.y - pos.y) / CellSize);
    }
}