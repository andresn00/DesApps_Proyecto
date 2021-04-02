using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColor : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] Color baseColor = Color.white;
    [SerializeField] Color emissionColor = Color.white;
    [SerializeField] bool emission = false;
    [SerializeField] float intensity = 0;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            //renderer.material = material;
            renderer.material.color = baseColor;
            if (emission)
            {
                renderer.material.EnableKeyword("_EMISSION");
                renderer.material.SetColor("_EmissionColor", emissionColor * intensity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
