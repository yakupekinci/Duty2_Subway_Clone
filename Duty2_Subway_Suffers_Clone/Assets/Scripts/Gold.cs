using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Gold : MonoBehaviour
{
    private UIManager uiManager;
    public GoldSO goldSO;
    [SerializeField] private MeshRenderer render;

    void Awake()
    {

        uiManager = FindObjectOfType<UIManager>();
        goldSO.goldAmount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectGold();
        }
    }

    private void CollectGold()
    {
        render.enabled = false;
        StartCoroutine(DisableGoldAfterDelay(3));
        if (goldSO != null)
        {
            goldSO.goldAmount++;
            uiManager.GoldText(goldSO.goldAmount.ToString());
        }
    }
    private IEnumerator DisableGoldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        render.enabled = true;

    }
}
