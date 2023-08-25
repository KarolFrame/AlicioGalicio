using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D porDefecto;
    Vector2 hotSpot = new Vector2(0, 0);
    private void Awake()
    {
        CursosPorDefecto();
    }


    public void SetCursorRecortable(Sprite icon)
    {
        Cursor.SetCursor(icon.texture, hotSpot, CursorMode.Auto);
    }
    public void CursosPorDefecto()
    {
        Cursor.SetCursor(porDefecto, hotSpot, CursorMode.Auto);
    }
}
