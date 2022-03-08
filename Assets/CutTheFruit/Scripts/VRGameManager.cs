using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
public class VRGameManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    private int Score;
    private int lives = 2;
    private XRInteractorLineVisual[] LineVisual;
    
    [Header("Audios")]
    public AudioSource LifeDeductAudio;
    [Header("Lives Cross Images")]
    public GameObject[] CrossesImage;
    [Header("GameOver Panel")]
    public GameObject GameOverPanel;

    private void Start()
    {
        ScoreText.text = "0";
        Score = 0;
        LineVisual = FindObjectsOfType<XRInteractorLineVisual>();
        foreach (XRInteractorLineVisual line in LineVisual)
        {
            line.enabled = false;
        }
        for (int i = 0; i < CrossesImage.Length; i++)
        {
            CrossesImage[i].SetActive(false);
        }
    }
    public void IncreaseScore()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
    public void DecreaseLife()
    {
        CrossesImage[lives].SetActive(true);
        LifeDeductAudio.Play();
        lives--;       
        if(lives < 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        GameObject[] Fruits = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (GameObject fruit in Fruits)
        {
            Destroy(fruit);
        }
        foreach (XRInteractorLineVisual line in LineVisual)
        {
            line.enabled = true;
        }
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        GameOverPanel.SetActive(false);
        lives = 2;
        for (int i = 0; i < CrossesImage.Length; i++)
        {
            CrossesImage[i].SetActive(false);
        }
        foreach (XRInteractorLineVisual line in LineVisual)
        {
            line.enabled = false;
        }
        Score = 0;
        ScoreText.text = Score.ToString();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
