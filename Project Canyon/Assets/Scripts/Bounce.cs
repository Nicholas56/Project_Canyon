using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    public GameObject player;
    public float belowHeight;
    public float height;
    public float obstacleReduction;
    public AudioSource groundHit1;
    public AudioSource groundHit2;
    public AudioSource groundHit3;

    private void Start()
    {
        height = 10;
        obstacleReduction = PlayerPrefs.GetInt("obstacleReduction");
    }

    private void Update()
    {
        if (player.transform.position.y < -12)
        {
            belowHeight += Time.deltaTime;
        }
        else { belowHeight = 0; }
        if(belowHeight >= 1) { player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0); height = 0; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, height, 0);
            height = height * (0.8f + (0.1f * obstacleReduction));
            if (belowHeight < 2)
            {
                int sound = Random.Range(0, 3);
                if (sound == 0) { groundHit1.Play(); }
                else if (sound == 1) { groundHit2.Play(); }
                else if (sound == 2) { groundHit3.Play(); }
                else return;
            }
        }
        
    }
}
