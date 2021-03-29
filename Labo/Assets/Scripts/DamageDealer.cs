using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    float timeToDestroy = 1;
    float initialTime;
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
