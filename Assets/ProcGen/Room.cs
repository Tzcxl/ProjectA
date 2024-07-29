using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public GameObject RoomGameObject { get; private set; }
    public Vector2 Position { get; private set; }
    public List<Room> ConnectedRooms = new List<Room>();
    public Room(GameObject roomGameObject, Vector2 position)
    {
        RoomGameObject = roomGameObject;
        SetPosition(position);
    }

    public void SetPosition(Vector2 position)
    {
        Position = position;
        RoomGameObject.transform.position = new Vector2(position.x, position.y);
    }
}