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

    void Start()
    {
        if (liveImage != null && liveSprites.Length > 3)
        {
            liveImage.sprite = liveSprites[3];
        }
        else
        {
            Debug.LogError("LiveImage or LiveSprites not set properly in the inspector or liveSprites array length is insufficient.");
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + 0;
        }
        else
        {
            Debug.LogError("ScoreText not set in the inspector.");
        }
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
    }
}
