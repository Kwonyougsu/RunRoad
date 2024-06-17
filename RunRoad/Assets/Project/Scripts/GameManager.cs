using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ObjectPool objectpool;
    public Transform leftSpawnPoints; // 왼쪽 스폰 포인트
    public Transform rightSpawnPoints; // 오른쪽 스폰 포인트
    private float spawnInterval; // 스폰 간격

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        spawnInterval = Random.Range(1f, 10f);
        InvokeRepeating("SpawnCar", spawnInterval, spawnInterval); 

    }

    void SpawnCar()
    {
        bool spawnLeft = Random.value > 0.5f; // 랜덤하게 왼쪽이나 오른쪽에서 스폰

        GameObject carPrefab = objectpool.SpawnFromPool("Object");
        if (spawnLeft)
        {
            Instantiate(carPrefab, leftSpawnPoints.position, Quaternion.identity);
        }
        else
        {
            Instantiate(carPrefab, rightSpawnPoints.position, Quaternion.identity);
        }
    }
}
