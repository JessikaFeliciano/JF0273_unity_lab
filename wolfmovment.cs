using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] float movement = .5f;
    [SerializeField] Rigidbody2D wolf;
    [SerializeField] const int SPEED = 10;
    // Start is called before the first frame update
    void Start()
    {

        if (wolf == null)
            wolf = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        wolf.velocity = new Vector2(SPEED * movement * Settingsscript.difficulty, wolf.velocity.y);

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
       
        else
            Debug.Log(collision.gameObject.tag);
    }
}