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

    private void DestroyItself()
    {
        if (Time.time >= initialTime + timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
    
}

