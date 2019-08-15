using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Creates objects from prefab with a material created with all textures found in the texturesPath directory
/// </summary>
public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    string texturesPath;

    void Start()
    {
        if (!prefab.GetComponent<MaterialGenerator>()) throw new System.Exception("Prefabs must have Material Generator");

        Texture2D[] textures = FileFunctions.GetAtPath<Texture2D>(texturesPath);
        foreach(Texture2D texture in textures)
        {
            GameObject instance = Instantiate(prefab);
            Material material = instance.GetComponent<MaterialGenerator>().CreateMaterial();
            material.mainTexture = texture;
        }
    }

    

}
