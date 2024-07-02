using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static int enemyCount;
    public GameObject[] enemies;

    [HideInInspector] private Timer spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer.timeLeft == 0)
        {
            int enemyIdx = Random.Range(0, enemies.Length);
            SpawnEnemy(enemies[enemyIdx]);
            enemyCount += 1;
            spawnTimer.StartTimer();
        }
    }

    public void SpawnEnemy(GameObject enemy)
    {
        float angle = Mathf.Deg2Rad * Random.Range(0, 360);
        GameObject newEnemy = Instantiate(enemy, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * 15f, Quaternion.identity);
    }
}
