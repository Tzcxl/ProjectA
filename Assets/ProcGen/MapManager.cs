using System.Collections;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    public GameObject player;    // Объект игрока, который будет перемещаться
    private static Room currentRoom;    // Текущая комната, в которой находится игрок

    private void Awake()
    {
        Instantiate(player,new Vector2(0,0), Quaternion.identity);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SetCurrentRoom(Room room)
    {
        currentRoom = room;
    }

    public void MoveToRoom(Room targetRoom)
    {
        
         StartCoroutine(MovePlayer(targetRoom));
         currentRoom = targetRoom;
       
    }

    private IEnumerator MovePlayer(Room targetRoom)
    {
        Vector3 startPosition = player.transform.position;
        Vector3 endPosition = targetRoom.Position;
        float travelTime = 1.0f; // Время, за которое персонаж переместится
        float elapsedTime = 0;

        while (elapsedTime < travelTime)
        {
            player.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = endPosition;
    }
}
