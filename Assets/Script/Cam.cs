using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject pCamera, portal;
    private Camera camera;

    void Awake()
    {
        camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, pCamera.transform.position.y, pCamera.transform.position.z);
        this.transform.forward = -pCamera.transform.position + portal.transform.position;

        camera.fieldOfView = -10 / this.transform.localPosition.z;
    }
}
