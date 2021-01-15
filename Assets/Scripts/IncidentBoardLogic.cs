using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncidentBoardLogic : MonoBehaviour
{

    public Sprite loopMarkerSprite;
    public Sprite dayMarkerSprite;
    public Sprite incidentMarkerSprite;
    public Sprite extraMarkerSprite;

    [Space]
    public float clickPointRadius;
    public List<float> clickXCoords;
    public List<float> clickYCoords;

    private int clickedCircle = -1;
    private Camera mainCam;
    private int dayMarkerPosition = -1;
    private int loopMarkerPosition = -1;
    private int extraMarkerPosition = -1;
    private HashSet<int> incidentMarkerPositions = new HashSet<int>();
    private SpriteRenderer dayMarkerSR, loopMarkerSR, extraMarkerSR;





    private void Awake()
    {
        SpriteRenderer[] tempSprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in tempSprites)
        {
            Debug.Log("Spriterender found with name " + sr.name);
        }
        dayMarkerSR = tempSprites[1];
        dayMarkerSR.transform.position = new Vector2(clickXCoords[0], clickYCoords[0]);
        loopMarkerSR = tempSprites[2];
        loopMarkerSR.transform.position = new Vector2(clickXCoords[2], clickYCoords[0]);
        extraMarkerSR = tempSprites[3];
        extraMarkerSR.gameObject.SetActive(false);


    }


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
            clickedCircle = -1;
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
        if (circleClicked % 4 == 0) // clicked on a "day" circle
        {
            DayMarkerClick(circleClicked);
        }
        else if (circleClicked % 4 == 1)
        {
            IncidentMarkerClicked(circleClicked);
        }
        else if (circleClicked % 4 == 2)
        {
            LoopMarkerClick(circleClicked);
        }
        else if (circleClicked % 4 == 3)
        {
            ExtraGaugeClicked(circleClicked);
        }
    }

    private void DayMarkerClick(int pos)
    {
        dayMarkerPosition = pos;
        Vector2 tempPos = new Vector2();
        tempPos.x = clickXCoords[0];
        tempPos.y = clickYCoords[pos / 4];
        dayMarkerSR.transform.position = tempPos;
        //dayMarkerSR.gameObject.SetActive(true);
    }

    private void LoopMarkerClick(int pos)
    {
        loopMarkerPosition = pos;
        Vector2 tempPos = new Vector2();
        tempPos.x = clickXCoords[2];
        tempPos.y = clickYCoords[pos / 4];
        loopMarkerSR.transform.position = tempPos;
    }

    private void IncidentMarkerClicked(int pos)
    {

    }

    private void ExtraGaugeClicked(int pos)
    {
        if (pos == extraMarkerPosition)
        {
            extraMarkerPosition = -1;
            extraMarkerSR.gameObject.SetActive(false);
        }
        else
        {
            extraMarkerPosition = pos;
            Vector2 tempPos = new Vector2();
            tempPos.x = clickXCoords[3];
            tempPos.y = clickYCoords[pos / 4];
            extraMarkerSR.transform.position = tempPos;
            extraMarkerSR.gameObject.SetActive(true);
        }
    }
}
