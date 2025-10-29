using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Data", menuName = "Gun Data")]
public class GunData : ScriptableObject
{
    public float bulletSpeed;
    public float bulletDamage = 10;
    public float BulletKnockback;
    public float bulletLifeTime;
}
