using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject Endgame;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private bool canDamge = true;
    public float invulnerableTimer;

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
           animator.SetFloat("HorizontalIdle", Input.GetAxisRaw("Horizontal"));
           animator.SetFloat("VerticalIdle", Input.GetAxisRaw("Vertical"));

        }

        if(currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Stop("BackgroundTheme");
            FindObjectOfType<AudioManager>().Play("GameLoose");
            Endgame.SetActive(true);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator InvulnerableCount()
    {
        canDamge = false;
        Debug.Log("Started");
        yield return new WaitForSeconds(invulnerableTimer);
        Debug.Log("Ended");
        canDamge = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canDamge)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(25);
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(InvulnerableCount());
    }

}
