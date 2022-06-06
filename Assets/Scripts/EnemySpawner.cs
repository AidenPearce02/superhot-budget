using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawner : MonoBehaviour
{
    readonly float spawnY = 0.5f;
    
    readonly float spawnVX = 3.5f;
    readonly float spawnVZL = -18f;
    readonly float spawnVZR = 26f;

    readonly float spawnHZ = -3.5f;
    readonly float spawnHXU = -28f;
    readonly float spawnHXD = 18f;

    public GameObject enemy;
    GameObject player;
    public Text WaveText;

    int level = 1;
    bool isNewLevel = true; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Avatar");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Health>().isDead())
        {
            WaveText.text = "You survived: " + level + " waves";
        }
        else if(level == 9)
        {
            Time.timeScale = 0;
            WaveText.text = "You win";
        }
        else if (isNewLevel == true)
        {
            for (int i = 0; i < level; i++)
            {
                Instantiate(enemy, new Vector3(spawnVX - 2.5f * i, spawnY, spawnVZL), Quaternion.identity, transform);
                Instantiate(enemy, new Vector3(spawnVX - 2.5f * i, spawnY, spawnVZR), Quaternion.identity, transform);
                Instantiate(enemy, new Vector3(spawnHXU, spawnY, spawnHZ + 2.5f * i), Quaternion.identity, transform);
                Instantiate(enemy, new Vector3(spawnHXD, spawnY, spawnHZ + 2.5f * i), Quaternion.identity, transform);
            }
            WaveText.text = "Wave: " + level;
            isNewLevel = false;
        }
        else if(transform.childCount == 0)
        {
            isNewLevel = true;
            level++;
        }

    }
}
