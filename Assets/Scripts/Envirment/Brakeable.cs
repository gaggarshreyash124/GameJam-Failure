using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakeable : MonoBehaviour,Idamageable
{
    public float Health;
    public float MaxHealth = 20;

    private void Start()
    {
        Health = MaxHealth;
    }
    public void TakeDamage(float Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }

    }

      
    
}
