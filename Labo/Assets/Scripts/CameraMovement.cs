using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 5, -6);

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + cameraOffset;
        }
    }
}
