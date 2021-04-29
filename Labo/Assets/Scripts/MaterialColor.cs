using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MaterialColor : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;

    [Header("Colors")]
    [SerializeField] Color baseColor = Color.white;
    [SerializeField] Color emissionColor = Color.white;
    [SerializeField] float intensity = 0f;

    [Header("Texture")]
    [SerializeField] Texture texture;
    [SerializeField] float tilesX;
    [SerializeField] float tilesY;

    private Renderer renderer;
    private MaterialPropertyBlock propBlock;

    // Start is called before the first frame update
    void Awake()
    {
        propBlock = new MaterialPropertyBlock();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.sharedMaterial == null)
        {
            renderer.sharedMaterial = defaultMaterial;
        }
        if (propBlock == null)
        {
            propBlock = new MaterialPropertyBlock();
            Debug.Log("propBlock es null");
        }
        if (texture)
        {
            propBlock.SetTexture("_BaseMap", texture);
            propBlock.SetTexture("_EmissionMap", texture);
            propBlock.SetVector("_BaseMap_ST", new Vector4(tilesX, tilesY, 0, 0));
        }
        else
        {
            propBlock.Clear();
        }
        propBlock.SetColor("_BaseColor", baseColor);
        propBlock.SetColor("_EmissionColor", emissionColor * intensity);
        
        renderer.SetPropertyBlock(propBlock);
    }
}
