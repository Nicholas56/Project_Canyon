using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public Camera cameraObject;
    public GameObject player;

    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public Color color3 = Color.white;

    // Use this for initialization
    void Start () {
        cameraObject = FindObjectOfType<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y < 100)
        {
            float t = player.transform.position.y / 100;
            cameraObject.backgroundColor = Color.Lerp(color1, color3, t);
        }
        else
        {

            float t = player.transform.position.y / 2000;
            cameraObject.backgroundColor = Color.Lerp(color3, color2, t);
        }
	}
}
