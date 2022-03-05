using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public GameObject Loosegame;
    [SerializeField] public GameObject Wingame;

    public GameObject ventbutton;
    public GameObject UICheese;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public SpriteRenderer playerSpriteRenderer;
    public CircleCollider2D enemycollider;

    Vector2 movement;

    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private bool canDamge = true;
    public float invulnerableTimer;

    public bool canMove = true;

    VentsSystem ventsSystem;

    public bool hasCheese = false;

   

    void Awake()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove == true)
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
        }

        if (canMove == false)
        {
            movement.x = 0;
            movement.y = 0;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }

        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Stop("BackgroundTheme");
            FindObjectOfType<AudioManager>().Play("GameLoose");
            Loosegame.SetActive(true);
            ventbutton.SetActive(false);
            canMove = false;
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

        if (hasCheese)
        {
            if (collision.gameObject.CompareTag("Mouse"))
            {
                FindObjectOfType<AudioManager>().Stop("BackgroundTheme");
                FindObjectOfType<AudioManager>().Play("GameWin");
                ventbutton.SetActive(false);
                UICheese.SetActive(false);
                Wingame.SetActive(true);
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        StartCoroutine(InvulnerableCount());
    }



    // Vent Stuff

    public void EnterVent(VentsSystem ventsSystem)
    {
        this.ventsSystem = ventsSystem;
    }

    public void VentEntered()
    {
        DisablePlayer();

        ventsSystem.PlayerInVent();
    }

    public bool IsInVent()
    {
        return rb.simulated;
    }

    public void VentExited()
    {
        EnablePlayer();
    }

    public void MovePlayer()
    {
        canMove = true;
    }

    public void StopPlayer()
    {
        canMove = false;
    }

    void DisablePlayer()
    {
        Color c = playerSpriteRenderer.color;
        c.a = 0;
        playerSpriteRenderer.color = c;
        rb.simulated = false;
    }
    void EnablePlayer()
    {
        Color c = playerSpriteRenderer.color;
        c.a = 1;
        playerSpriteRenderer.color = c;
        rb.simulated = true;
        MovePlayer();
    }

}
