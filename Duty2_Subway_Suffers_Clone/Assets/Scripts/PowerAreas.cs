using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class PowerAreas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Gold"))
        {
            GameObject obj = other.transform.parent.gameObject;
            other.transform.SetParent(transform.parent);
            other.transform.DOLocalMove(Vector3.up, 0.3f).OnComplete(() =>
            {
                other.transform.GetComponent<Gold>().CollectGold();
                //other.transform.SetParent(obj.transform);
            });

        }
    }

}

