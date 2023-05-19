using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BULLET : MonoBehaviour 
{
    public float speed = 30f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float impactEffectLifetime = 1f;
    public AudioClip impactSound;
    public float impactSoundVolume = 0.5f;

    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (impactEffect != null)
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, impactEffectLifetime);
        }

        if (impactSound != null)
        {
            AudioSource.PlayClipAtPoint(impactSound, transform.position, impactSoundVolume);
        }

        //Destroy(gameObject);
    }
}
