using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    float targetFOV = 60f;
    float sizeDecrement = 2f;
    float initialFOV = 60f;
    public float shrinkChange = 15f; //Shrink Zone Decreemnt
    public float smoothRate = 5f; // Value for smoother transition
    public Camera cam; //set main camera to this variable

    private float cameraTimer;
    private float currentFOV;

    bool didZoneShrink = false;
    // Use this for initialization
    void Start()
    {
        cam.orthographicSize = initialFOV;
    }
    // Update is called once per frame
    void Update()
    {
        currentFOV = cam.orthographicSize; //keep track of Current FOV

        if (Input.GetKeyDown("a")) //Use this code to test shrink
        {
            ShrinkFOV(shrinkChange);
            Debug.Log("Pressed A");
        }
        if (didZoneShrink) //Zone is shrinking
        {
            ChangeFOV();
        }

    }
    public void ShrinkFOV(float viewSize)
    {
        targetFOV -= viewSize; //Change target size
        didZoneShrink = true;
        Debug.Log("In ShrinkFOV");
    }

    public void ChangeFOV()
    {
        Debug.Log("In Change FOV");
        if (currentFOV != targetFOV) //Is currentFOV caught up to targetFOV?
        {
            if (currentFOV >= targetFOV)
            {
                cam.orthographicSize += (-smoothRate * Time.deltaTime); //Smooth transition
            }
            else
            {
                if (currentFOV <= targetFOV) //If currentFOV goes over, set equal to TargetFOV
                {
                    cam.orthographicSize = targetFOV;
                    didZoneShrink = false; //done shrinking
                }
            }
        }
    }



}
