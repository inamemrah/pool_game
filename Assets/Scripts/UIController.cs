using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text süre;
    public Text skor;
    public Text vurusSayisi;
    public Text hazir;
    
    public GameObject oyunBittiPanel;

   public static float süre_ ;
   public static int skor_ ;
   public static int vurusSayisi_ ;

	// Use this for initialization
	void Start () {

          süre_ = 0;
          skor_ = 0;
          vurusSayisi_ = 0;
        

        oyunBittiPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.F))
        {
            Application.LoadLevel("Main");
        }

        if(PlayerController.attack == true)
        {
            hazir.text = "Vuruş İçin Hazır";
        }
        else
        {
            hazir.text = "Yeni Vuruş İçin Bekle";
        }

        süre_ += Time.deltaTime;

        süre.text = "" + Mathf.Round(süre_);
        vurusSayisi.text = "" + Mathf.Round(vurusSayisi_);
        skor.text = "" + skor_;

        

        if (skor_ == 5)
        {
            LastGame();
        }

    }

    public void LastGame()
    {
        süre_ -= Time.unscaledDeltaTime;

        PlayerPrefs.SetFloat("lastSüre", Mathf.Round(süre_));
        PlayerPrefs.SetInt("lastSkor", skor_);
        PlayerPrefs.SetInt("lastVurus", vurusSayisi_);
        PlayerPrefs.Save();

        oyunBittiPanel.SetActive(true);
       
       
    }

    
}
