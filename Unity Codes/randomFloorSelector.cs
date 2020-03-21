using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class randomFloorSelector : MonoBehaviour
{
    private int floor;
    public static int currentFloor;
    public Text startingUI;

    void Start()
    {
        floor = (int)Random.Range(1, 5);
        currentFloor = floor;
        startingUI.text = "Go to Floor " + currentFloor;
    }

    void Update()
    {

    }
}
