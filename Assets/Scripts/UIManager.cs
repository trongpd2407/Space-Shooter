using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private Image liveImage;
    [SerializeField]
    private Sprite[] liveSprites;

    [SerializeField]
    private TMP_Text gameOverText;

    [SerializeField]
    private TMP_Text restartText;

    private GameManager gameManager;

    void Start()
    {
        liveImage.sprite = liveSprites[3];
        gameOverText.gameObject.SetActive(false);
        restartText.gameObject.SetActive(false);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int updatedScore)
    {
        scoreText.text = "Score: " + updatedScore.ToString();
    }
    public void UpdateLiveSprite(int currentLive)
    {
        liveImage.sprite = liveSprites[currentLive];

        if(currentLive < 1)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        gameManager.GameOver();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlick());
    }
    IEnumerator GameOverFlick()
    {
        while(true)
        {
            gameOverText.text = "Game Over";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
        

    }
}
