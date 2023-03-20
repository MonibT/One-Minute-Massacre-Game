using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int Bulletdamage = 30;
    public float speed = 20f;
    
    public GameObject impactEffect;
    

    // Start is called before the first frame update
    public void Start()
    {
        if (GameManager.instance != null)
        {
            Bulletdamage = GameManager.instance.Bulletdamage;
        }
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Bulletdamage);
            GameObject Effect = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(Effect, 1f);
            Destroy(gameObject);
        }
        else if (hitInfo.gameObject.CompareTag("Boundys"))
        {
            GameObject Effect = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(Effect, 1f);
            Destroy(gameObject);
        }
    }

    
}

