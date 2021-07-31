using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static bool dead;
    public static int lastScore;

    private void Awake()
    {
        dead = false;
        lastScore = 0;
    }

    void Start()
    {
        StartCoroutine(ScoreCounter());
    }

    private void Update()
    {
        scoreText.text = lastScore.ToString();
    }

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (dead) break;
            else
            {
                lastScore++;
                scoreText.text = lastScore.ToString();
            }
        }
    }
}
