using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudge : MonoBehaviour {

    float timer;
    float waitTime;
    bool canMove;

    public float nudgeAmount;
    public BeginRun runControl;
    public Detach launchControl;

	// Use this for initialization
	void Start () {
        timer = 0;
        waitTime = 2f;
        runControl = FindObjectOfType<BeginRun>();
        launchControl = FindObjectOfType<Detach>();
	}

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer = timer - waitTime;
            if (!canMove) { canMove = true; }
        }
        if ((launchControl.launched&&!runControl.isRun))
        { 
            if (canMove && Input.GetKeyUp("left"))
            {
                canMove = false;
                if (transform.GetComponent<Rigidbody2D>() != null)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector3(transform.GetComponent<Rigidbody2D>().velocity.x - nudgeAmount, transform.GetComponent<Rigidbody2D>().velocity.y, 0);
                }
            }

            if (canMove && Input.GetKeyUp("right"))
            {
                canMove = false;
                if (transform.GetComponent<Rigidbody2D>() != null)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = new Vector3(transform.GetComponent<Rigidbody2D>().velocity.x + nudgeAmount, transform.GetComponent<Rigidbody2D>().velocity.y, 0);
                }
            }
        }
    }
}
