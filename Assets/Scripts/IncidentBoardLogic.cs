using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncidentBoardLogic : MonoBehaviour
{

    [SerializeField]
    private float clickPointRadius;
    public List<GameObject> markerXCoords, markerYCoords;
    private List<float> clickXCoords, clickYCoords;

    private int clickedCircle = -1;
    private Camera mainCam;
    private int dayMarkerPosition = -1;
    private int loopMarkerPosition = -1;
    private int extraMarkerPosition = -1;
    private HashSet<int> incidentMarkerPositions = new HashSet<int>();
    private SpriteRenderer dayMarkerSR, loopMarkerSR, extraMarkerSR;
    private class IncidentMarker {
        public GameObject marker;
        public int position;
    }
    private List<IncidentMarker> incidentMarkers = new List<IncidentMarker>();
    
    
    private void Awake()
    {
        // populate the coordinate lists for the click hotspots
        clickXCoords = new List<float>();
        clickYCoords = new List<float>();
        foreach (GameObject go in markerXCoords)
        {
            clickXCoords.Add(go.transform.position.x);
            GameObject.Destroy(go);
        }
        foreach (GameObject go in markerYCoords)
        {
            clickYCoords.Add(go.transform.position.y);
            GameObject.Destroy(go);
        }
        
        // find and cache sprite renderers for the various markers
        SpriteRenderer[] tempSprites = GetComponentsInChildren<SpriteRenderer>();
        dayMarkerSR = tempSprites[1];
        dayMarkerSR.transform.position = new Vector2(clickXCoords[0], clickYCoords[0]);
        loopMarkerSR = tempSprites[2];
        loopMarkerSR.transform.position = new Vector2(clickXCoords[2], clickYCoords[0]);
        extraMarkerSR = tempSprites[3];
        extraMarkerSR.gameObject.SetActive(false);

        // setup the first incident marker and the list for new ones
        IncidentMarker im = new IncidentMarker
        {
            marker = tempSprites[4].gameObject,
            position = -1
        };
        incidentMarkers.Add(im);
        incidentMarkers[0].marker.SetActive(false);
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

    private void IncidentMarkerClicked(int pos)
    {
        // if clicking an existing marker, set it inactive
        if (incidentMarkerPositions.Contains(pos))
        {
            incidentMarkerPositions.Remove(pos);
            var im = FindIncidentMarkerAtPosition(pos);
            im.position = -1;
            im.marker.SetActive(false);
        }
        // if clicking an empty space, find a free marker and place it there
        else
        {
            var im = GetFreeIncidentMarker();
            im.marker.transform.position = new Vector2(clickXCoords[1], clickYCoords[pos / 4]);
            im.marker.SetActive(true);
            im.position = pos;
            incidentMarkerPositions.Add(pos);
        }
    }

    private void LoopMarkerClick(int pos)
    {
        loopMarkerPosition = pos;
        Vector2 tempPos = new Vector2();
        tempPos.x = clickXCoords[2];
        tempPos.y = clickYCoords[pos / 4];
        loopMarkerSR.transform.position = tempPos;
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

    private IncidentMarker GetFreeIncidentMarker()
    {
        foreach (IncidentMarker im in incidentMarkers)
        {
            if (im.marker.activeSelf == false)
            {
                im.marker.SetActive(true);
                return im;
            }
        }
        // no inactive incident markers, so make a new one.  We know index zero always exists.
        GameObject newMarker = GameObject.Instantiate(incidentMarkers[0].marker, this.transform);
        IncidentMarker newIM = new IncidentMarker
        {
            marker = newMarker,
            position = -1
        };

        incidentMarkers.Add(newIM);
        return newIM;
    }

    private IncidentMarker FindIncidentMarkerAtPosition(int pos)
    {
        foreach (var im in incidentMarkers)
        {
            if (im.position == pos) return im;
        }
        return null;
    }
}
