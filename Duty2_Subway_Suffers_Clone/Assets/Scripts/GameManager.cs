using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStarted;
    private UIManager uIManager;
    private void Start()
    {
        isStarted = false;
        uIManager = FindObjectOfType<UIManager>();
    }
    public void StartBtn()
    {
        isStarted = true;
        uIManager.StartScoreTxt();
    }
}
