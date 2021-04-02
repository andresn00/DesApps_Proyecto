using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float scoreOfEnemy = 10;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
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
        gameSession.AddKillCount();
        gameSession.AddToScore(scoreOfEnemy);
        Destroy(gameObject);
    }

}
