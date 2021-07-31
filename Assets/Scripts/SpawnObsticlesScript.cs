using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticlesScript : MonoBehaviour
{
    public GameObject RockSpike;
    public GameObject FireBall;
    public GameObject Cloud;
    public GameObject BlueFire;

    public GameObject Coin;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FloorObsticles());
        StartCoroutine(Projectiles());
    }

    /*
    IEnumerator FloorObsticles()          //Spawning Base on time
    {
        float xCounter = 0;
        while (true)
        {
            float randX = Random.Range(30, 45);
            xCounter += randX;

            Vector2 spawnPos = new Vector2(randX + xCounter, -3.69f);
            GameObject curRockSpike = Instantiate(RockSpike, spawnPos, Quaternion.identity); //Randomly choose between rock Spike and water spout

            yield return new WaitForSeconds(1);
        }
    }
    */

    private void SpawnCloud(float xVal)
    {
        Vector2 spawnPos = new Vector2(Random.Range(-15, 15) + xVal, Random.Range(0, 6));
        GameObject curCloud = Instantiate(Cloud, spawnPos, Quaternion.identity);

        float size = Random.Range(1, 2.35f);
        curCloud.transform.localScale = new Vector2(size, size);
    }

    private void SpawnCoin(float xVal)
    {
        int chance = Random.Range(0, 4);
        if (chance == 0)
        {
            Vector2 spawnPos = new Vector2(Random.Range(15, 25) + xVal, Random.Range(-4.5f, 5));
            GameObject curCoin = Instantiate(Coin, spawnPos, Quaternion.identity);
        }
    }

    IEnumerator FloorObsticles()           //spawning based on players distance to next obsitcle
    {
        float randX;
        while (true)
        {
            randX = Player.transform.position.x + Random.Range(30, 90);
            Vector3 spawnPos = new Vector3(randX, -3.69f);
            GameObject curRockSpike = Instantiate(RockSpike, spawnPos, Quaternion.identity); //Randomly choose between rock Spike and water spout

            //SpawnCloud(randX);
            SpawnCoin(randX);

            while (Player.transform.position.x < randX)
            {
                if (Player.transform.position.x < randX)
                {
                    yield return null;
                }
                else
                {
                    break;
                }
            }

            yield return null;
        }
    }

    IEnumerator Projectiles()
    {
        int blueCounter = 0;
        int blueMatch = 4;
        while (true)
        {
            float randTime = Random.Range(2.5f, 6);
            yield return new WaitForSeconds(randTime);

            if (blueCounter > 1)
            {
                blueMatch = Random.Range(2, 5);
                blueCounter = 0;

                Vector3 spawnPos = new Vector3(Player.transform.position.x + 24, 10, -7);
                GameObject curBlueBall = Instantiate(BlueFire, spawnPos, Quaternion.identity);
            }
            else
            {
                float randY = Random.Range(0, 7);
                Vector3 spawnPos = new Vector3(Player.transform.position.x + 20, randY, -7);
                GameObject curFireBall = Instantiate(FireBall, spawnPos, Quaternion.identity); //Randomly choose between fireball and waterball
            }

            AudioManager.instance.Play("FireBall");

            blueCounter++;
        }
    }
}

