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
    public int faceDirection = 1;
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

    void Start()
    {
        maxHealth = CurrentHealth;
    }
}
