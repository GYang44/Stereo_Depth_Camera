using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Player : SmoothMouseLook
{
    public StereoSnapshotCamera stereoSnapCam;
    public DepthCamera depthCam;

    /*
    * This Parameters create delegates to determine the update mode for the player
    */
    public delegate void controllerUpdate();
    private controllerUpdate update;

    private List<Tuple<Vector3, Quaternion>> positionList;

    // Update is called once per frame
    new void Update()
    {
        update();
    }

    void Manual()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeSnapShot(string.Format("{0}/Snapshots/{1}_{2}_{3}", Application.dataPath, this.name, 0, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")));
        }
    }

    void CSV()
    {
        if (positionList.Count > 0)
        {
            transform.SetPositionAndRotation(positionList[0].Item1, positionList[0].Item2);
            //Consume the list
            positionList.RemoveAt(0);
            TakeSnapShot(string.Format("{0}/Snapshots/{1}_{2}_{3}", Application.dataPath, this.name, 3,positionList.Count));
        }
        else
        {
            //return to manual mode after finishing
            SetMode(0);
        }
    }

    void Auto()
    {
        //TODO 
    }

    public void SetMode(int mode)
    {
        switch(mode)
        {
            case 0:
                update = Manual;
                break;
            case 1:
                update = Auto;
                break;
            case 2:
                update = CSV;
                InitialPositionList();
                break;
            default:
                break;
        }
        
    }

    //create list of position and attitude for snapshot from csv input
    void InitialPositionList()
    {
        //initialize the list to empty
        positionList = new List<Tuple<Vector3, Quaternion>>();
        
        //read file 
        StreamReader strReader = new StreamReader(string.Format("{0}/Test.csv", Application.dataPath));
        bool endOfFile = false;
        while (!endOfFile)
        {
            string data_string = strReader.ReadLine();
            if (data_string == null)
            {
                endOfFile = true;
                break;
            }
            var data_values = data_string.Split(',');
            positionList.Add(Tuple.Create(
                    new Vector3(
                        float.Parse(data_values[0], System.Globalization.NumberStyles.Float),
                        float.Parse(data_values[1], System.Globalization.NumberStyles.Float),
                        float.Parse(data_values[2], System.Globalization.NumberStyles.Float)
                    ),
                    Quaternion.Euler(
                        float.Parse(data_values[3], System.Globalization.NumberStyles.Float),
                        float.Parse(data_values[4], System.Globalization.NumberStyles.Float),
                        float.Parse(data_values[5], System.Globalization.NumberStyles.Float)
                    )
                )
            );

        }

    }

    void TakeSnapShot(string name)
    {
        stereoSnapCam.CallTakeSnapshot(name);
        depthCam.CallTakeSnapshot(name);

    }

    private void Start()
    {
        base.Start();
        update = Manual;
    }

}
