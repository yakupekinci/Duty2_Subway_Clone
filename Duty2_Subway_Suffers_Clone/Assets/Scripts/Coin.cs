using UnityEngine;
using DG.Tweening;


public class Coin : MonoBehaviour
{

    void Start()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), 10f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental) // Sonsuz döngü
            .SetEase(Ease.Linear); // Dönüş hızını ayarla, örneğin Lineer eğri
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

}
