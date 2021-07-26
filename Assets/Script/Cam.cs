using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject pCamera, portal;
    public Portal[] portais;
    private Camera camera;
    private RenderTexture viewTexture;

    void Awake()
    {
        portais = GameObject.FindObjectsOfType<Portal>();
        camera = this.GetComponent<Camera>();
    }

    void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x, pCamera.transform.position.y, pCamera.transform.position.z);

        //this.transform.rotation = pCamera.transform.rotation;
        //this.transform.forward = -pCamera.transform.position + portal.transform.position;

        //camera.fieldOfView = -10 / this.transform.localPosition.z;
    }

    private void OnPreCull()
    {
        //portal.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
        //camera.projectionMatrix = pCamera.GetComponent<Camera>().projectionMatrix;
        //if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        //{
        //    if (viewTexture != null)
        //    {
        //        viewTexture.Release();
        //    }
        //    viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
        //    this.camera.targetTexture = viewTexture;
        //    portal.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", viewTexture);
        //    portal.GetComponent<MeshRenderer>().material.SetInt("displayMask", 1);
        //}


    }
}
