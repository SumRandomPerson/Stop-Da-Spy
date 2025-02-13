using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private GameObject player;
    private int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        player = GameObject.Find("Player");
        enemyAgent.destination = player.transform.position;
        if(hp <=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(gameObject + " Took " + damage + " Damage");
    }
}
