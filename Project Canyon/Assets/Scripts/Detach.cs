using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detach : MonoBehaviour {

    public int forward;
    public int upward;
    public bool launched;

    public Sprite playerFly;


    private void Start()
    {
        forward = PlayerPrefs.GetInt("forward");
        upward = PlayerPrefs.GetInt("upward");
        launched = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Skate")
        {
            if(collision.GetComponent<FixedJoint2D>()!=null)
            {
                collision.GetComponent<FixedJoint2D>().enabled = !collision.GetComponent<FixedJoint2D>().enabled;
                launched = true;
            }
            
        }
        if (collision.tag == "Player")
        {
            //Debug.Log("Hello");
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(forward, upward), ForceMode2D.Impulse);
            launched = true;
            collision.GetComponent<SpriteRenderer>().sprite = playerFly;
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void SetLaunch()
    {
        PlayerPrefs.SetInt("upward", upward);
        PlayerPrefs.SetInt("forward", forward);
    }
}
