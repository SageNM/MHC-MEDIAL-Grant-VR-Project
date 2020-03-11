using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject person;
    public GameObject controller;
    public static bool leftHanded { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        leftHanded = OVRInput.GetControllerPositionTracked(OVRInput.Controller.LTouch);
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Controller c = leftHanded ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        if (OVRInput.GetControllerPositionTracked(c))
        {
            Vector3 vector = new Vector3(0.3f, 0.5f, 0f);
            Quaternion rotation = new Quaternion(0f, -0.7f, 0f, 1f);
            controller.transform.SetPositionAndRotation(OVRInput.GetLocalControllerPosition(c) + person.transform.position + vector, OVRInput.GetLocalControllerRotation(c));
            controller.transform.rotation *= rotation;
        }
    }
}
