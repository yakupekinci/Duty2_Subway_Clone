using System.Linq;
using UnityEngine;

public class MapActiver : MonoBehaviour
{
    public MapPool MapPool;
    private void Start()
    {
        MapPool = FindObjectOfType<MapPool>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var obj = MapPool.mapPool.Where(x => !x.activeSelf);
            var map = obj.FirstOrDefault();
            map.SetActive(true);
            map.transform.position = transform.parent.transform.GetChild(0).transform.position;
            map.GetComponent<Map>().SpawnObstacle();
        }
    }
}