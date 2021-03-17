using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float moveSpeed = 5f;

    //Cache
    [SerializeField] Joystick leftJoystick;
    [SerializeField] Joystick rightJoystick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = leftJoystick.Horizontal * Time.deltaTime * moveSpeed;
        var deltaZ = leftJoystick.Vertical * Time.deltaTime * moveSpeed;

        Vector3 movement = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ);
        transform.position = movement;
    }
}
