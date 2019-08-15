using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a material and loads into meshRenderer
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class MaterialGenerator : MonoBehaviour
{
    public Material CreateMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        Material material = new Material(Shader.Find("Standard"));

        meshRenderer.material = material;
        return material;
    }
}
