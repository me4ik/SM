using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollP : NetworkBehaviour
{
    private Transform playerT;

    private Transform camTrans;
    private Camera mainCam;

    public float smoothSpeed = 0.125f;

    private void Awake()
    {
        mainCam = Camera.main;
        camTrans = mainCam.GetComponent<Transform>();
        playerT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        Vector3 currentPosition = camTrans.transform.position;


        Vector3 desiredPosition = new Vector3(playerT.position.x, playerT.position.y, currentPosition.z);
        Vector3 smoothedPosition = Vector3.Lerp(currentPosition, desiredPosition, smoothSpeed);

        camTrans.transform.position = smoothedPosition;

    }

    
}
