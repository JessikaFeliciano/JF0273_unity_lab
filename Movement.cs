<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] AudioSource shot;
    [SerializeField] int currentlevel;
    [SerializeField] GameObject needlePrefab;
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 10;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = .2f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Animator animator;
    public static int lives = 3;
    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;
    const int SHOOT = 3;
    [SerializeField] bool hasShoot = false;
    // Start is called before the first frame update
    void Start()
    {
     
        currentlevel = SceneManager.GetActiveScene().buildIndex;
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
            animator.SetInteger("motion", IDLE);
        }
        if (shot == null)
            shot = GetComponent<AudioSource>();


    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        if(lives==0)
            SceneManager.LoadScene("PostGame");
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
        if (Input.GetButtonDown("Fire1") && NeedleScript.needlecnt < 1)
        {
            hasShoot = true;
        }
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
        if (hasShoot)
            Shoot();
        else
        {
            jumpPressed = false;
            if (isGrounded)
            {
                if (movement > 0 || movement < 0)
                {
                    animator.SetInteger("motion", RUN);
                }
                else
                {
                    animator.SetInteger("motion", IDLE);
                }
            }

        }

    }

    public NeedleScript needle;
    public Transform LaunchOffset;

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        animator.SetInteger("motion", JUMP);
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }

    private void Shoot()
    {
        animator.SetInteger("motion", SHOOT);
        AudioSource.PlayClipAtPoint(shot.clip, transform.position);
        Instantiate(needlePrefab, LaunchOffset.position, transform.rotation);
        NeedleScript.needlecnt += NeedleScript.inc;
        hasShoot = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        else if (collision.gameObject.tag == "wolf") {
            Destroy(gameObject);
            NeedleScript.needlecnt = 0;
            lives--;
            Scoring.scoreValue -= 15;
        SceneManager.LoadScene(currentlevel);
        
        }
        else
            Debug.Log(collision.gameObject.tag);
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
        else
            jumpPressed = false;

        
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        else
            Debug.Log(collision.gameObject.tag);
    }
}
>>>>>>> Stashed changes
