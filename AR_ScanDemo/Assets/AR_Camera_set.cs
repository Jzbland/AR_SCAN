using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Camera_set : MonoBehaviour {

    // Use this for initialization
    //扫描聚焦
    private string label;
    private float touchduration;
    private Touch touch;

    // Use this for initialization  
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.touchCount > 0)
        {
            touchduration += Time.deltaTime;
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended && touchduration < 0.2f)
            {
                StartCoroutine("SingleOrDouble");
            }
        }
        else
        {
            touchduration = 0;
        }
    }

    IEnumerator SingleOrDouble()
    {
        yield return new WaitForSeconds(0.3f);
        if (touch.tapCount == 1)
        {
            Debug.Log("Single");
            OnSingleTapped();
        }
        else if (touch.tapCount == 2)
        {
            StopCoroutine("SingleOrDouble");
            Debug.Log("Double");
            OnDoubleTapped();
        }
    }

    private void OnSingleTapped()
    {
        TriggerAutoFocus();
        label = "Tap the Screen!";
    }

    private void OnDoubleTapped()
    {
        label = "Double Tap the Screen!";
    }

    public void TriggerAutoFocus()
    {
        StartCoroutine(TriggerAutoFocusAndEnableContinuousFocusIfSet());
    }

    private IEnumerator TriggerAutoFocusAndEnableContinuousFocusIfSet()
    {
        Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        yield return new WaitForSeconds(1.0f);
        Vuforia.CameraDevice.Instance.SetFocusMode(Vuforia.CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

}
