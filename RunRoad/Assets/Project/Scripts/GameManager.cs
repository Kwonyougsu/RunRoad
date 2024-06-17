using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] carPrefabs; // �ڵ��� ������
    public Transform[] leftSpawnPoints; // ���� ���� ����Ʈ
    public Transform[] rightSpawnPoints; // ������ ���� ����Ʈ
    private float spawnInterval; // ���� ����

    void Start()
    {
        spawnInterval = Random.Range(1f, 10f);
        InvokeRepeating("SpawnCar", spawnInterval, spawnInterval); // �ݺ������� �ڵ��� ����
    }

    void SpawnCar()
    {
        bool spawnLeft = Random.value > 0.5f; // �����ϰ� �����̳� �����ʿ��� ����

        GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];

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
