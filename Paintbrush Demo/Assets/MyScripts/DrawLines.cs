using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour 
{

    public float LINE_WIDTH = 0.5f;

    public GameObject controller;
    public Material lineMat;

    private int numClicks = 0;
    private LineRenderer currLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (numClicks == 0)
            {
                GameObject go = new GameObject();
                go.AddComponent<MeshFilter>();
                go.AddComponent<MeshRenderer>();
                currLine.material = lineMat;
            }
            currLine.SetVertexCount(numClicks + 1);
            currLine.SetPosition(numClicks, controller.transform.position);
            numClicks++;
        }
        else
        {
            if(numClicks!=0)
            {
                Debug.LogError(numClicks);
            }
            numClicks = 0;
        }
    }
}
