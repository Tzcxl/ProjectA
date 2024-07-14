using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Массив объектов для спавна
    public float spawnInterval = 5f; // Интервал спавна (в секундах)

    private void Start()
    {
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);

        // Добавляем компонент FollowPlayer к спавненному объекту
        spawnedObject.AddComponent<EnemyMond>().player = GameObject.FindGameObjectWithTag("_player").transform;
    }
}
