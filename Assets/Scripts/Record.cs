using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Record : MonoBehaviour
{
    [System.Serializable]

    public class GoVals
    {
        public Vector3 position;
        public Quaternion rotation;

        //constructor
        public GoVals(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }


    List<GoVals> vals = new List<GoVals>();

    public static bool recording = false;

    public static bool replaying = false;

    int replayFrame = 0;


    Transform tf;

    void Start()
    {

        tf = this.transform;
    }

    void Update()
    {
        Record_();
        Replay();
    }

    void Record_()
    {
        if (!recording) return;
        vals.Add(new GoVals(tf.position, tf.rotation));
 
    }

    void Replay()
    {
        if (!replaying) return;


        if (replayFrame >= vals.Count)
        {
            replayFrame = 0;
            replaying = false;

            return;
        }

        tf.position = vals[replayFrame].position;
        tf.rotation = vals[replayFrame].rotation;
        Debug.Log(tf.position);

        replayFrame++;
    }

    public void ReplayButton()
    {
        if (!recording)
        {
            replaying = true;
        }
        else
        {
            replaying = !replaying;
        }
    }

}