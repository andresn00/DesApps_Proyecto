using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Components
    Rigidbody rb;
    Animator animator;

    //Config
    [Header("Configuration")]
    [SerializeField] int lives = 3;
    bool isShooting = false;
    bool isMoving = false;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float nextShot = 0f;
    [SerializeField] float bulletSpeed = 10f;

    [Space]
    public GameObject efecto;
    public ContactPoint contact;
    public Quaternion rot;
    public Vector3 pos;
    public float TiempoDeVida;

    //Cache
    [Header("Cached References")]
    [SerializeField] Joystick leftJoystick;
    [SerializeField] Joystick rightJoystick;
    [Space]
    [SerializeField] AudioClip shotSFX;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject firingPoint;
    [SerializeField] GameObject bullet;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isShooting = rightJoystick.IsPointerDown;
        HandleShoot();
        TiempoDeVida -=Time.deltaTime;
        if(TiempoDeVida <=0)
        {
            Instantiate(efecto, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
        }
    }

    private void Move()
    {
        if (leftJoystick.Horizontal != 0 && leftJoystick.Vertical != 0)
        {
            var deltaX = leftJoystick.Horizontal * Time.deltaTime * moveSpeed;
            var deltaZ = leftJoystick.Vertical * Time.deltaTime * moveSpeed;

            transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + deltaZ);
            isMoving = true;
            animator.SetBool("isMoving", isMoving);
            animator.speed = leftJoystick.Direction.magnitude;
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
            animator.speed = 1;
        }

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
        AudioSource.PlayClipAtPoint(shotSFX, transform.position);
        GameObject projectile = Instantiate(bullet, firingPoint.transform.position, firingPoint.transform.rotation);
        Vector3 newVelocity = projectile.gameObject.transform.TransformVector(Vector3.left) * bulletSpeed * Time.deltaTime;
        projectile.GetComponent<Rigidbody>().velocity = newVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            contact = collision.contacts[0];
            rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            pos = contact.point;
            Instantiate(efecto, pos, rot);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        lives--;
        if (lives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameSession.GameOver();

        Destroy(gameObject);
    }

    public int GetLives()
    {
        return lives;
    }
}
