using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalCam, posicionador;
    public Portal portalVinculado;
    private GameObject player;
    private Camera portalCamCam;
    private RenderTexture viewTexture;


    void Awake()
    {
        this.GetComponent<MeshRenderer>().material.SetInt("displayMask", 1);
        player = GameObject.Find("Player");
        portalCamCam = portalCam.GetComponent<Camera>();
        this.gameObject.layer = (10 + int.Parse((this.name != "Portal") ? this.gameObject.name.Split('(')[1].Replace(")", "") : "0"));
        portalCamCam.cullingMask = ~(1 << this.gameObject.layer);
        //portalCamCam.enabled = false;
    }

    private void Start()
    {
    }

    void LateUpdate()
    {
        //this.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

        AjustarCamera();


        if (viewTexture == null || viewTexture.width != Screen.width || viewTexture.height != Screen.height)
        {
            if (viewTexture != null)
            {
                viewTexture.Release();
            }
            viewTexture = new RenderTexture(Screen.width, Screen.height, 0);
            portalVinculado.portalCamCam.targetTexture = viewTexture;
            this.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", viewTexture);
        }

        OcultarPortalCamera();
        //portalCamCam.Render();

        //portalVinculado.GetComponent<MeshRenderer>().material.SetInt("diplayMask", 0);

        //for (int i = 0; i < 2; i++)
        //{
        //    if (i == 0)
        //    {
        //        portalCam.transform.localPosition = portalVinculado.transform.localPosition;
        //        portalCam.transform.localRotation = portalVinculado.transform.localRotation;
        //        portalCamCam.Render();
        //    }
        //}

    }

    private void AjustarCamera()
    {
        portalCamCam.projectionMatrix = Camera.main.projectionMatrix;
        posicionador.transform.position = Camera.main.transform.position;
        posicionador.transform.rotation = Camera.main.transform.rotation;

        if (NaVisao())
        {
            portalVinculado.portalCam.transform.localPosition = -posicionador.transform.localPosition + Vector3.up * 2 * posicionador.transform.localPosition.y;
            portalVinculado.portalCam.transform.localEulerAngles = posicionador.transform.localEulerAngles + Vector3.up * 180;
        }
    }

    void OcultarPortalCamera()
    {
        var plane = new Plane((portalVinculado.posicionador.transform.localPosition.z < 0f ? -1 : 1) * this.transform.forward, this.transform.position);
        var clipPlane = Matrix4x4.Transpose(Matrix4x4.Inverse(portalCamCam.worldToCameraMatrix)) * new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
        portalCamCam.projectionMatrix = Camera.main.CalculateObliqueMatrix(clipPlane);
    }

    private bool NaVisao() => GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(Camera.main), this.GetComponent<MeshRenderer>().bounds);
}
