using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public int spawnDistance;
    [SerializeField] GameObject player;
    public int maxEnemyCount;

    List<GameObject> enemies = new List<GameObject>();

    //playground area
    float minX = -16.22f;
    float maxX = 19.88f;
    float minZ = -17.74f;
    float maxZ = 20.23f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while(enemies.Count < maxEnemyCount)
        {
            spawnEnemy();
        }
    }

    void spawnEnemy()
    {
        //get enemy spawn position
        Vector3 spawnPosition = genspawnPosition();

        //always use positions greater than spawnDistance
        if(Vector3.Distance(spawnPosition, player.transform.position) < spawnDistance)
        {
            spawnPosition = genspawnPosition();
        } else
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.AddComponent<enemyscript>();
            enemies.Add(enemy);
        }
    }

    //generate spawn position within play area
    Vector3 genspawnPosition()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), 2.98f, Random.Range(minZ, maxZ));
        return spawnPosition;
    }
}
