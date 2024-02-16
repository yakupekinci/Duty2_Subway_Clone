using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapPool : MonoBehaviour
{
    public List<GameObject> mapPool;
    public List<GameObject> mapPrefabs;
   
    public int number = 15;
    private void Start()
    {
        for (int i = 0; i < number; i++)
        {
            var mapInstante = Instantiate(mapPrefabs[Random.Range(0,mapPrefabs.Count)]);
            mapInstante.SetActive(false);
            mapPool.Add(mapInstante);
        }
    }

}
