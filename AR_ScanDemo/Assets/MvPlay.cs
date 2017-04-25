using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvPlay : MonoBehaviour
{



    // Use this for initialization
    void Start()
    {

        Debug.Log("Movie Player ");
        bool bSucc = Handheld.PlayFullScreenMovie("newSun.mp4");
        Debug.Log("bSucc = " + bSucc);
    }

    //    Update is called once per frame

    void Update()
    {

        TextAsset myText = GetComponent<TextAsset>();
        bool bLeftMousePressed = Input.GetMouseButtonDown(0);
        if (bLeftMousePressed)
        {
            Debug.Log("left mouse pressed. need to call device camera!!");
        }
    }
}