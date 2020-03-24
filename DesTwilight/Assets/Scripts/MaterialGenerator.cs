using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Creates a material and loads into meshRenderer
/// </summary>
public class MaterialGenerator : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshRenderer;

    public Material CreateMaterial(string shader = "Standard")
    {
        if (!meshRenderer)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        Material material = new Material(Shader.Find(shader));
        StandardShaderUtils.ChangeRenderMode(material, StandardShaderUtils.BlendMode.Cutout);

        meshRenderer.material = material;
        return material;
    }

    public void SetMaterial(Material mat)
    {
        meshRenderer.material = mat;
    }
}
