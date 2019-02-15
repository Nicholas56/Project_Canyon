using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour {

    public Detach launch;
    public BeginRun endGame;
    public GameObject player;
    public float fuel;
    public float speed;

    public Image fuelBar;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endGame = FindObjectOfType<BeginRun>();
        fuel = PlayerPrefs.GetFloat("fuel");
        speed = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (fuel > 0)
        {
            fuelBar.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Space) && (launch.launched&&!endGame.isRun))
            {
                player.transform.GetComponent<Rigidbody2D>().velocity = new Vector3(player.transform.GetComponent<Rigidbody2D>().velocity.x + 0.1f, player.transform.GetComponent<Rigidbody2D>().velocity.y + 0.5f, 0);
                fuel -= 1;
            }

            fuelBar.fillAmount = fuel / (PlayerPrefs.GetFloat("fuel"));
        }
        else { fuelBar.gameObject.SetActive(false); }
	}
}
