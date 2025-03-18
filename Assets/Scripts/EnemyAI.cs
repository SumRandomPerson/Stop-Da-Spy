using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private GameObject player;
    private int hp = 10;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.Play("Movement.Walk");
    }

    void Update()
    {
        Debug.Log(enemyAgent.velocity);
        if(enemyAgent.velocity.x != 0)
        {
            anim.SetBool("Static_b", true);
            anim.SetFloat("Speed_f", 1);
        }else
        {
            anim.SetBool("Static_b", false);
            anim.SetFloat("Speed_f", 0);
        }
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
