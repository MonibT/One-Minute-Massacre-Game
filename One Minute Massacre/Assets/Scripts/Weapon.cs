using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bulletprefab;
    public AudioSource GunSound;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }

        void Shoot()
        {
            GunSound.Play();
            Instantiate(bulletprefab, firePoint1.position, firePoint1.rotation);
            Instantiate(bulletprefab, firePoint2.position, firePoint2.rotation);
        }
    }
}
