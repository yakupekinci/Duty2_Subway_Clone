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

            PowerAreas powerAreas = other.GetComponentInChildren<PowerAreas>(true);
            if (powerAreas != null)
            {            
                powerAreas.gameObject.SetActive(true);
                StartCoroutine(PowerAreaTimer(powerAreas.gameObject));
            }
            else
            {

            }

            Destroy(gameObject);
        }
    }
    IEnumerator PowerAreaTimer(GameObject gameObject)
    {
        yield return new WaitForSeconds(maxTimer);
        gameObject.SetActive(false);

    }


}



