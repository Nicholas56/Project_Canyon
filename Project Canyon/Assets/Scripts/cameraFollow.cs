using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public GameObject player;   //Public variable to store a reference to the player game object

	// LateUpdate is called after Update each frame
	void LateUpdate ()
    {
        //Set the position of the camera's transform to be the same as the player's. but the offset by the calculated offset distance.
        transform.position = player.transform.position + new Vector3(0,0,-10);
	}
}
