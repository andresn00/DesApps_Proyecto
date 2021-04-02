using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        ProcessHit(collision);
    }

    private void ProcessHit(Collider collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(collision);
        }
    }

    private void TakeDamage(Collider collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
