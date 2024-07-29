using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNode : MonoBehaviour
{
    public Room roomToMove;
   
    private void OnMouseDown()
    {
        MapManager.Instance.MoveToRoom(roomToMove);
        SceneManager.LoadScene(0);
    }
}
