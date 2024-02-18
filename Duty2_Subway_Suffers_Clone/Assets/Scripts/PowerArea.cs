using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Collider[] cl = other.gameObject.GetComponents<Collider>();
            foreach (var cld in cl)
            {
                cld.enabled = false;
                StartCoroutine(PowerAreaTimer(cl));
            }
            
        }
    }

    IEnumerator PowerAreaTimer(Collider[] colliders)
    {
        yield return new WaitForSeconds(3);
        foreach (var cld in colliders)
        {
            cld.enabled = true;
        }
        gameObject.SetActive(false);
    }
}

