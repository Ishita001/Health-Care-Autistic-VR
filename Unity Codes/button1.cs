using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{

    public int scored;
    public Image gaze;
    public float totaltime = 2f;
    bool gvrstatus;
    float gvrTimer;

    public GameObject normButt;
    public GameObject propButt;

    public GameObject trigs;
    public GameObject rat;
    public GameObject circle;

    private RaycastHit hit;

    private void Start()
    {
        normButt.SetActive(true);
        propButt.SetActive(false);

        gaze.fillAmount = 0;
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out hit))
        {
            if (gaze.fillAmount == 1 && hit.transform.name == "1")
            {
                scored = 1;
            }
            if (gaze.fillAmount == 1 && hit.transform.name == "2")
            {
                scored = 2;
            }
            if (gaze.fillAmount == 1 && hit.transform.name == "3")
            {
                scored = 3;
            }
            if (gaze.fillAmount == 1 && hit.transform.name == "4")
            {
                scored = 4;
            }
        }


        if(scored == randomFloorSelector.currentFloor)
        {
            normButt.SetActive(false);
            propButt.SetActive(true);
            trigs.SetActive(false);
            rat.SetActive(false);
            circle.SetActive(false);
        }

        if (gvrstatus)
        {
            gvrTimer += Time.deltaTime;
            gaze.fillAmount = gvrTimer / totaltime;

        }


    }

    public void gvrOn()
    {
        gvrstatus = true;
    }

    public void gvrOff()
    {
        gvrstatus = false;
        gvrTimer = 0;
        gaze.fillAmount = 0;
    }
}