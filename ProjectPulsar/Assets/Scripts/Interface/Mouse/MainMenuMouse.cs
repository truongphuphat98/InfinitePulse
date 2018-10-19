using UnityEngine;
using System.Collections;

public class MainMenuMouse : MonoBehaviour {

    public Texture2D cursorTexture;
    Vector2 cursorHotspot;

    void Start () {
        Invoke("SetCustomCursor", 0);
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
    }
	
	void Update () {
	
	}

    void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);//Resets the cursor to the default  
    }

    void SetCustomCursor()
    {
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);//Replace the 'cursorTexture' with the cursor 
    }
}
