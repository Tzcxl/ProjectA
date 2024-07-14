using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // ������ �������� ��� ������
    public float spawnInterval = 5f; // �������� ������ (� ��������)

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);

        // ��������� ��������� FollowPlayer � ����������� �������
        spawnedObject.AddComponent<EnemyMond>().player = GameObject.FindGameObjectWithTag("_player").transform;
    }
}
