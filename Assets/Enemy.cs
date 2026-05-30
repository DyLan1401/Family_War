using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public float speed = 2f;
    public int scoreValue = 1;


    public int attackDamage = 10;     // dame quái gây ra cho Player
    public float attackRange = 1.2f;   // khoang cach enemy attack
    public float attackRate = 1.5f;    // 1,5s attack 1 lan
    private float nextAttackTime;

    public Slider healthSlider; // 
    public GameObject coinPrefab; //

    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerHealth playerHealth;

    void Start()
    {

        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        // Th? c? 2 tên ph? bi?n
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("KHÔNG TÌM thay PLAYER! check Tag!");
        }
    }

    void FixedUpdate()
    {
        // chua thay thi tim lai
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
                playerHealth = playerObj.GetComponent<PlayerHealth>();
            }
            return;
        }
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
            if (anim != null) anim.SetBool("isMoving", true);

            if (direction.x > 0)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (anim != null) anim.SetBool("isMoving", false);

            if (Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }
    void AttackPlayer()
    {
        // 1.tan cong
        if (anim != null)
        {
            anim.SetTrigger("Attack"); // Tên Parameter Trigger trong Animator  quái

        }

        // 2. 
        if (playerHealth != null)
        {
            playerHealth.PlayerTakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthSlider != null) healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
