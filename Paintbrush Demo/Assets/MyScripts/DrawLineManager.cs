using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour
{
    public GameObject controller;
    public Gradient gradient;
    public AnimationCurve curve;

    private LineRenderer currLine;
    private int numClicks = 0;
    public static bool leftHanded { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        leftHanded = OVRInput.GetControllerPositionTracked(OVRInput.Controller.LTouch);
    }

    void Update()
    {
        OVRInput.Controller c = leftHanded ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
            GameObject go = new GameObject(); 
            currLine = go.AddComponent<LineRenderer>();
            LineRenderer lineDetails = currLine.GetComponent<LineRenderer>();
            lineDetails.material = new Material(Shader.Find("Sprites/Default"));
            lineDetails.colorGradient = gradient;
            lineDetails.widthCurve = curve;
            lineDetails.widthMultiplier = 0.5f;
            numClicks = 0;
        } else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            currLine.SetVertexCount(numClicks+1);
            currLine.SetPosition(numClicks, controller.transform.position);
            //LineRenderer lineDetails = currLine.GetComponent<LineRenderer>();
            //lineDetails.colorGradient = gradient;
            numClicks++;
        }

    }
}
