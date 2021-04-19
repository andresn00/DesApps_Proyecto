using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timeToDestroy = 1;
    float initialTime;
    //efecto
    public GameObject efecto;
    public ContactPoint contact;
    public Quaternion rot;
    public Vector3 pos;
    public float TiempoDeVida;
    // Start is called before the first frame update
    void Start()
    {
        initialTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyItself();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            contact = collision.contacts[0];
            rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            pos = contact.point;
            Instantiate(efecto, pos, rot);

        }

    }

    private void DestroyItself()
    {
        if (Time.time >= initialTime + timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
    
}

