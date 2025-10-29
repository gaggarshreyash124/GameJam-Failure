using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerData playerData;
    public GunData gunData;
    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        rb.velocity = gunData.bulletSpeed * transform.right;
        Destroy(this.gameObject, gunData.bulletLifeTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Idamageable>() != null)
        {
            other.gameObject.GetComponent<Idamageable>().TakeDamage(gunData.bulletDamage);
        }
    }
}
