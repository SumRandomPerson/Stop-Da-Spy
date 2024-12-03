using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage = 2;
    // Start is called before the first frame update
    void Start()
    {

        
    }
    void Update()
    {
        transform.Translate(Vector3.forward*15 * Time.deltaTime);
    }
    public void DealDamageTo(GameObject enemy)
    {   
        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        ai.TakeDamage(damage);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            DealDamageTo(other.gameObject);
            Destroy(gameObject);
            Debug.Log("hit");
        }
        
    }
}
