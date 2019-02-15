using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour {

	public void ClickReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
