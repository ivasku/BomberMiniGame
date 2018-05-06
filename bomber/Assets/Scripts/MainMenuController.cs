using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        GetScore();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void StartButton()
    {
        SceneManager.LoadScene("game");
    }

    public void Exitbutton()
    {
        Application.Quit();
    }

    public int GetScore()
    {
        float score = PlayerPrefs.GetFloat("score");
        scoreText.text = ((int)score).ToString();
        return (int)score;
    }
}
