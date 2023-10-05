using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    public int spawnDistance; //in meters
    [SerializeField] GameObject player;
    playercontroller playercontroller;
    Camera mainCamera;
    Vector3 originalCameraPosition;
    float shakeMagnitude;
    public int maxEnemyCount;
    int currentEnemyCount = 0;
    float timer;

    //playground area
    float minX = -16.22f;
    float maxX = 19.88f;
    float minZ = -17.74f;
    float maxZ = 20.23f;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = player.GetComponent<playercontroller>();
        mainCamera = playercontroller.mainCamera;
        originalCameraPosition = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (currentEnemyCount < maxEnemyCount)
        {
            if(timer > 10f && timer < 30f)
            {
                maxEnemyCount = 15;
                spawnDistance -= 5;
                spawnEnemy(enemy2);
                spawnEnemy(enemy1);
            } else if(timer > 30f)
            {
                maxEnemyCount = 30;
                spawnDistance -= 3;
                spawnEnemy(enemy2);

                //shake camera TODO...
                
            } else
            {
                spawnEnemy(enemy1);
            }
        }
    }

    void spawnEnemy(GameObject enemyVariant)
    {
        //get enemy spawn position
        Vector3 spawnPosition = genspawnPosition();

        //always use positions greater than spawnDistance
        if(Vector3.Distance(spawnPosition, player.transform.position) < spawnDistance)
        {
            spawnPosition = genspawnPosition();
        } else
        {
            GameObject enemy = Instantiate(enemyVariant, spawnPosition, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    //generate spawn position within play area
    Vector3 genspawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 2.98f, Random.Range(minZ, maxZ));
        return spawnPosition;
    }

    public void isDestroyed()
    {
        currentEnemyCount--;
    }
}
