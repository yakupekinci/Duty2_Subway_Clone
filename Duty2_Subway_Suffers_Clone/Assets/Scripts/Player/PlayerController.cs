using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Transform[] healths;
    [SerializeField] private GameObject hltsRoots;
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private int health = 3;
    [SerializeField] private float _blinkDuration = 0.05f;
    [SerializeField] private float _shakeDuration = 0.2f;
    [SerializeField] private int blinkRepeatCount = 1;
    [SerializeField] private GameObject PowerArea;
    [SerializeField] private SkinnedMeshRenderer bodyrendereR;
    [SerializeField] private MeshRenderer headRendereR;
    private UIManager uIManager;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        healths = hltsRoots.GetComponentsInChildren<Transform>();
        uIManager = FindObjectOfType<UIManager>();
    }
    public void TakeDamage()
    {
        health--;
        ShakeAndStop();
        RemoveHearth(health + 1);
        if (health > 0)
            StartCoroutine(BlinkCharacter());
        PowerArea.SetActive(true);
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator BlinkCharacter()
    {
        if (bodyrendereR == null)
            yield break;

        yield return new WaitForSeconds(_shakeDuration);
        for (int i = 0; i < blinkRepeatCount; i++)
        {

            bodyrendereR.enabled = false;
            headRendereR.enabled = false;
            yield return new WaitForSeconds(_blinkDuration);

            bodyrendereR.enabled = true;
            headRendereR.enabled = true;
            yield return new WaitForSeconds(_blinkDuration);
        }
        bodyrendereR.enabled = true;
        headRendereR.enabled = true;
    }

    private void WaitForLastHeart()
    {
        playerMovement._animator.SetBool("isRunning", false);
        playerMovement._gameManager.isStarted = false;
    }

    private void ShakeAndStop()
    {
        transform.DOShakePosition(_shakeDuration, 1, 90);
        playerMovement.ResetMovement();
    }

    private IEnumerator Die()
    {
        WaitForLastHeart();
        yield return new WaitForSeconds(2f);
        uIManager.DeadPanel();


    }

    private void RemoveHearth(int i)
    {
        Sequence sequence = DOTween.Sequence();
        if (health >= 0)
        {
            sequence.Append(healths[healths.Length - i].transform.DOScale(Vector3.zero, 0.2f)).SetEase(Ease.InOutCirc);
            sequence.Append(healths[healths.Length - i].transform.DOScale(new Vector3(1, 1, 1), 0.2f)).SetEase(Ease.InOutCirc);
            sequence.Append(healths[healths.Length - i].transform.DOMoveY(-2000, 2.5f));
        }
    }
}
