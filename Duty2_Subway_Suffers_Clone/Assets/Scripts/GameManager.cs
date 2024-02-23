using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    private UIManager uIManager;
    private PlayerMovement playerMovement;
    public GoldSO goldSO;
    private void Start()
    {
        DOTween.Clear();
        isStarted = false;
        uIManager = FindObjectOfType<UIManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        goldSO.goldAmount = 0;
    }
    public void StartBtn()
    {
        isStarted = true;
        uIManager.StartScoreTxt();
        uIManager.StartGame();
        playerMovement.Startnvoke();

    }
}
