using UnityEngine;

public class MapManager : MonoBehaviour
{
    public CreateMap createMap;
    public ObjectPool mapObject;

    private void Awake()
    {
        createMap = GetComponent<CreateMap>();
        mapObject = GetComponent<ObjectPool>();
    }
}