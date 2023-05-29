using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorTexture;
    void Start()
    {
        UnityEngine.Cursor.SetCursor(cursorTexture, new Vector2(10, 10), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
