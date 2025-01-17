using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private GameObject player;
    private bool shotCooldown = false;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        enemyAgent.destination = player.transform.position;
        if(enemyAgent.remainingDistance < 100)
        {
            if(shotCooldown == false)
            {
                ShootProjectile();
                shotCooldown = true;
                StartCoroutine("ResetCooldown");
            }
           
        }
    }
     void ShootProjectile()
    {
        Instantiate(projectilePrefab,transform.position, Quaternion.LookRotation(player.transform.position-transform.position));
    }
     IEnumerator ResetCooldown()
    {
               
        yield return new WaitForSeconds(5);
        shotCooldown = false;
                
    }
}
