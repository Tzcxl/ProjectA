using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public GameObject roomPrefab;  // Префаб для комнат
    public int rowNumber = 20;     // Количество строк
    public int minRoom = 1;        // Минимальное количество комнат на строку
    public int maxRoom = 4;        // Максимальное количество комнат на строку

    private List<Room> spawnRooms = new List<Room>();
    private Room startRoom;
    private Room endRoom;

    void Start()
    {
        GenerateStartGraph();
        for (int i = 2; i < rowNumber; i += 2)
        {
            GenerateRooms(i);
        }
        CreateVisualRepresentation();
    }

    void GenerateStartGraph()
    {
        startRoom = new Room(roomPrefab, new Vector2(0, 0));
        endRoom = new Room(roomPrefab, new Vector2(0, rowNumber));

        spawnRooms.Add(startRoom);
        spawnRooms.Add(endRoom);
    }

    void CreateVisualRepresentation()
    {
        foreach (Room room in spawnRooms)
        {
            Instantiate(room.RoomGameObject, room.Position, Quaternion.identity);
        }
    }

    void GenerateRooms(int row)
    {
        int roomsToGenerate = Random.Range(minRoom, maxRoom);
        for (int roomsPerRow = 0; roomsPerRow < roomsToGenerate; roomsPerRow++)
        {
            Vector2 newPosition = new Vector2(Random.Range(-2, 2), row);
            bool positionTaken = false;

            foreach (Room existingRoom in spawnRooms)
            {
                if (existingRoom.Position == newPosition)
                {
                    positionTaken = true;
                    break;
                }
            }

            if (!positionTaken)
            {
                Room newRoom = new Room(roomPrefab, newPosition);
                spawnRooms.Add(newRoom);
            }
        }
    }
}

public class Room
{
    public GameObject RoomGameObject { get; private set; }
    public Vector2 Position { get; private set; }

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
