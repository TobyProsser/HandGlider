using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChilCoinSpawner : MonoBehaviour
{
    public List<GameObject> coinShape = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoins());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnCoins(float xVal)
    {
        Vector2 spawnPos = new Vector2(xVal, Random.Range(-7, 7));
        GameObject curCoinShape = Instantiate(coinShape[Random.Range(0, coinShape.Count)], spawnPos, Quaternion.identity);
    }


    IEnumerator spawnCoins()
    {
        float xCounter = 0;
        while (true)
        {
            float randX = Random.Range(30, 45);
            xCounter += randX;

            spawnCoins(xCounter);
            yield return new WaitForSeconds(1);
        }
    }
}
