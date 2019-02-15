using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    public GameObject player;
    float timer;
    float waitTime;
    public BeginRun gameManager;

    public GameObject bird;
    public GameObject bigBird;
    public GameObject rock;
    public GameObject cactus;

    List<GameObject> objects;
    List<int> frequency;

    public GameObject money1;
    public GameObject money2;
    public GameObject money3;
    public GameObject donut;

    public Score distanceTrack;
    public int objectSpacing;
    public bool place;

	// Use this for initialization
	void Start ()
    {
        gameManager = FindObjectOfType<BeginRun>();
        distanceTrack = FindObjectOfType<Score>();
        objectSpacing = 20;
        place = true;

        timer = 0;
        waitTime = 2f;

        frequency = new List<int> { 35, 50, 85, 100 };
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && !gameManager.isRun)
        {
            timer = timer - waitTime;
            placeMoney();
            placeObject();
        }

    }

    void placeObject()
    {
        int objectPick = Random.Range(0,100);
        
        if (objectPick < frequency[0])
        {
            Instantiate(bird, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20),0), Quaternion.identity);
            Instantiate(bird, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20),0), Quaternion.identity);
        }
        else if(objectPick <frequency[1])
        {
            Instantiate(bigBird, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20), 0), Quaternion.identity);
            Instantiate(bigBird, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20), 0), Quaternion.identity);
        }
        else if (objectPick < frequency[2])
        {
            Instantiate(rock, new Vector3(player.transform.position.x + Random.Range(20, 40), -13, 0), Quaternion.identity);
        }
        else if (objectPick < frequency[3])
        {
            Instantiate(cactus, new Vector3(player.transform.position.x + Random.Range(20, 40), -13, 0), Quaternion.identity);
        }
        else { return; }

    }

    void placeMoney()
    {
        if (distanceTrack.distance>50)
        {
            Instantiate(money1, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20), 0), Quaternion.identity);
        }
        if (distanceTrack.distance > 150)
        {
            Instantiate(money2, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20), 0), Quaternion.identity);
        }
        if (distanceTrack.distance > 500)
        {
            Instantiate(money3, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20), 0), Quaternion.identity);
        }
        int donutChance = Random.Range(0, 10);
        if (distanceTrack.distance > 50 && donutChance == 5)
        {
            Instantiate(donut, new Vector3(player.transform.position.x + Random.Range(20, 40), player.transform.position.y + Random.Range(-20, 20), 0), Quaternion.identity);
        }
    }
}
