using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdmovement : MonoBehaviour
{
    [SerializeField] AudioSource crow1;
    [SerializeField] float movement = .5f;
    [SerializeField] int birdhealth = 3;
    [SerializeField] Rigidbody2D bird;
    public static int SPEED = 20;
    // Start is called before the first frame update
    void Start()
    {
        
        if (bird == null)
            bird = GetComponent<Rigidbody2D>();
        if (crow1 == null)
            crow1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(birdhealth == 0)
        {
            Destroy(gameObject);
            Scoring.scoreValue += 15 * Settingsscript.scoreMOD;
        }
    }

    private void FixedUpdate()
    {
        bird.velocity = new Vector2(SPEED * movement * Settingsscript.difficulty , bird.velocity.y);

    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "EDGE")
        {

            movement *= -1;

            Flip();
        }
        else if (collision.gameObject.tag == "Needle")
        {
           birdhealth -=1;
           AudioSource.PlayClipAtPoint(crow1.clip, transform.position);
        }
        else
            Debug.Log(collision.gameObject.tag);
    }
}