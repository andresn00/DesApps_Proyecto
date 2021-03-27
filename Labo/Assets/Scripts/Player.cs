using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Components
    Rigidbody rb;
    
    //Config
    [Header("Configuration")]
    bool isShooting = false;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float nextShot = 0f;
    [SerializeField] float bulletSpeed = 10f;

    [Space]

    //Cache
    [Header("Cached References")]
    [SerializeField] Joystick leftJoystick;
    [SerializeField] Joystick rightJoystick;
    [Space]
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject firingPoint;
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isShooting = rightJoystick.IsPointerDown;
        HandleShoot();
    }

    private void Move()
    {
        var deltaX = leftJoystick.Horizontal * Time.deltaTime * moveSpeed;
        var deltaZ = leftJoystick.Vertical * Time.deltaTime * moveSpeed;

        transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ);

        if (!isShooting)
        {
            RotatePlayer(leftJoystick.Horizontal, leftJoystick.Vertical);
        }
    }

    private void RotatePlayer(float x, float y)
    {
        if (x != 0 && y != 0)
        {
            float rotationAngle = Mathf.Rad2Deg * Mathf.Atan2(y, x);
            Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.down);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            //transform.eulerAngles = Vector3.down * rotationAngle;
        }
    }

    private void HandleShoot()
    {
        RotatePlayer(rightJoystick.Horizontal, rightJoystick.Vertical);
        if (isShooting && Time.time >= nextShot)
        {
            nextShot = Time.time + fireRate;
            Shoot();

        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        //Instanciar bala
        GameObject projectile = Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        Vector3 newVelocity = projectile.gameObject.transform.TransformVector(Vector3.left) * bulletSpeed * Time.deltaTime;
        projectile.GetComponent<Rigidbody>().velocity = newVelocity;
    }

}
