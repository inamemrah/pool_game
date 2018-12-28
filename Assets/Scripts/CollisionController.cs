using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    public static bool redBall_Carpti = false;
    public static bool yellowBall_Carpti = false;

    public AudioClip MusicClip;
    public AudioSource MusicSource;


    // Use this for initialization
    void Start () {
        MusicSource.clip = MusicClip;
        MusicSource.volume = Main.soundLevel;
 
       
    }
	
	// Update is called once per frame
	void Update () {


        if (redBall_Carpti == true && yellowBall_Carpti == true)
        {
            UIController.skor_ += 1;
            redBall_Carpti = false;
            yellowBall_Carpti = false;
        }

       
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("yellowBall"))
        {
            
            MusicSource.Play();
            Debug.Log("sarı");
            yellowBall_Carpti = true;
           
        }

        if (collision.gameObject.CompareTag("redBall"))
        {
            MusicSource.Play();
            Debug.Log("kırmızı");
            redBall_Carpti = true;
            
        }
       
    }
}
