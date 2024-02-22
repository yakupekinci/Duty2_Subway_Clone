using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class Magnet : MonoBehaviour
{
    float maxTimer = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            int objNum = other.gameObject.transform.childCount;
            GameObject powerAreas = other.transform.GetChild(objNum - 1).GetComponent<PowerAreas>().gameObject;
            powerAreas.SetActive(true);
            StartCoroutine(PowerAreaTimer(powerAreas));
            Destroy(gameObject);
        }
    }
    IEnumerator PowerAreaTimer(GameObject gameObject)
    {
        yield return new WaitForSeconds(maxTimer);
        gameObject.SetActive(false);

    }


}



