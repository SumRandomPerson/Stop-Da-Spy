using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage = 2;
    private TimeManager time;
    private bool delayed = true;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyProjectile");
        StartCoroutine("DelayFreeze");
        time = GameObject.Find("Game Manager").GetComponent<TimeManager>();
       
        
    }
    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(16);
        Destroy(gameObject);
    }
    IEnumerator DelayFreeze()
    {
        yield return new WaitForSeconds(0.1f);
        delayed = false;
        
    }
    void Update()
    {
        //allows bullets to move regardless of stopped time for a short while after creation
        if(delayed == false)
        {
            if(time.isStopped == false)
            {
                transform.Translate(Vector3.forward*50 * Time.deltaTime);
            }
        }else{
            transform.Translate(Vector3.forward*50 * Time.deltaTime);
        }
       
        
    }

    public void DealDamageTo(GameObject enemy)
    {   
        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        ai.TakeDamage(damage);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")&&time.isStopped == false)
        {
            DealDamageTo(other.gameObject);
            Destroy(gameObject);
            Debug.Log("hit");
        }
        
    }
    
}
