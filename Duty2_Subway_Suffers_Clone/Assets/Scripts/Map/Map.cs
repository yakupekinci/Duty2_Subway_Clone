using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<GameObject> redObstaclePF;
    public List<GameObject> greenObstaclePF;
    public List<GameObject> blueObstaclePF;
    public Transform leftSP;
    public Transform rightSP;
    public Transform middleSP;
    public List<GameObject> leftSPLst = new List<GameObject>();
    public List<GameObject> rightSPLst = new List<GameObject>();
    public List<GameObject> middleSPLst = new List<GameObject>();

    private void Awake()
    {
        PopulateSpawnLists(leftSP, leftSPLst);
        PopulateSpawnLists(rightSP, rightSPLst);
        PopulateSpawnLists(middleSP, middleSPLst);
    }

    private void PopulateSpawnLists(Transform spawnPoint, List<GameObject> spawnList)
    {
        int childCount = spawnPoint.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = spawnPoint.GetChild(i).gameObject;
            spawnList.Add(child);
        }
    }

    private void SpawnObstacles(List<GameObject> obstaclePrefabs, List<GameObject> spawnList)
    {
        if (obstaclePrefabs == null || spawnList == null || spawnList.Count == 0)
            return;

        int prefabCount = obstaclePrefabs.Count;
        int spawnCount = spawnList.Count;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject selectedPrefab = obstaclePrefabs[Random.Range(0, prefabCount)];
            GameObject spawnPoint = spawnList[i];

            GameObject obstacle = Instantiate(selectedPrefab, spawnPoint.transform.position, selectedPrefab.transform.rotation);
            obstacle.transform.SetParent(transform);
        }
    }

    public void SpawnObstacle()
    {
        if (gameObject.name.StartsWith("Red"))
        {
            SpawnObstacles(redObstaclePF, leftSPLst);
            SpawnObstacles(redObstaclePF, rightSPLst);
            SpawnObstacles(redObstaclePF, middleSPLst);
        }
        else if (gameObject.name.StartsWith("Green"))
        {
            SpawnObstacles(greenObstaclePF, leftSPLst);
            SpawnObstacles(greenObstaclePF, rightSPLst);
            SpawnObstacles(greenObstaclePF, middleSPLst);
        }
        else if (gameObject.name.StartsWith("Blue"))
        {
            SpawnObstacles(blueObstaclePF, leftSPLst);
            SpawnObstacles(blueObstaclePF, rightSPLst);
            SpawnObstacles(blueObstaclePF, middleSPLst);
        }
    }
}
