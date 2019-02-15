using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpButton : MonoBehaviour
{
    public int price;
    public string buttonType;
    public int upgradeNum;
    public string id;


    private void Start()
    {
        id = buttonType + upgradeNum;
        gameObject.GetComponentInChildren<Text>().text = buttonType + " Upgrade " + upgradeNum + ": " + price;

        if (PlayerPrefs.GetInt(id)==1)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
