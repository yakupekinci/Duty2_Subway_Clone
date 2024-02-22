using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Map : MonoBehaviour
{


    [SerializeField] private List<GameObject> redObstaclePF;
    [SerializeField] private List<GameObject> greenObstaclePF;
    [SerializeField] private List<GameObject> blueObstaclePF;
    [SerializeField] private Transform leftSP;
    [SerializeField] private Transform rightSP;
    [SerializeField] private Transform middleSP;
    [SerializeField] private List<GameObject> leftSPLst;
    [SerializeField] private List<GameObject> rightSPLst;
    [SerializeField] private List<GameObject> middleSPLst;
    [SerializeField] private Transform ObstacleParent;

    private void OnEnable()
    {
        DOTween.Clear();
    }
    bool isActive;
    private void Update()
    {
        int i = 1;
        if (i < 2 && gameObject.activeSelf)
        {

            i = 3;
        }
    }
    private void Start()
    {
        SpawnObstacle();
    }
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
            obstacle.transform.SetParent(ObstacleParent);
        }
    }

    public void SpawnObstacle()
    {

        int childCount = ObstacleParent.childCount;
        if (childCount != 0)
        {

            for (int i = 0; i < childCount; i++)
            {
                GameObject obj = ObstacleParent.transform.GetChild(i).gameObject;
                Destroy(obj);
            }
        }

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
