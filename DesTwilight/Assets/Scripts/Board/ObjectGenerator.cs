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

    [SerializeField]
    Transform spawnTransform;

    [SerializeField]
    Texture2D alternator;

    void Start()
    {
        if (prefab.GetComponents<MaterialGenerator>().Length==0) throw new System.Exception("Prefabs must have Material Generator");

        Texture2D[] textures = FileFunctions.GetAtPath<Texture2D>(texturesPath);
        int y = 0;
        bool alternation = true;
        for(int i = 0; i < textures.Length;)
        {
            if (textures[i] == alternator)
            {
                i++;
                continue;
            }

            GameObject instance = Instantiate(prefab, spawnTransform.position + new Vector3(0, y, 0), Quaternion.identity);
            y += 1;

            foreach(var generator in instance.GetComponents<MaterialGenerator>())
            {
                Texture2D texture;
                if (alternator && alternation)
                {
                    texture = alternator;
                }
                else
                {
                    texture = textures[i];
                    i++;
                }
                alternation = !alternation;
                Material material = generator.CreateMaterial();
                material.mainTexture = texture;
            }

        }
    }
}
