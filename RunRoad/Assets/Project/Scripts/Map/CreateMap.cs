using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject HumanRoad;
    [SerializeField]
    private GameObject CarRoad;

    private Queue<GameObject> HumanRoadQueue = new Queue<GameObject>();
    private Queue<GameObject> CarRoadQueue = new Queue<GameObject>();

    public Transform playerTransform;
    public int mapPartsCount;
    private ObjectPool mapObject;

    private void Awake()
    {
        for (int i = 0; i < mapPartsCount; i++)
        {
            GameObject obj1 = Instantiate(HumanRoad);
            obj1.transform.parent = transform;
            HumanRoadQueue.Enqueue(obj1);
            obj1.SetActive(false);

            GameObject obj2 = Instantiate(CarRoad);
            obj2.transform.parent = transform;
            CarRoadQueue.Enqueue(obj2);
            obj2.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(RespawnMap());
    }
    IEnumerator RespawnMap()
    {
        while (true)
        {
            for (int i = -1; i < 10; i++)
            {
                GameObject map = GetRandomMapPart();
                setPosition(map, i);
                map.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private GameObject GetRandomMapPart()
    {
        GameObject map;
        if (Random.value > 0.5f)
        {
            map = HumanRoadQueue.Dequeue();
            HumanRoadQueue.Enqueue(map);
        }
        else
        {
            map = CarRoadQueue.Dequeue();
            CarRoadQueue.Enqueue(map);
        }
        return map;
    }

    private void setPosition(GameObject obj, float i)
    {
        Vector3 newPosition = new Vector3(obj.transform.position.x, 0, playerTransform.position.z);
        newPosition.z += 21 * i;
        obj.transform.position = newPosition;
    }
}
