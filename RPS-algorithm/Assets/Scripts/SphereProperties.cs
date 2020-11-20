using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereProperties : MonoBehaviour
{
    public GameObject FollowingObj;
    public Slider sliderStepMag;
    private float velocity_x = 0f;
    private float velocity_y = 0f;
    private float stpMag = 1000f;

    float other_x;
    float other_y;
    float this_x;
    float this_y;

    private void Update()
    {
        stpMag = sliderStepMag.value;
    }

    public void ResetVelocity()
    {
        velocity_x = 0f;
        velocity_y = 0f;
    }

    // updates called by main
    public void UpdateVelocity()
    {
        //get x and y values of other object
        other_x = 1f * FollowingObj.transform.position.x;
        other_y = 1f * FollowingObj.transform.position.y;
        this_x = 1f * gameObject.transform.position.x;
        this_y = 1f * gameObject.transform.position.y;

        //set velocity
        velocity_x += -(this_x - other_x) / (stpMag);
        velocity_y += -(this_y - other_y) / (stpMag);
    }
    public void UpdatePostion()
    {
        Vector3 temp = new Vector3(velocity_x, velocity_y, 0);
        gameObject.transform.position += temp;
    }
}
