using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : NetworkBehaviour
{

    public Transform followTransform;
    public float smoothSpeed = 0.125f;

    private Camera mainCam;
    // Start is called before the firstframe update

    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;

        
        Vector3 desiredPosition = new Vector3(followTransform.position.x, followTransform.position.y, currentPosition.z);
        Vector3 smoothedPosition = Vector3.Lerp(currentPosition, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
    }
}
