using UnityEngine;

public class Player
{
    public GameObject PlayerPref { get;  set; }
    public Vector2 Position { get;  set; }

    public Player(GameObject roomGameObject, Vector2 position)
    {
        PlayerPref = roomGameObject;
        SetPosition(position);
    }

    public void SetPosition(Vector2 position)
    {
        Position = position;
        PlayerPref.transform.position = new Vector2(position.x, position.y);
    }
}