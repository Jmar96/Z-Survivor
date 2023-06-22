using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreTxtBox;
    [SerializeField]
    Text highScoreTxtBox;
    float score = 0f;
    float highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore = ((int)PlayerPrefs.GetFloat("highScore"));
    }

    // Update is called once per frame
    void Update()
    {
        highScoreTxtBox.text = highScore.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", score);
        }
    }
    public void AddScore()
    {
        score += 1;
        scoreTxtBox.text = score.ToString();

    }
}
