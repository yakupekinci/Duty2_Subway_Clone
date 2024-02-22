using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Gold : MonoBehaviour
{
    private UIManager uiManager;
    public GoldSO goldSO;
    Vector3 sp;
    Transform parent;
    [SerializeField] private MeshRenderer render;

    void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    
    }
    private void Start()
    {
        sp = transform.localPosition;
        parent=transform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            CollectGold();
        }
    }

    public void CollectGold()
    {
        render.enabled = false;
        StartCoroutine(DisableGoldAfterDelay(7));
        if (goldSO != null)
        {
            goldSO.goldAmount++;
            uiManager.GoldText(goldSO.goldAmount.ToString());
        }
    }
    public IEnumerator DisableGoldAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);
        transform.SetParent(parent);
        transform.position = sp;
        render.enabled = true;
        

    }
}
