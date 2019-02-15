using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LauncherMeter : MonoBehaviour {

    public bool isLaunch;
    private bool upPoint;
    //private bool goPoint;
    private bool meterUp;
    public Image upMeter;
    public Image meter;

	// Use this for initialization
	void Start ()
    {
        isLaunch = true;
        upPoint = true;
        //goPoint = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isLaunch)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (upPoint)
                {
                    upPoint = false;
                }
                else
                {
                    isLaunch = false;
                }
            }

            if (upPoint)
            {
                if (upMeter.fillAmount >= 1)
                {
                    meterUp = false;
                }
                else if (upMeter.fillAmount <= 0)
                {
                    meterUp = true;
                }

                if (meterUp)
                {
                    upMeter.fillAmount += Time.deltaTime;
                }
                else
                {
                    upMeter.fillAmount -= Time.deltaTime;
                }
            }
            else
            {
                if (meter.fillAmount >= 1)
                {
                    meterUp = false;
                }
                else if (meter.fillAmount <= 0)
                {
                    meterUp = true;
                }

                if (meterUp)
                {
                    meter.fillAmount += Time.deltaTime;
                }
                else
                {
                    meter.fillAmount -= Time.deltaTime;
                }
            }
            
        }
	}

    public void Launch()
    {
        if (isLaunch && (Input.GetMouseButtonUp(0)))
        {
            if (upPoint)
            {
                upPoint = false;
            }
        }
    }
}
