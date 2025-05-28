using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int damage = 2;
    private float speed = 50f;
    private TimeManager time;
    public GameObject collider;
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
        collider.SetActive(true);
        
    }
    
    void Update()
    {
        //allows bullets to move regardless of stopped time for a short while after creation
        if(delayed == false)
        {
            if(time.isStopped == false)
            {
                transform.Translate(Vector3.forward*speed * Time.deltaTime);
            }
        }else{
            transform.Translate(Vector3.forward*speed * Time.deltaTime);
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
            speed = 0;
            DealDamageTo(other.gameObject);
            gameObject.transform.SetParent(other.gameObject.transform);
            Debug.Log("hit");
        }
        
    }
   
    
}
