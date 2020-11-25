using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform camTr;
    private bool isAssign = false;

    public Transform playerTr;

    private void Start()
    {
        Application.targetFrameRate = 60;
        camTr = GetComponent<Transform>();
        Invoke("FindPlayerObj", 0.1f);
    }
    public void FindPlayerObj()
    {
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        isAssign = true;
    }

    private void FixedUpdate()
    {
        if (isAssign)
        {
            CameraMovement();
        }
    }

    public void CameraMovement()
    {
        camTr.position = Vector3.Slerp(camTr.position,
            new Vector3(playerTr.position.x, playerTr.position.y, camTr.position.z), 3f * Time.fixedDeltaTime);
    }
}
