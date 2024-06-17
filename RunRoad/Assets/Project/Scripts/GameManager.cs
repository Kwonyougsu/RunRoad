using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public ObjectPool objectpool;
    public Transform leftSpawnPoints; // ���� ���� ����Ʈ
    public Transform rightSpawnPoints; // ������ ���� ����Ʈ
    private float spawnInterval; // ���� ����

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
        bool spawnLeft = Random.value > 0.5f; // �����ϰ� �����̳� �����ʿ��� ����

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
