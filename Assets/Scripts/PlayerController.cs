using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public GameObject ball;
    public GameObject yellowBall;
    public GameObject redBall;

    public Button replay;

    public Slider power;
    public static float power_;

    public static bool attack = true;
   

    void Start()
    {
        attack = true;
    }

    

    void Update()
    {
        transform.LookAt(ball.transform);

        Rigidbody red = redBall.GetComponent<Rigidbody>();
        Rigidbody yellow = yellowBall.GetComponent<Rigidbody>();
        Rigidbody white = ball.GetComponent<Rigidbody>();

        if(redBall.transform.position.y < -1)
        {
            redBall.transform.position = new Vector3(1.66f, -0.09f, 1f);
            red.velocity = Vector3.zero;
        }
        else if(yellowBall.transform.position.y < -1)
        {
            yellowBall.transform.position = new Vector3(1.66f, -0.09f, 1f);
            yellow.velocity = Vector3.zero;
        }
        else if(ball.transform.position.y < -1)
        {
            ball.transform.position = new Vector3(1.66f, -0.09f, 1f);
            white.velocity = Vector3.zero;
        }

        if(UIController.vurusSayisi_ == 0)
        {
            attack = true;
        }
        else
        {
            if (white.velocity == Vector3.zero && yellow.velocity == Vector3.zero && red.velocity == Vector3.zero)
            {

                CollisionController.redBall_Carpti = false;
                CollisionController.yellowBall_Carpti = false;
                attack = true;
                Record.recording = false;
                

            }
        }

        if(Record.replaying == true)
        {
            attack = false;
        }
        if(Record.recording == true)
        {
            replay.interactable = false;
        }
        else
        {
            replay.interactable = true;
        }
        

        if (attack == true)
        {
           

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ball.transform.position = ball.transform.position + Camera.main.transform.forward;
                white.velocity = Camera.main.transform.forward * power_ / 5;
                
                UIController.vurusSayisi_ += 1;
                attack = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if(Record.recording == false)
                {
                    Record.recording = true;
                    Debug.Log("record");
                }
               
                power.value += 2;
                power_ = power.value;
            }
            else
            {
                power.value = 0;
                power_ = power.value;
            }

        }

    }
   

}