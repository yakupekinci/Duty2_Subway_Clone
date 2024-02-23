using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class Magnet : MonoBehaviour
{
    private UIManager uIManager;
    float maxTimer = 10f;
    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            PowerAreas powerAreas = other.GetComponentInChildren<PowerAreas>(true);
            if (powerAreas != null)
            {
                uIManager.MagnetPanel();
                powerAreas.gameObject.SetActive(true);
                StartCoroutine(PowerAreaTimer(powerAreas.gameObject));
            }
            else
            {

            }

            transform.localScale = Vector3.zero;
        }
    }
    IEnumerator PowerAreaTimer(GameObject gameObject)
    {
        yield return new WaitForSeconds(maxTimer);
        gameObject.SetActive(false);

    }


}



