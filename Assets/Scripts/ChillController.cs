using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChillController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public static int lastChillScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        lastChillScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = lastChillScore.ToString();
    }
}
