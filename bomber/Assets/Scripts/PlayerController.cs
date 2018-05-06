using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public GameObject endGamePanel;
    public GameObject DestroyBombsObject;
    public Text endScoreText;
    public Text HighScore;

    private float minX = -2.5f;
    private float maxX = 2.5f;

    // Use this for initialization
    void Start () {
#if UNITY_STANDALONE_WIN 
        int width = 480; 
        int height = 800; 
        bool isFullScreen = false; 
        int desiredFPS = 60;

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
#endif
    }

    // Update is called once per frame
    void Update () {
        Move();
	}

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");        
        Vector2 tempPosition = this.gameObject.transform.position;

#if UNITY_ANDROID || UNITY_IOS && !UNITY_EDITOR
        if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2) {
            tempPosition.x += speed * Time.deltaTime;     
        }

        if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2) {
            tempPosition.x -= speed * Time.deltaTime;     
        }
#else
        if (h > 0)
        {
            // goind right
            tempPosition.x += speed * Time.deltaTime;            
        }
        else if (h < 0)
        {
            // goind left
            tempPosition.x -= speed * Time.deltaTime;            
        }
#endif

        if (tempPosition.x < minX)
        {
            tempPosition.x = minX;
        }

        if (tempPosition.x > maxX)
        {
            tempPosition.x = maxX;
        }        

        this.gameObject.transform.position = tempPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bomb")) {
            EndGame();
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        endGamePanel.SetActive(true);
        int score = DestroyBombsObject.GetComponent<DestroyBombs>().score;
        endScoreText.text = "Score: " + ((int)score).ToString();

        float scoreCurrent = PlayerPrefs.GetFloat("score");
        HighScore.text = "HighScore: " + ((int)scoreCurrent).ToString();
    }
   
}
