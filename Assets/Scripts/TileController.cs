using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileController : MonoBehaviour
{
    [SerializeField] private TMP_Text _tileText;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private static readonly Color COLOR_EMPTY = new Color32(204, 192, 179, 255);
    private static readonly Color COLOR_2 = new Color32(238, 228, 218, 255);
    private static readonly Color COLOR_4 = new Color32(237, 224, 200, 255);
    private static readonly Color COLOR_8 = new Color32(242, 177, 121, 255);
    private static readonly Color COLOR_16 = new Color32(245, 149, 99, 255);
    private static readonly Color COLOR_32 = new Color32(246, 124, 95, 255);
    private static readonly Color COLOR_64 = new Color32(246, 94, 59, 255);
    private static readonly Color COLOR_128 = new Color32(237, 207, 114, 255);
    private static readonly Color COLOR_256 = new Color32(237, 204, 97, 255);
    private static readonly Color COLOR_512 = new Color32(237, 200, 80, 255);
    private static readonly Color COLOR_1024 = new Color32(237, 197, 63, 255);
    private static readonly Color COLOR_2048 = new Color32(237, 194, 46, 255);
    private static readonly Color COLOR_OTHER = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Int32.Parse(gameObject.name) == 0)
            _tileText.text = string.Empty;
        else
            _tileText.text = gameObject.name;
        switch (Int32.Parse(gameObject.name))
        {
            case 0:
                _spriteRenderer.color = COLOR_EMPTY;
                break;
            case 2: 
                _spriteRenderer.color = COLOR_2;
                break;
            case 4: 
                _spriteRenderer.color = COLOR_4;
                break;
            case 8: 
                _spriteRenderer.color = COLOR_8;
                break;
            case 16: 
                _spriteRenderer.color = COLOR_16;
                break;
            case 32: 
                _spriteRenderer.color = COLOR_32;
                break;
            case 64: 
                _spriteRenderer.color = COLOR_64;
                break;
            case 128: 
                _spriteRenderer.color = COLOR_128;
                break;
            case 256: 
                _spriteRenderer.color = COLOR_256;
                break;
            case 512: 
                _spriteRenderer.color = COLOR_512;
                break;
            case 1024: 
                _spriteRenderer.color = COLOR_1024;
                break;
            case 2048: 
                _spriteRenderer.color = COLOR_2048;
                break;
            default:
                _spriteRenderer.color = COLOR_OTHER;
                break;
        }
    }
}
