using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseCursor : MonoBehaviour
{
    Player pulsarPower;
    PlayerTuto pulsarPower2;

    public Texture2D cursorTexture, redCursor, blueCursor, redBlueCursor;

    Vector3 mousePos;
    Vector2 cursorHotspot;

    void Start()
    {
        Invoke("SetCustomCursor", 0);//Call the 'SetCustomCursor'

        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        if (PlayerPrefs.GetInt("TutoFini") == 0)
            pulsarPower2 = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<PlayerTuto>();
        if (PlayerPrefs.GetInt("TutoFini") == 1)
            pulsarPower = GameObject.FindGameObjectWithTag("Pulsar").GetComponent<Player>();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("TutoFini") == 1)
        {
            if (pulsarPower.attractReload >= pulsarPower.attractTime && pulsarPower.pushReload >= pulsarPower.pushTime)
                Cursor.SetCursor(redBlueCursor, cursorHotspot, CursorMode.Auto);
            if (pulsarPower.attractReload <= pulsarPower.attractTime && pulsarPower.pushReload >= pulsarPower.pushTime)
                Cursor.SetCursor(redCursor, cursorHotspot, CursorMode.Auto);
            if (pulsarPower.attractReload >= pulsarPower.attractTime && pulsarPower.pushReload <= pulsarPower.pushTime)
                Cursor.SetCursor(blueCursor, cursorHotspot, CursorMode.Auto);
            if (pulsarPower.attractReload <= pulsarPower.attractTime && pulsarPower.pushReload <= pulsarPower.pushTime)
                Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }

        if (PlayerPrefs.GetInt("TutoFini") == 0)
        {
            if (pulsarPower2.attractReload >= pulsarPower2.attractTime && pulsarPower2.pushReload >= pulsarPower2.pushTime)
                Cursor.SetCursor(redBlueCursor, cursorHotspot, CursorMode.Auto);
            if (pulsarPower2.attractReload <= pulsarPower2.attractTime && pulsarPower2.pushReload >= pulsarPower2.pushTime)
                Cursor.SetCursor(redCursor, cursorHotspot, CursorMode.Auto);
            if (pulsarPower2.attractReload >= pulsarPower2.attractTime && pulsarPower2.pushReload <= pulsarPower2.pushTime)
                Cursor.SetCursor(blueCursor, cursorHotspot, CursorMode.Auto);
            if (pulsarPower2.attractReload <= pulsarPower2.attractTime && pulsarPower2.pushReload <= pulsarPower2.pushTime)
                Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }
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
