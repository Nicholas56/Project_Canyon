using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour {

    public Detach launcher;
    public GameObject player;
    public Bounce obstacleModifier;
    public Score gameScore;
    public Jetpack booster;

    public GameObject upgradeScreen;
    public AudioSource openShop;


	// Use this for initialization
	void Start ()
    {
        launcher = GameObject.Find("PlayerThrower").GetComponent<Detach>();
        player = GameObject.FindGameObjectWithTag("Player");
        obstacleModifier = FindObjectOfType<Bounce>();
        gameScore = FindObjectOfType<Score>();
        booster = FindObjectOfType<Jetpack>();
        openShop = GetComponent<AudioSource>();

        upgradeScreen.SetActive(false);
    }

    public void ClickUpgrade(GameObject button)
    {
        if (button.GetComponent<UpButton>().buttonType == "Slope")
        {
            if(gameScore.GetTotalScore()>= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                launcher.upward += (button.GetComponent<UpButton>().price / 10);
                launcher.SetLaunch();
                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id,1);
            }
        }
        else if (button.GetComponent<UpButton>().buttonType == "Player")
        {
            if (gameScore.GetTotalScore() >= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                player.GetComponent<Rigidbody2D>().gravityScale -= (button.GetComponent<UpButton>().price / 1000);
                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id, 1);
            }
        }
        else if (button.GetComponent<UpButton>().buttonType == "Skate")
        {
            if (gameScore.GetTotalScore() >= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                launcher.forward += (button.GetComponent<UpButton>().price / 10);
                launcher.SetLaunch();
                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id, 1);
            }
        }
        else if (button.GetComponent<UpButton>().buttonType == "Obstacle")
        {
            if (gameScore.GetTotalScore() >= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                obstacleModifier.obstacleReduction++;
                PlayerPrefs.SetFloat("obstacleReduction", obstacleModifier.obstacleReduction);
                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id, 1);
            }
        }
        else if (button.GetComponent<UpButton>().buttonType == "MMagnet")
        {
            if (gameScore.GetTotalScore() >= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                PlayerPrefs.SetFloat("moveSpeed", PlayerPrefs.GetFloat("moveSpeed") + 0.001f);
                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id, 1);
            }
        }
        else if (button.GetComponent<UpButton>().buttonType == "DMagnet")
        {
            if (gameScore.GetTotalScore() >= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                PlayerPrefs.SetFloat("moveSpeed2", PlayerPrefs.GetFloat("moveSpeed2") + 0.001f);

                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id, 1);
            }
        }
        else if (button.GetComponent<UpButton>().buttonType == "Jetpack")
        {
            if (gameScore.GetTotalScore() >= button.GetComponent<UpButton>().price)
            {
                gameScore.AlterTotalScore(button.GetComponent<UpButton>().price);
                PlayerPrefs.SetFloat("fuel", PlayerPrefs.GetFloat("fuel") + 500);
                button.GetComponent<Button>().interactable = false;
                PlayerPrefs.SetInt(button.GetComponent<UpButton>().id, 1);
            }
        }
    }
	
	public void OpenUpScreen()
    {
        upgradeScreen.SetActive(true);
        openShop.Play();
    }

    public void CloseUpScreen()
    {
        upgradeScreen.SetActive(false);
    }
}
