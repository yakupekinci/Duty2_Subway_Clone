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
            
            var objArray = MapPool.mapPool.Where(x => !x.activeSelf);
            var map = objArray.FirstOrDefault();
            map.transform.position = transform.parent.transform.GetChild(0).transform.position;
            map.SetActive(true);


        }
    }
}