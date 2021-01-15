using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncidentBoardLogic : MonoBehaviour
{

    public Sprite loopMarker;
    public Sprite dayMarker;
    public Sprite incidentMarker;
    public Sprite extraMarker;

    [Space]
    public float clickPointRadius;
    public List<float> clickXCoords;
    public List<float> clickYCoords;


    private int clickedCircle = -1;
    private Camera mainCam;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clickedCircle = GetTargetCircle((Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnMouseUpAsButton()
    {
        if (clickedCircle == -1) return;

        int clickReleaseCirlce = GetTargetCircle((Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition));
        if (clickedCircle == clickReleaseCirlce)
        {
            HandleCircleClick(clickReleaseCirlce);
        }
    }


    // returns -1 if no valid target
    private int GetTargetCircle(Vector2 inputPos)
    {
        for (int i = 0; i < clickXCoords.Count; i++)
        {
            for (int j = 0; j < clickYCoords.Count; j++)
            {
                float x = clickXCoords[i];
                float y = clickYCoords[j];
                if (Vector2.Distance(inputPos, new Vector2(x, y)) < clickPointRadius)
                {
                    return (j * clickXCoords.Count + i);
                }
            }
        }
        return -1;
    }

    private void HandleCircleClick(int circleClicked)
    {
        Debug.Log("Clicked and released inside circle " + circleClicked);
    }
}
