using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGameData : MonoBehaviour {

    public Text lastSüre_;
    public Text lastSkor_;
    public Text lastVurus_;
    

	// Use this for initialization
	void Start () {
        lastSüre_.text  = PlayerPrefs.GetFloat("lastSüre").ToString();
        lastSkor_.text  = PlayerPrefs.GetInt("lastSkor" ).ToString();
        lastVurus_.text = PlayerPrefs.GetInt("lastVurus" ).ToString();
	}
	
	// Update is called once per frame
	void Update () {
        

       if(UIController.skor_ == 5)
        {
            PlayerPrefs.SetFloat("lastSüre", Mathf.Round(UIController.süre_));
            PlayerPrefs.SetInt("lastSkor", UIController.skor_);
            PlayerPrefs.SetInt("lastVurus", UIController.vurusSayisi_);

            PlayerPrefs.Save();
        }
	}
}
