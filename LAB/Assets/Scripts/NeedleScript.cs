using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{
    public static int needlecnt = 0;
    public static int inc = 1;
    

    public float speed = 30000f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * -1 * Time.deltaTime * speed;
    

    }
    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "baloon")
        {

            needlecnt--;
        }

        else if (collision.gameObject.tag == "EDGE")
        {
            Destroy(gameObject);
            needlecnt--;
        }
        else if (collision.gameObject.tag == "Bird")
        {
            Destroy(gameObject);
            needlecnt--;
        }
        else if (collision.gameObject.tag == "wolf")
        {
            Destroy(gameObject);
            needlecnt--;
        }

    }
}
