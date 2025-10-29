using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour,Idamageable
{
    public Rigidbody2D rb;
    Animator anim;
    public PlayerData playerData;
    public Transform GroundCheck;
    public Transform GunPoint;
    private Vector3 LastPosition;

    private bool isFacingRight = true;
    public int faceDirection = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerData.CurrentHealth = playerData.maxHealth;
        playerData.Coins = 250;
        playerData.DevelopmentPoints = 0;
        playerData.B1unlocked = false;
        playerData.B2unlocked = false;
        playerData.VillagerSaved = 0;

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerData.moveSpeed, rb.velocity.y);
        Flip();
        anim.SetBool("Run", Input.GetAxis("Horizontal") != 0);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        anim.SetBool("Jump", !IsGrounded());

        if (Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(Dash(playerData.dashDuration, playerData.dashSpeed));
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(playerData.bulletPrefab, GunPoint.position, GunPoint.rotation);
        }

        if (playerData.DevelopmentPoints >= playerData.MaxDevelopmentPoints)
        {
            EndGame();
        }
    }
    
    private void Flip()
    {
        if (isFacingRight && Input.GetAxis("Horizontal") < 0f || !isFacingRight && Input.GetAxis("Horizontal") > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.Rotate(0f, 180f, 0f);
            faceDirection *= -1;
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0f, playerData.jumpForce), ForceMode2D.Impulse);
        anim.SetBool("Jump", true);
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
            rb.velocity = new Vector2(dashSpeed * faceDirection, 0f);
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
        if (other.gameObject.CompareTag("Falling"))
        {
            StartCoroutine(Platformer(other.gameObject.GetComponent<Rigidbody2D>(), other.gameObject));
        }
        else if (other.gameObject.CompareTag("Dead"))
        {
            SceneManager.LoadScene(4);
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E))
    {
        if (other.gameObject.CompareTag("Villager"))
        {
            playerData.Coins += 200;
            playerData.DevelopmentPoints += 100;
            playerData.VillagerSaved += 1;
            Destroy(other.gameObject, 1f);
        }
        else if (other.gameObject.CompareTag("Build"))
        {
            var buildScript = other.gameObject.GetComponent<BuyBuild>();

            if (!playerData.B1unlocked && playerData.Coins >= 200)
            {
                playerData.B1unlocked = true;
                playerData.Coins -= 200;
                buildScript.openB1();
            }
            else if (!playerData.B2unlocked && playerData.Coins >= 250)
            {
                playerData.B2unlocked = true;
                playerData.Coins -= 250;
                buildScript.openB1();
                Debug.Log("open B2");
            }
            else
            {
                Debug.Log("Cannot Afford");
            }
        }
    }

    }

    public void EndGame()
    {
        SceneManager.LoadScene(3);
    }
}
