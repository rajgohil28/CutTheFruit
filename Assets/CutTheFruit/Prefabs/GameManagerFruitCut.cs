using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerFruitCut : MonoBehaviour
{
    public Text ScoreText;
    public GameObject GameOverPanel;

    [Header("Audios")]
    public AudioSource VegetableCutAudio;

    [Header("Combos")]
    public GameObject m_ThreeComboText;
    public GameObject m_FourComboText;
    
    private int m_score;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        m_score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
    public void AddScore()
    {
        m_score++;
        ScoreText.text = m_score.ToString();
    }
    public void GameOver()
    {
        FindObjectOfType<FruitSpawner>().StopSpawning();
        VegetableCutAudio.Play();
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name); 
    }
    public void ThreeFruitCombo()
    {
        m_score = m_score + 2;
        StartCoroutine(ShowThreeComboText());
    }
    IEnumerator ShowThreeComboText()
    {
        m_ThreeComboText.SetActive(true);
        yield return new WaitForSeconds(3f);
        m_ThreeComboText.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");
        GameObject[] vegetables = GameObject.FindGameObjectsWithTag("Vegetable");
        foreach (GameObject fruit in fruits)
        {
            Destroy(fruit);
        }
        foreach (GameObject vegetable in vegetables)
        {
            Destroy(vegetable);
        }
        GameOverPanel.SetActive(false);
        m_score = 0;
        ScoreText.text = m_score.ToString();

    }
    public void Quit()
    {
        Application.Quit();
    }
}
