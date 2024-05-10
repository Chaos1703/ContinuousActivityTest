using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowScript : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset = new Vector3(1.21061396f, 10.3149142f, -15.6445966f); 

    void Update()
    {
        transform.position = playerTransform.position + offset;
    }
}