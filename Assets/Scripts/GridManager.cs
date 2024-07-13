using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    private const int GRID_X = 4, GRID_Y = 4;
    [SerializeField] private Vector2 _gridPos;
    [SerializeField] private float _cellSize;
    [SerializeField] private GameObject _tilePrefab;
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
            }
        }
    }

    private void Update()
    {
    }

    private void MoveGrid(Vector2 direction)
    {
        if (direction.x <= 0 && direction.y <= 0)
        {
            for (int i = 0; i < GRID_X; ++i)
            {
                for (int e = 0; e < GRID_Y; ++e)
                {
                    GameObject current = _grid.GetValue(i, e);
                    int x = i + (int)direction.x, y = e + (int)direction.y;
                    int ox = i, oy = e;
                    if (x < 0 || x > 3 || y < 0 || y > 3 || current.name == "0")
                    {
                        continue;
                    }

                    while (Int32.Parse(_grid.GetValue(x, y).name) == 0)
                    {
                        Debug.Log($"{x} {y}");
                        Debug.Log($"{current.transform.position}");
                        GameObject change = _grid.GetValue(x, y);
                        _grid.SetValue(x, y, current);
                        _grid.SetValue(ox, oy, change);
                        Vector2 currentPos = current.transform.position;
                        current.transform.position = change.transform.position;
                        change.transform.position = currentPos;
                        ox = x;
                        oy = y;
                        x += (int)direction.x;
                        y += (int)direction.y;
                        Debug.Log($"{current.transform.position}");
                        if (x < 0 || x > 3 || y < 0 || y > 3)
                        {
                            break;
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = GRID_X - 1; i >= 0; --i)
            {
                for (int e = GRID_Y -1; e >= 0; --e)
                {
                    GameObject current = _grid.GetValue(i, e);
                    int x = i + (int)direction.x, y = e + (int)direction.y;
                    int ox = i, oy = e;
                    if (x < 0 || x > 3 || y < 0 || y > 3 || current.name == "0")
                    {
                        continue;
                    }

                    while (Int32.Parse(_grid.GetValue(x, y).name) == 0)
                    {
                        Debug.Log($"{x} {y}");
                        Debug.Log($"{current.transform.position}");
                        GameObject change = _grid.GetValue(x, y);
                        _grid.SetValue(x, y, current);
                        _grid.SetValue(ox, oy, change);
                        Vector2 currentPos = current.transform.position;
                        current.transform.position = change.transform.position;
                        change.transform.position = currentPos;
                        ox = x;
                        oy = y;
                        x += (int)direction.x;
                        y += (int)direction.y;
                        Debug.Log($"{current.transform.position}");
                        if (x < 0 || x > 3 || y < 0 || y > 3)
                        {
                            break;
                        }
                    }
                }
            }
        }
        AddTile();
    }

    private void AddTile()
    {
        List<GameObject> empty = new List<GameObject>();
        for (int i = 0; i < GRID_X; ++i)
        {
            for (int e = 0; e < GRID_Y; ++e)
            {
                GameObject current = _grid.GetValue(i, e);
                if (current is not null)
                {
                    empty.Add(current);
                }
            }
        }
        if (empty.Count == 0)
        {
            //death
        }
        else
        {
            GameObject picked = empty[Random.Range(0, empty.Count - 1)];
            picked.name = 2.ToString();
        }
    }
}