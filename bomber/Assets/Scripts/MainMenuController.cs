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
#if UNITY_STANDALONE_WIN
        int width = 480;
        int height = 800;
        bool isFullScreen = false;
        int desiredFPS = 60;

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
#endif

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
