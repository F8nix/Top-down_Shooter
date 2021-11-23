using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variables
    public GameObject[] enemiesPrefabs;
    //spawning variables
    public float spawnCounter = 0.0f;
    public float counterFix = 0.0f;
    public float enemySpawnTime1 = 10.0f;
    private int enemyAlreadySpawned1 = 0;

    public float enemySpawnTime2 = 50.0f;
    private int enemyAlreadySpawned2 = 0;

    public float enemySpawnTime3 = 75.0f;
    public float musicSpawnTime = 750.0f;
    //Enemy class
    public class Enemy {
        public float xPos;
        public float yPos;
        public float zPos;
        public int index;
        //enemy constructor
        public Enemy(float xPosition, float yPosition, float zPosition, int enemyIndex) {
            xPos = xPosition;
            yPos = yPosition;
            zPos = zPosition;
            index = enemyIndex;
        }
    }
    //Enemy firstEnemy = new Enemy();
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawning counter
        counterFix += 1 * Time.deltaTime;
        if (counterFix >= 0.1f)
        {
            spawnCounter += 1.0f;
            counterFix -= 0.1f;
        }
        //spawning enemy1 and so on
        if (spawnCounter == enemySpawnTime1 && enemyAlreadySpawned1 == 0) {
            SpawnEnemy1();
            enemyAlreadySpawned1 = 1;
        }
        if (spawnCounter == enemySpawnTime2 && enemyAlreadySpawned2 == 0)
        {
            SpawnEnemy2();
            enemyAlreadySpawned2 = 1;
            enemyAlreadySpawned1 = 0;
        }
        if (spawnCounter == enemySpawnTime3 && enemyAlreadySpawned1 == 0)
        {
            SpawnEnemy3();
            enemyAlreadySpawned1 = 1;
            enemyAlreadySpawned2 = 0;
        }
        if (spawnCounter == musicSpawnTime && enemyAlreadySpawned2 == 0)
        {
            SpawnMusic();
            enemyAlreadySpawned2 = 1;
        }
    }
    //dream about good ONE spawning method
    void SpawnEnemy1()
    {
        Enemy enemy1 = new Enemy(507, 100, 265, 0);
        Vector3 spawnPos = new Vector3(enemy1.xPos, enemy1.yPos, enemy1.zPos);
        Instantiate(enemiesPrefabs[enemy1.index], spawnPos, enemiesPrefabs[enemy1.index].transform.rotation);
    }
    void SpawnEnemy2()
    {
        Enemy enemy2 = new Enemy(368, 100, 345, 1);
        Vector3 spawnPos = new Vector3(enemy2.xPos, enemy2.yPos, enemy2.zPos);
        Instantiate(enemiesPrefabs[enemy2.index], spawnPos, enemiesPrefabs[enemy2.index].transform.rotation);
    }
    void SpawnEnemy3()
    {
        Enemy enemy3 = new Enemy(460, 100, 432, 2);
        Vector3 spawnPos = new Vector3(enemy3.xPos, enemy3.yPos, enemy3.zPos);
        Instantiate(enemiesPrefabs[enemy3.index], spawnPos, enemiesPrefabs[enemy3.index].transform.rotation);
    }
    void SpawnMusic()
    {
        Enemy Music = new Enemy(0, 0, 0, 3);
        Vector3 spawnPos = new Vector3(Music.xPos, Music.yPos, Music.zPos);
        Instantiate(enemiesPrefabs[Music.index], spawnPos, enemiesPrefabs[Music.index].transform.rotation);
        Debug.Log("Timed and made poorly");
    }

}
