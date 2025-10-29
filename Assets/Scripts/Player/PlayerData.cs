using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [Header("Player Stats")]
    public float maxHealth = 100;
    public float CurrentHealth;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    [Header("Dash Settings")]

    public float dashDuration = 0.2f;
    public float dashSpeed = 20f;

    [Header("Gun Settings")]
    public float fireRate;
    public int magazineSize;
    public float reloadTime;
    public GameObject bulletPrefab;

    [Header("Buildings")]
    public bool B1unlocked;
    public bool B2unlocked;
    public float Interval = 10f;
    public float DevpointsB1;
    public float DevpointsB2;

    [Header("Game objectives")]

    public float DevelopmentPoints;
    public int MaxDevelopmentPoints;
    public int Coins;
    public int VillagerSaved;

}
