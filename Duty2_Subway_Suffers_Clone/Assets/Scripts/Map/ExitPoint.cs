using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           // transform.parent.transform.GetComponent<Map>().SpawnObstacle();
            transform.parent.gameObject.SetActive(false);

        }
    }
}
