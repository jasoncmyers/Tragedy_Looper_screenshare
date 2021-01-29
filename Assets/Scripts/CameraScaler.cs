using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    Camera cam;
    public float desiredAspectRatio = 16f / 9f;
    private float lastGoodAspect;
    private float heightPx;
    private float heightOrtho;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = this.GetComponent<Camera>();
        lastGoodAspect = desiredAspectRatio;
        heightOrtho = cam.orthographicSize;
        heightPx = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.aspect != lastGoodAspect)
        {
            NewScale();
        }
    }

    void NewScale()
    {
        
        float screenAspect = (float)Screen.width / (float)Screen.height;
        if (screenAspect < desiredAspectRatio)
        {
            // the screen isn't wide enough, so reduce the height and letterbox it
            cam.orthographicSize = heightOrtho * desiredAspectRatio / screenAspect;
        }
        else
        {
            // if wide enough, reset to the default and let the automated height scaling handle it
            cam.orthographicSize = heightOrtho;
        }

        lastGoodAspect = cam.aspect;
    }
}
