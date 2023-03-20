using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    public int maxHealth = 100;
    public int currentHealth;
    public int TrapDamage = 50;
    public HealthBar healthBar;
    public AudioSource deathsound;
    public AudioSource DamageSound;

    void Start()
    {
        // Update moveSpeed value based on GameManager moveSpeed value

        currentHealth = maxHealth;
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Traps"))
    //    {
    //        TakeDamage(TrapDamage);

    //    }

    //}
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        DamageSound.Play();

        if (currentHealth <= 0)
        {
            
            Die();
        }

    }
    public void Die()
    {

        //coll.enabled = false;
        //rb.bodyType = RigidbodyType2D.Static;
        deathsound.Play();
        anim.SetTrigger("death");
        
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
