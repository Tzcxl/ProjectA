using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.ProcGen
{
    public class Generation : MonoBehaviour
    {
        public GameObject playerPref;
        public GameObject roomPrefab;  // Префаб для комнат
        public int rowNumber = 10;     // Количество строк
        public int minRoom = 1;        // Минимальное количество комнат на строку
        public int maxRoom = 4;        // Максимальное количество комнат на строку

        private List<Room> _spawnRooms = new List<Room>();
        private Room _startRoom;
        private Room _endRoom;

        void Start()
        {
            GenerateStartGraph();
            for (int i = 2; i < 2 * rowNumber; i += 2)
            {
                GenerateRooms(i);
            }
            ConnectRooms();
            CreateVisualRepresentation();
            MapManager.SetCurrentRoom(_spawnRooms[0]);
        }

        void GenerateStartGraph()
        {
            _startRoom = new Room(roomPrefab, new Vector2(0, 0));
            _endRoom = new Room(roomPrefab, new Vector2(0, 2 * rowNumber));

            _spawnRooms.Add(_startRoom);
            _spawnRooms.Add(_endRoom);
        }

        void CreateVisualRepresentation()
        {
            foreach (Room room in _spawnRooms)
            {
                GameObject roomGO = Instantiate(room.RoomGameObject, room.Position, Quaternion.identity);
                MapNode roomNode = roomGO.AddComponent<MapNode>();
                roomNode.roomToMove = room;
            }
        }

        void GenerateRooms(int row)
        {
            int roomsamount = 0;
            int roomsToGenerate = Random.Range(minRoom, maxRoom);
            for (int roomsPerRow = 0; roomsPerRow < roomsToGenerate; roomsPerRow++)
            {
                Vector2 newPosition = new Vector2(Random.Range(-2, 2), row);
                bool positionTaken = false;

                foreach (Room existingRoom in _spawnRooms)
                {
                    if (existingRoom.Position == newPosition)
                    {
                        positionTaken = true;
                        break;
                    }
                }

                if (!positionTaken)
                {
                    roomsamount++;
                    Room newRoom = new Room(roomPrefab, newPosition);
                    _spawnRooms.Add(newRoom);
                }
            }
        }
        void ConnectRooms()
        {
            foreach (Room room in _spawnRooms)
            {
                foreach (Room otherRoom in _spawnRooms)
                {
                    if (room == otherRoom) continue;

                    // Проверка расстояния или другой критерий для соединения узлов
                    if (Vector2.Distance(room.Position, otherRoom.Position) <= 1.0f)
                    {
                        room.ConnectedRooms.Add(otherRoom);
                    }
                }
            }
        }
    }
}

