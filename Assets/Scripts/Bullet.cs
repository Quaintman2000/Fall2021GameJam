using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Stores how much damage certain types of damage would do.
    [Tooltip("How much damage this bullet will do vs Plastic.")]
    public float plasticDamage;
    [Tooltip("How much damage this bullet will do vs Paper.")]
    public float paperDamage;
    [Tooltip("How much damage this bullet will do vs Food.")]
    public float foodDamage;

    public GameObject hitEffect;
    public float speed = 60f;
    Transform target;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check to see if they have DebrisHealth script.
        if(collision.gameObject.GetComponent<DebrisHealth>())
        {
            float damage = 0;
            // Give the appropriate amount of damage.
            if(collision.gameObject.GetComponent<DebrisHealth>().debrisType == DebrisHealth.DebrisType.Plastic)
            {
                damage = plasticDamage;
            }
            else if (collision.gameObject.GetComponent<DebrisHealth>().debrisType == DebrisHealth.DebrisType.Paper)
            {
                damage = paperDamage;
            }
            else if(collision.gameObject.GetComponent<DebrisHealth>().debrisType == DebrisHealth.DebrisType.Food)
            {
                damage = foodDamage;
            }
            else
            {
                
                Debug.LogError("Debris type has not been set for: " + collision.gameObject.name);
            }
            collision.gameObject.GetComponent<DebrisHealth>().TakeDamage(damage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

   
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
}

   