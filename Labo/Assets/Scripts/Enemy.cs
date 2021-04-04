using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Config
    [SerializeField] float health = 100f;
    [SerializeField] float scoreOfEnemy = 10;
    [SerializeField] float speed;

    //Other
    GameObject player;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        if (player)
        {
            Vector3 target = player.transform.position;
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        }
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
