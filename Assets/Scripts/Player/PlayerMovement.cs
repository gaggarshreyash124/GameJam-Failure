using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,Idamageable
{
    public Rigidbody2D rb;
    public PlayerData playerData;
    public Transform GroundCheck;
    public Transform GunPoint;
    private Vector3 LastPosition;

    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerData.moveSpeed, rb.velocity.y);
        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }


        if (Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(Dash(playerData.dashDuration, playerData.dashSpeed));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerData.bulletPrefab, GunPoint.position, GunPoint.rotation);
        }


    }
    
    private void Flip()
    {
        if (isFacingRight && Input.GetAxis("Horizontal") < 0f || !isFacingRight && Input.GetAxis("Horizontal") > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
            playerData.faceDirection *= -1;
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0f, playerData.jumpForce), ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.1f, playerData.groundLayer);
    }

    public IEnumerator Dash(float dashDuration, float dashSpeed)
    {
        float elapsed = 0f;

        while (elapsed < dashDuration)
        {
            rb.velocity = new Vector2(dashSpeed * playerData.faceDirection, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void TakeDamage(float Damage)
    {
        playerData.CurrentHealth -= Damage;
    }

    public IEnumerator Platformer(Rigidbody2D RB,GameObject Gb)
    {
        LastPosition = Gb.transform.position;
        Debug.Log(Gb.transform.position);
        yield return new WaitForSeconds(4f);
        RB.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(2f);
        Gb.SetActive(false);
        yield return new WaitForSeconds(4f);
        RB.bodyType = RigidbodyType2D.Static;
        Gb.transform.position = LastPosition;
        Gb.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Falling"))
        {
            StartCoroutine(Platformer(other.gameObject.GetComponent<Rigidbody2D>(),other.gameObject));
        }
    }
}
