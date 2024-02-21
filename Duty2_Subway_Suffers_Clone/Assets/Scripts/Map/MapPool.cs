using System.Collections.Generic;
using UnityEngine;

public class MapPool : MonoBehaviour
{
    public List<GameObject> mapPool;
    public List<GameObject> mapPrefabs;

    public int number = 15;
    private void Start()
    {
        for (int i = 0; i < 3 * number; i++)
        {
            var mapInstante = Instantiate(mapPrefabs[i]);
            mapInstante.SetActive(false);
            mapPool.Add(mapInstante);
        }
    }

}
