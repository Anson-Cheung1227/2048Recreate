using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    private const int GRID_X = 4, GRID_Y = 4;
    [SerializeField] private Vector2 _gridPos;
    [SerializeField] private float _cellSize;
    [SerializeField] private GameObject _tilePrefab, _backgroundPrefab;
    private UnityGrid<GameObject> _grid;

    void Start()
    {
        EventManager.Instance.OnGameInput += MoveGrid;
        _grid = new UnityGrid<GameObject>(GRID_X, GRID_Y, _gridPos, _cellSize);
        for (int i = 0; i < GRID_X; ++i)
        {
            for (int e = 0; e < GRID_Y; ++e)
            {
                GameObject tileInstance = Instantiate(_tilePrefab, this.transform);
                _grid.SetValue(i, e, tileInstance);
                tileInstance.transform.position = _grid.GetWorldPosition(i, e);
                tileInstance.name = 0.ToString();
                Instantiate(_backgroundPrefab, _grid.GetWorldPosition(i, e), Quaternion.identity);
            }
        }
    }

    private void Update()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="direction"> Vector2 should EITHER be x = 0 OR y = 0</param>
    private void MoveGrid(Vector2 direction)
    {
        if (direction.x != 0) // X
        {
            for (int y = 0; y < GRID_Y; ++y)
            {
                if (direction.x > 0)
                {
                    for (int x = GRID_X - 1; x >= 0; --x)
                    {
                        if (x + 1 > GRID_X - 1) continue;
                        GameObject current = _grid.GetValue(x, y);
                        if (current.name == "0") continue;
                        GameObject right = _grid.GetValue(x + 1, y);
                        int count = 0;
                        while (Int32.Parse(right.name) == 0) //Empty
                        {
                            _grid.SetValue(x + 1 + count, y, current);
                            _grid.SetValue(x + count, y, right);
                            current.transform.position = _grid.GetWorldPosition(x + 1 + count, y);
                            right.transform.position = _grid.GetWorldPosition(x + count, y);
                            ++count;
                            if (x + 1 + count > GRID_X - 1) break;
                            right = _grid.GetValue(x + 1 + count, y);
                            
                        }
                        if (Int32.Parse(right.name) == Int32.Parse(current.name)) //Same value tiles
                        {
                            right.name = (Int32.Parse(right.name) * 2).ToString();
                            current.name = 0.ToString();
                            AnimateMergeTile(right);
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < GRID_X; ++x)
                    {
                        if (x - 1 < 0) continue;
                        GameObject current = _grid.GetValue(x, y);
                        if (current.name == "0") continue;
                        GameObject left = _grid.GetValue(x - 1, y);
                        int count = 0;
                        while (Int32.Parse(left.name) == 0) //Empty
                        {
                            _grid.SetValue(x - 1 - count, y, current);
                            _grid.SetValue(x - count, y, left);
                            current.transform.position = _grid.GetWorldPosition(x - 1 - count, y);
                            left.transform.position = _grid.GetWorldPosition(x - count, y);
                            ++count;
                            if (x - 1 - count < 0) break;
                            left = _grid.GetValue(x - 1 - count, y);
                        }
                        if (Int32.Parse(left.name) == Int32.Parse(current.name)) //Same value tiles
                        {
                            left.name = (Int32.Parse(left.name) * 2).ToString();
                            current.name = 0.ToString();
                            AnimateMergeTile(left);
                        }
                    }
                }
            }
        }
        else // Y
        {
            for (int x = 0; x < GRID_X; ++x)
            {
                if (direction.y > 0) //Down
                {
                    for (int y = GRID_Y - 1; y >= 0; --y)
                    {
                        if (y + 1 > GRID_Y - 1) continue;
                        GameObject current = _grid.GetValue(x, y);
                        if (Int32.Parse(current.name) == 0) continue;
                        GameObject down = _grid.GetValue(x, y + 1);
                        int count = 0;
                        while (Int32.Parse(down.name) == 0) //Empty
                        {
                            _grid.SetValue(x, y + 1 + count, current);
                            _grid.SetValue(x, y + count, down);
                            current.transform.position = _grid.GetWorldPosition(x, y + 1 + count);
                            down.transform.position = _grid.GetWorldPosition(x, y + count);
                            ++count;
                            if (y + 1 + count > GRID_Y - 1) break;
                            down = _grid.GetValue(x, y + 1 + count);
                        }
                        if (Int32.Parse(down.name) == Int32.Parse(current.name)) //Same value tiles
                        {
                            down.name = (Int32.Parse(down.name) * 2).ToString();
                            current.name = 0.ToString();
                            AnimateMergeTile(down);
                        }
                    }
                }
                else
                {
                    for (int y = 0; y < GRID_Y; ++y)
                    {
                        if (y - 1 < 0) continue;
                        GameObject current = _grid.GetValue(x, y);
                        if (Int32.Parse(current.name) == 0) continue;
                        GameObject up = _grid.GetValue(x, y - 1);
                        int count = 0;
                        while (Int32.Parse(up.name) == 0) //Empty
                        {
                            _grid.SetValue(x, y - 1 - count, current);
                            _grid.SetValue(x, y - count, up);
                            current.transform.position = _grid.GetWorldPosition(x, y - 1 - count);
                            up.transform.position = _grid.GetWorldPosition(x, y - count);
                            ++count;
                            if (y - 1 - count < 0) break;
                            up = _grid.GetValue(x, y - 1 - count);
                        }
                        if (Int32.Parse(up.name) == Int32.Parse(current.name)) //Same value tiles
                        {
                            up.name = (Int32.Parse(up.name) * 2).ToString();
                            current.name = 0.ToString();
                            AnimateMergeTile(up);
                        }
                    }
                }
            }
        }
        AddTile();
    }

    private List<GameObject> GetEmptyTiles(UnityGrid<GameObject> grid)
    {
        List<GameObject> list = new List<GameObject>();
        for (int x = 0; x < grid.X; ++x)
        {
            for (int y = 0; y < grid.Y; ++y)
            {
                GameObject current = _grid.GetValue(x, y);
                if (Int32.Parse(current.name) == 0)
                {
                    list.Add(current);
                }
            }
        }

        return list;
    }

    private void AnimateMergeTile(GameObject tile)
    {
        LTSeq sequence = LeanTween.sequence();
        sequence.append(LeanTween.scale(tile, new Vector3(1.6f, 1.6f, 1.6f), 0.1f));
        sequence.append(LeanTween.scale(tile, new Vector3(1.5f, 1.5f, 1.5f), 0.1f));
    }
    private void AddTile()
    {
        List<GameObject> empty = GetEmptyTiles(_grid);
        if (empty.Count == 0)
        {
            //death
        }
        else
        {
            GameObject picked = empty[Random.Range(0, empty.Count - 1)];
            picked.name = 2.ToString();
            picked.transform.localScale = new Vector3(0, 0, 0);
            LeanTween.scale(picked, new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
        }
    }
}