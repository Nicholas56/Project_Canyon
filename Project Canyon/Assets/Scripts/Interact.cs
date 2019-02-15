using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public GameObject player;
    public Score keepTrack;
    public Bounce floor;
    public BeginRun gameEnd;

    public float modifier;
    public float moveSpeed;
    public float moveSpeed2;
    public AudioSource soundEffect;
    public AudioSource hitSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        keepTrack = FindObjectOfType<Score>();
        floor = FindObjectOfType<Bounce>();
        gameEnd = FindObjectOfType<BeginRun>();


        moveSpeed = PlayerPrefs.GetFloat("moveSpeed");
        moveSpeed2 = PlayerPrefs.GetFloat("moveSpeed2");
    }

    private void Update()
    {
        if(!gameEnd.isRun)
        {
            if (player.transform.position.x - transform.position.x > 20) { Invoke("SelfDestruct", 2f); }
            if (gameObject.tag == "Money1")
            {
                    transform.position = Vector2.Lerp(transform.position, player.transform.position, moveSpeed);
            }
            else if (gameObject.tag == "Money2")
            {
                transform.position = Vector2.Lerp(transform.position, player.transform.position, moveSpeed);
            }
            else if (gameObject.tag == "Money3")
            {
                transform.position = Vector2.Lerp(transform.position, player.transform.position, moveSpeed);
            }
            else if (gameObject.tag == "Donut")
            {
                transform.position = Vector2.Lerp(transform.position, player.transform.position, moveSpeed2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitSound.Play();
        soundEffect.Play();
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Bird")
            {
                floor.height = floor.height + modifier;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y + floor.height, 0);
                keepTrack.birdsHit++;
            }
            else if (gameObject.tag == "BigBird")
            {
                floor.height = floor.height + modifier;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y + floor.height, 0);
                keepTrack.birdsHit++;
            }
            else if (gameObject.tag == "Rock")
            {
                floor.height = floor.height * modifier;
                floor.height += floor.obstacleReduction;
                keepTrack.obstacles++;
            }
            else if (gameObject.tag == "Cactus")
            {
                floor.height = 0;
                player.GetComponent<Rigidbody2D>().velocity = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x * modifier, player.GetComponent<Rigidbody2D>().velocity.y * modifier, 0);
                keepTrack.obstacles++;
            }
            else if (gameObject.tag == "Donut")
            {
                keepTrack.donuts++;
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Money1")
            {
                keepTrack.money += Mathf.FloorToInt(modifier);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Money2")
            {
                keepTrack.money += Mathf.FloorToInt(modifier);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Money3")
            {
                keepTrack.money += Mathf.FloorToInt(modifier);
                Destroy(gameObject);
            }
            else return;
        }
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
