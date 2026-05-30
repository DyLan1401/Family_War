using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{

   //di chuyen
    public float speed = 5f;          
    private float moveInput;        
    private Rigidbody2D rb;           
    private Animator anim;          

    //nhay
    public float jumpForce = 10f;    
    public Transform groundCheck;   
    public LayerMask groundLayer;    
    private bool isGrounded;          

    //huong nhin
    private bool facingRight = true; 

    //tan cong
    public Transform attackPoint;     
    public float attackRange = 0.5f; 
    public LayerMask enemyLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
     //bam trai quai di chuyen 
        moveInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        

        //nhay và check xem co dung ground hay k 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        //neu bam nut space va cham ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
           //giu nguyen truc x và di chuyên tr?c y
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        //attack
        // b?m nút J ?? attack
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }

        //check quay mat
        if (moveInput < 0 && facingRight) { Flip(); }
              else if (moveInput > 0 && !facingRight) { Flip(); }
    }
    void FixedUpdate()
    {
       
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
    void Attack()
    {
        anim.SetTrigger("Attack"); 

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}