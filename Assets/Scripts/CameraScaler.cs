using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    Camera cam;
    public float desiredAspectRatio = 16f / 9f;
    private float lastGoodAspect;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        lastGoodAspect = desiredAspectRatio;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.aspect != lastGoodAspect)
        {
            float new_ratio = desiredAspectRatio / cam.aspect;
            cam.orthographicSize *= new_ratio;
            lastGoodAspect = cam.aspect;
        }
    }
}
