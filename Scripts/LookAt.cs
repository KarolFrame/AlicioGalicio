using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Camera cam;
    GameObject camObject;
    Transform tr;
    void Start()
    {
        camObject = GameObject.Find("Main Camera");
        cam = camObject.GetComponent<Camera>();
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        tr.LookAt(cam.transform);
    }
}
