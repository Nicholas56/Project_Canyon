using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject player;
    public GameObject slope;
    public float distance;
    public float height;
    public Text distanceText;
    public Text heightText;

    public BeginRun gameManager;
    bool scoreDisplayed;

    public int money;
    public int donuts;
    public int birdsHit;
    public int obstacles;

    int totalScore;

	// Use this for initialization
	void Start () {
        distance = 0;		
        height = 0;

        //DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update ()
    {
        distance = player.transform.position.x - slope.transform.position.x;
        height = player.transform.position.y + 13;
        distance -= 4;
        distanceText.text = "Distance Travelled: " + distance.ToString("n0");
        heightText.text = "Height: " + height.ToString("n0");

        if (gameManager.isRun && !scoreDisplayed)
        {
            scoreDisplayed = true;
            DisplayScore();
        }
	}

    void DisplayScore()
    {
        if (gameManager.distTxt != null)
        {
            gameManager.distTxt.text = "Distance Travelled: " + distance.ToString("n0");
            gameManager.MonTxt.text = "Money Collected: " + money;
            gameManager.DonTxt.text = "Donuts Collected: " + donuts;

            gameManager.FinalTxt.text = "Final Score: " + (money+Mathf.FloorToInt(distance*0.1f));
            gameManager.TotalTxt.text = "Total Score: " + ((money+Mathf.FloorToInt(distance*0.1f)) + PlayerPrefs.GetInt("totalScore"));
            totalScore = (money + Mathf.FloorToInt(distance * 0.1f)) + PlayerPrefs.GetInt("totalScore");
            PlayerPrefs.SetInt("totalScore", totalScore);
        }
    }

    public void AlterTotalScore(int alteration)
    {
        PlayerPrefs.SetInt("totalScore", totalScore - alteration);
        totalScore -= alteration;
        gameManager.TotalTxt.text = "Total Score: " + PlayerPrefs.GetInt("totalScore");
    }

    public int GetTotalScore()
    {
        return PlayerPrefs.GetInt("totalScore");
    }
}
