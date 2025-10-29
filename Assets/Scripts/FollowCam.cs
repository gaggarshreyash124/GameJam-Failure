using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 1, -5);

    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
