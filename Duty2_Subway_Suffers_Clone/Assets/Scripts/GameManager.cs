using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStarted;

    private void Start()
    {
        isStarted = false;
    }
    public void StartBtn()
    {
        isStarted = true;
        
    }
}
