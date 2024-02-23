using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text Gold;

    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject MagnetPnl;
    [SerializeField] TMP_Text recordedScore;
    [SerializeField] TMP_Text recordedHScore;

    private int score = 0;
    private int highScore = 20;


    private void Start()
    {
        DeathPanel.SetActive(false);
        GameUI.SetActive(false);
        MenuUI.SetActive(true);
        Gold.text = "" + 0;
        Score.text = "" + 0;
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
    }
    public void StartGame()
    {
        GameUI.SetActive(true);
        DeathPanel.SetActive(false);
    }
    public void GoldText(string gold)
    {
        Gold.text = gold;
        score += 1 * 5;
        Score.text = score.ToString();
        CheckHighScore();
    }
    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);

            Score.color = Color.red;
            if (Score.transform != null)
            {
                Sequence sequence = DOTween.Sequence();
                sequence.Append(Score.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f)).SetEase(Ease.Linear);
                sequence.Append(Score.transform.DOScale(new Vector3(0.75f, .75f, .75f), 0.2f)).SetEase(Ease.Linear);
                sequence.Append(Score.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.2f)).SetEase(Ease.Linear);
                sequence.Append(Score.transform.DOScale(new Vector3(0.75f, .75f, .75f), 0.2f)).SetEase(Ease.Linear);
            }
        }
    }

    IEnumerator IncreaseScore()
    {
        score += 1;
        Score.text = score.ToString();
        yield return new WaitForSeconds(0.5f);
        CheckHighScore();
        StartCoroutine(IncreaseScore());
    }

    public void StopScoreTxt()
    {
        StopCoroutine(IncreaseScore());
    }
    public void StartScoreTxt()
    {
        StartCoroutine(IncreaseScore());
    }

    public void DeadPanel()
    {
        recordedScore.text = Score.text;
        recordedHScore.text = highScore + "";
        DeathPanel.SetActive(true);
        GameUI.SetActive(false);
        MenuUI.SetActive(false);
    }
    public void Restart_BTN()
    {
        SceneManager.LoadScene(0);
    }


    private float timers = 0f;
    public void MagnetPanel()
    {
        MagnetPnl.SetActive(true);
        timers += Time.deltaTime;
        if (timers > 15)
        {
            MagnetPnl.SetActive(false);
            timers = 0;
        }
    }

}
