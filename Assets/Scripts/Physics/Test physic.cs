using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpringUtils;
using static UnityEngine.GraphicsBuffer;

public class Testphysic : MonoBehaviour
{
    public float velocity = 5f;
    public Vector3 velocity3;
    float posX = 1f;
    tDampedSpringMotionParams pOutParams;
    public float target = 1.25f;
    public Transform target3;
    public bool b_IsHolding = false;
    void Start()
    {
        pOutParams = new tDampedSpringMotionParams();
        CalcDampedSpringMotionParams(ref pOutParams, .1f, 4.5f, .01f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!b_IsHolding)
        {
            //posX = transform.position.x;
            //UpdateDampedSpringMotion(ref posX, ref velocity, target, pOutParams);

            //transform.position = new Vector3(posX, transform.position.y, transform.position.z);

            Vector3 pos3 = transform.position;
            UpdateDampedSpringMotionVector3(ref pos3, ref velocity3, target3.position, pOutParams);
            transform.position = pos3;
        }
        else
        {
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Mouse X") / 11f, transform.position.y, transform.position.z);
        }
       
        
    }

    private void OnMouseDown()
    {
        b_IsHolding = true;
    }

    private void OnMouseUp()
    {
        b_IsHolding = false;
    }
}
