using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBombs : MonoBehaviour {

    public Text scoreText;
    [HideInInspector]
    public int score;

    void Score()
    {
        score++;
        scoreText.text = "Score: " + score;
        updateHighScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bomb"))
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject, 0.2f);
            Score();
        }   
    }

    public void updateHighScore()
    {
        if (PlayerPrefs.GetFloat("score") < score)
        {
            PlayerPrefs.SetFloat("score", score);
        }
    }
}
