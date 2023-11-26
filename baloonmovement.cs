using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class baloonmovement : MonoBehaviour
{
    public int pointVal = 60;
    public float delaytime = 5f;  
    [SerializeField] AudioSource pop;
    [SerializeField] int currentlevel;
    [SerializeField] float movement = .5f;
    [SerializeField] Rigidbody2D baloon;
    public static int SPEED = 25;
    [SerializeField] int level;
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex + 1;
        currentlevel = SceneManager.GetActiveScene().buildIndex;
        InvokeRepeating("growSize", 5f, 5f);
        if (baloon == null)
            baloon = GetComponent<Rigidbody2D>();
        if (pop == null)
            pop = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(pointVal <= 0)
        {
            Destroy(gameObject);
            Movement.lives--;
            NeedleScript.needlecnt = 0;
            Scoring.scoreValue -= 15;
            SceneManager.LoadScene(currentlevel);
        }
    }

    private void FixedUpdate()
    {
        baloon.velocity = new Vector2(SPEED * movement * Settingsscript.difficulty, baloon.velocity.y);

    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

    private void growSize()
    {
        baloon.transform.localScale += new Vector3(.0025f, .0025f, .0025f);
        pointVal -= 5;

    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    { 

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "EDGE")
        {

            movement *= -1;

            Flip();
        }
        else if(collision.gameObject.tag == "Needle")
            {
            Scoring.scoreValue += pointVal * Settingsscript.scoreMOD;
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        
            SceneManager.LoadScene(level);
        }
            else
            Debug.Log(collision.gameObject.tag);
    }
}