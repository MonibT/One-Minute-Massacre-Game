using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MachineGun : MonoBehaviour
{
    public AudioSource GunSound;
    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public float fireRate = 0.1f;
    public Slider firingCooldownSlider;
    private bool isFiring = false;
    private bool onCooldown = false;

    void Start()
    {
        firingCooldownSlider.maxValue = 5f;
        firingCooldownSlider.value = 5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !onCooldown)
        {
            StartCoroutine(FireBullets());
        }
    }

    IEnumerator FireBullets()
    {
        isFiring = true;
        onCooldown = true;

        float timeFired = 0f;
        bool useFirePoint1 = true;
        while (timeFired < 5f)
        {
            if (useFirePoint1)
            {
                GunSound.Play();

                Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            }
            else
            {
                GunSound.Play();

                Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            }

            useFirePoint1 = !useFirePoint1;

            timeFired += fireRate;

            firingCooldownSlider.value -= fireRate;

            yield return new WaitForSeconds(fireRate);
        }

        isFiring = false;

        float timeOnCooldown = 0f;
        while (timeOnCooldown < 10f)
        {
            timeOnCooldown += Time.deltaTime;

            firingCooldownSlider.value += Time.deltaTime / 2f;

            yield return null;
        }

        onCooldown = false;
    }
}
