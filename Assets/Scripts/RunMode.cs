using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunMode : MonoBehaviour
{
    public Dropdown dropDown;
    private List<string> names = new List<string> { "Manual", "Auto Without CSV", "Auto With CSV" };
    public Text promt;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        CreateList();
    }

    public void indexChange(int index)
    {
        switch(index)
        {
            case 0:
                promt.text = "Manual W,S,A,D to move the main camera\n Space to take snapshot";
                break;
            case 1:
                promt.text = "Auto take snapshot automatically";
                break;
            case 2:
                promt.text = "CSV position camera as specified in CSV file";
                break;
            default:
                break;
        }
        player.SetMode(index);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateList()
    {
        dropDown.AddOptions(names);
    }
}
