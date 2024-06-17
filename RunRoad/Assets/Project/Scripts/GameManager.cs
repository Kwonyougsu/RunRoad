using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab; // �ڵ��� ������
    public Transform[] leftSpawnPoints; // ���� ���� ����Ʈ
    public Transform[] rightSpawnPoints; // ������ ���� ����Ʈ
    public float spawnInterval = 2f; // ���� ����

    void Start()
    {
        InvokeRepeating("SpawnCar", spawnInterval, spawnInterval); // �ݺ������� �ڵ��� ����
    }

    void SpawnCar()
    {
        bool spawnLeft = Random.value > 0.5f; // �����ϰ� �����̳� �����ʿ��� ����

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
