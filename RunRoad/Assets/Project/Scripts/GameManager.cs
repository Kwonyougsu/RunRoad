using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ObjectPool objectpool;
    public Transform[] leftSpawnPoints; // 왼쪽 스폰 포인트
    public Transform[] rightSpawnPoints; // 오른쪽 스폰 포인트
    private float spawnInterval; // 스폰 간격

    void Start()
    {
        spawnInterval = Random.Range(1f, 10f);
        InvokeRepeating("SpawnCar", spawnInterval, spawnInterval); // 반복적으로 자동차 생성

    }

    void SpawnCar()
    {
        bool spawnLeft = Random.value > 0.5f; // 랜덤하게 왼쪽이나 오른쪽에서 스폰

        GameObject carPrefab = objectpool.SpawnFromPool("Object");

        if (spawnLeft)
        {
            int spawnIndex = Random.Range(0, leftSpawnPoints.Length);
            Instantiate(carPrefab, leftSpawnPoints[spawnIndex].position, Quaternion.identity);
        }
        else
        {
            int spawnIndex = Random.Range(0, rightSpawnPoints.Length);
            Instantiate(carPrefab, rightSpawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}
