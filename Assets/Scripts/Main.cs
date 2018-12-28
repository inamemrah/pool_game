using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Slider soundLevelSlider;
    public static float soundLevel = 1;

	// Use this for initialization
	void Start () {
        soundLevelSlider.value = PlayerPrefs.GetFloat("soundLevel");

    }

    // Update is called once per frame
    void Update () {
        soundLevel = soundLevelSlider.value;
        PlayerPrefs.SetFloat("soundLevel", soundLevelSlider.value);
    }
    
    public void startGame()
    {
        Destroy(soundLevelSlider);
        Application.LoadLevel("Game");
    }
    public void volumeControl()
    {

    }

    public void mainScene()
    {
        Application.LoadLevel("Main");
    }


}
