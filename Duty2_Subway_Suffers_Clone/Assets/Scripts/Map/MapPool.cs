using System.Collections.Generic;
using UnityEngine;

public class MapPool : MonoBehaviour
{
    public List<GameObject> mapPrefabs;
    public int number;
    public List<GameObject> mapPool = new List<GameObject>();

    private void Start()
    {
       
        ShuffleFirstThree();

      
        for (int i = 0; i < 3 * number; i++)
        {
            var mapInstance = Instantiate(mapPrefabs[i % 3]);
            mapInstance.transform.SetParent(transform);
            mapInstance.SetActive(false);
            mapPool.Add(mapInstance);
        }
    }

    private void ShuffleFirstThree()
    {
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(i, 3);
            GameObject temp = mapPrefabs[i];
            mapPrefabs[i] = mapPrefabs[randomIndex];
            mapPrefabs[randomIndex] = temp;
        }
    }
    
}
