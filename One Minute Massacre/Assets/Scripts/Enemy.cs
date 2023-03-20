using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CircleCollider2D coll;
    public Transform target;
    public float speed = 3f;
    private Animator anim;
    public int Enemypoints = 1;
    public float rotateSpeed = 0.008f;
    private Rigidbody2D rb;
    private PlayerLife player;
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 20;
    private killsScript kills;
    public AudioSource deathsound;

    public void Start()
    {
        coll = GetComponent<CircleCollider2D>();
        kills = GameObject.FindWithTag("Score").GetComponent<killsScript>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

        }
    }
    private void RotateTowardsTarget()
    {

        Vector2 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerLife player = collision.collider.GetComponent<PlayerLife>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        target = null;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
       
        //DamageSound.Play();

        if (currentHealth <= 0)
        {
            EnemyDie();
            deathsound.Play();
            kills.IncrementKillCount(Enemypoints);
        }
    }

    void EnemyDie()
    {
        speed = 0f;
        coll.enabled = false;
        anim.SetTrigger("death");
        Destroy(gameObject, 0.5f);
        rb.bodyType = RigidbodyType2D.Static;
    }

}
