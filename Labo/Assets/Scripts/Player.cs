using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Components
    Rigidbody rb;
    
    //Config
    [SerializeField] float moveSpeed = 5f;
    float rotationAngle = -45f;

    //Cache
    [SerializeField] Joystick leftJoystick;
    [SerializeField] Joystick rightJoystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ);

        CalculatePlayerRotation(leftJoystick.Horizontal, leftJoystick.Vertical);
    }

    private void CalculatePlayerRotation(float x, float y)
    {
        if (x != 0 && y != 0)
        {
            rotationAngle = Mathf.Rad2Deg * Mathf.Atan2(y, x);
        }
        transform.eulerAngles = Vector3.down * rotationAngle;
    }
}
