using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject lastEnemy;
    public GameObject prefabEnemy;
    public float enemyCount;

    private Rect rectSpawn;
    private bool enemySpawner;
    private float randomX;
    private float randomY;

    void Start()
    {
        enemySpawner = true;
        rectSpawn = Rect.MinMaxRect(0, 0, 4, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawner)
        {
            float randomX = Random.Range(rectSpawn.xMin, rectSpawn.xMax);
            float randomY = Random.Range(rectSpawn.yMin, rectSpawn.yMax);
            lastEnemy = Instantiate(prefabEnemy, new Vector3(randomX, randomY, 0), new Quaternion().normalized);
            enemySpawner = false;
            
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            enemySpawner = true;
        }

    }
    public void AddEnemy()
    {
        enemyCount += 1;
    }
}
