using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class enemyscript : MonoBehaviour
{
    GameObject player;
    NavMeshAgent enemy;
    enemyManager enemyManager;
    [SerializeField]int maxHealth;
    HUDscript HUDscript;
    playercontroller playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("player");
        playercontroller = player.GetComponent<playercontroller>();
        enemy = GetComponent<NavMeshAgent>();
        enemyManager = GameObject.FindWithTag("eManager").GetComponent<enemyManager>();
        HUDscript = GameObject.FindWithTag("hud").GetComponent<HUDscript>();
    }

    // Update is called once per frame
    void Update()
    {
        //move to player
        enemy.SetDestination(player.transform.position);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "magicBlast")
        {
            maxHealth -= 10;

            if (maxHealth <= 0)
            {
                playercontroller.updateScore();
                enemyManager.isDestroyed();
                Destroy(gameObject);
            }
        }
    }
}

