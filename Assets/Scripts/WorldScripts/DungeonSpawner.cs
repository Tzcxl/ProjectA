using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public Vector2 position;
    public GameObject roomPrefab;
    public List<Vector2> doorPositions = new List<Vector2>(); // ������ ������� ������

    public Room(Vector2 pos, GameObject prefab)
    {
        position = pos;
        roomPrefab = prefab;
    }
}

public class DungeonSpawner : MonoBehaviour
{
    public GameObject startRoomPrefab;
    public List<GameObject> roomPrefabs;
    public GameObject uniqueRoomPrefab1;
    public int uniqueRoomCount1 = 3;
    public GameObject uniqueRoomPrefab2;
    public int uniqueRoomCount2 = 2;
    public GameObject uniqueRoomPrefab3;
    public int uniqueRoomCount3 = 1;
    public int totalRooms = 10;
    public GameObject doorPrefab; // ������ �����

    private List<Room> rooms = new List<Room>();
    private List<Vector2> possiblePositions = new List<Vector2>();

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        // Add the start room
        Room startRoom = new Room(Vector2.zero, startRoomPrefab);
        rooms.Add(startRoom);
        Instantiate(startRoom.roomPrefab, startRoom.position, Quaternion.identity);
        AddPossiblePositions(startRoom.position);

        // Generate other rooms
        for (int i = rooms.Count; i < totalRooms; i++)
        {
            if (possiblePositions.Count == 0)
            {
                Debug.LogWarning("No more possible positions to place rooms.");
                break;
            }

            Vector2 newRoomPosition = possiblePositions[Random.Range(0, possiblePositions.Count)];
            if (IsPositionOccupied(newRoomPosition))
            {
                // Remove this position from possible positions and continue to the next iteration
                possiblePositions.Remove(newRoomPosition);
                i--;
                continue;
            }

            GameObject newRoomPrefab = roomPrefabs[Random.Range(0, roomPrefabs.Count)];
            Room newRoom = new Room(newRoomPosition, newRoomPrefab);
            GenerateDoorPositions(newRoom);
            rooms.Add(newRoom);
            Instantiate(newRoom.roomPrefab, newRoom.position, Quaternion.identity);
            AddPossiblePositions(newRoom.position);

            // Place doors between rooms
            PlaceDoors(newRoom);
        }

        // Generate unique rooms after all normal rooms are generated
        GenerateUniqueRooms(uniqueRoomPrefab1, uniqueRoomCount1);
        GenerateUniqueRooms(uniqueRoomPrefab2, uniqueRoomCount2);
        GenerateUniqueRooms(uniqueRoomPrefab3, uniqueRoomCount3);
    }

    void GenerateUniqueRooms(GameObject uniquePrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            bool uniqueRoomPlaced = false;

            while (!uniqueRoomPlaced)
            {
                if (possiblePositions.Count == 0)
                {
                    Debug.LogWarning("No more possible positions to place unique rooms.");
                    break;
                }

                Vector2 newRoomPosition = possiblePositions[Random.Range(0, possiblePositions.Count)];
                if (IsPositionOccupied(newRoomPosition))
                {
                    // Remove this position from possible positions and continue to the next iteration
                    possiblePositions.Remove(newRoomPosition);
                    continue;
                }

                Room newRoom = new Room(newRoomPosition, uniquePrefab);
                GenerateDoorPositions(newRoom);
                rooms.Add(newRoom);
                Instantiate(newRoom.roomPrefab, newRoom.position, Quaternion.identity);
                AddPossiblePositions(newRoom.position);
                uniqueRoomPlaced = true;

                // Place doors between rooms
                PlaceDoors(newRoom);
            }
        }
    }
    void GenerateDoorPositions(Room room)
    {
        // Clear existing door positions
        room.doorPositions.Clear();

        // Add door positions based on room size or specific logic
        // For example, add doors in the center of each side
        room.doorPositions.Add(new Vector2(0, 0.5f));   // Top
        room.doorPositions.Add(new Vector2(0, -0.5f));  // Bottom
        room.doorPositions.Add(new Vector2(-0.5f, 0));  // Left
        room.doorPositions.Add(new Vector2(0.5f, 0));   // Right
    }

    void AddPossiblePositions(Vector2 position)
    {
        List<Vector2> newPositions = new List<Vector2>
        {
            position + Vector2.up,
            position + Vector2.down,
            position + Vector2.left,
            position + Vector2.right
        };

        foreach (Vector2 pos in newPositions)
        {
            if (!IsPositionOccupied(pos) && !possiblePositions.Contains(pos))
            {
                possiblePositions.Add(pos);
            }
        }

        // Remove the current position from possible positions
        possiblePositions.Remove(position);
    }

    bool IsPositionOccupied(Vector2 position)
    {
        foreach (Room room in rooms)
        {
            if (room.position == position)
            {
                return true;
            }
        }
        return false;
    }

    void PlaceDoors(Room room)
    {
        Debug.Log("Placing doors for room at position: " + room.position + "  " + room.doorPositions);

        List<GameObject> createdDoors = new List<GameObject>();

        foreach (Vector2 doorPos in room.doorPositions)
        {
            Debug.Log("Placing door at position: " + doorPos);

            Vector3 doorWorldPosition = new Vector3(room.position.x + doorPos.x, room.position.y + doorPos.y, 0f);
            GameObject door = Instantiate(doorPrefab, doorWorldPosition, Quaternion.identity, transform);

            // ���������� ���������� ����� �� ������ ������� ������������ �������
            if (doorPos == new Vector2(0, 0.5f) || doorPos == new Vector2(0, -0.5f))
            {
                // ����� �� ������� ��� ������ ������� - ������������ �� 90 ��������
                door.transform.Rotate(Vector3.forward, 90f);
            }
            // ��� ������ ������� ����� �� ��������� �������

            createdDoors.Add(door);
        }

        // ��������� ������ ��������� ����� �� ��������������� � ���������
        foreach (GameObject door in createdDoors)
        {
            bool doorTouchesRoom = false;

            foreach (Room otherRoom in rooms)
            {
                if (otherRoom != room)
                {
                    // ���������, ��� ����� �� ��������� ������ ������ �������
                    if (IsDoorTouchingRoom(door, otherRoom))
                    {
                        doorTouchesRoom = true;
                        break;
                    }
                }
            }

            // ���� ����� �� ������������� �� � ����� ��������, ������� �
            if (!doorTouchesRoom)
            {
                Destroy(door);
            }
        }
    }

    bool IsDoorTouchingRoom(GameObject door, Room room)
    {
        // �����������, ��� ������� ������� � ������� ����� ��������
        float roomLeft = room.position.x - 0.5f;
        float roomRight = room.position.x + 0.5f;
        float roomTop = room.position.y + 0.5f;
        float roomBottom = room.position.y - 0.5f;

        Vector2 doorPosition = new Vector2(door.transform.position.x, door.transform.position.y);

        // ���������, ��������� �� ������� ����� ������ ������ �������
        if (doorPosition.x >= roomLeft && doorPosition.x <= roomRight &&
            doorPosition.y >= roomBottom && doorPosition.y <= roomTop)
        {
            return true;
        }

        return false;
    }
}