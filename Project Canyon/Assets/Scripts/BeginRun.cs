using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginRun : MonoBehaviour {

    public LauncherMeter meterControl;
    public GameObject player;
    public Detach speedControl;
    public bool isRun;


    public GameObject jumpScreen;
    public Text distTxt;
    public Text MonTxt;
    public Text DonTxt;
    public Text FinalTxt;
    public Text TotalTxt;
       
	// Use this for initialization
	void Start ()
    {
        isRun = false;
        jumpScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!meterControl.isLaunch)
        {
            Begin();

            if(speedControl.launched && player.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                isRun = true;
            }
        }

        if (isRun)
        {
            jumpScreen.SetActive(true);
        }
	}

    void Begin()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        speedControl.upward = Mathf.FloorToInt(meterControl.upMeter.fillAmount * 10);
        speedControl.forward = Mathf.FloorToInt(meterControl.meter.fillAmount * 20);
    }
}
