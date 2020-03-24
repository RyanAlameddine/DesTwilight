using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Creates objects from prefab with a material created with all textures found in the texturesPath directory
/// </summary>
public class ObjectGenerator : NetworkBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    string texturesPath;

    [SerializeField]
    Transform spawnTransform;

    [SerializeField]
    Texture2D alternator;

    [SerializeField]
    string name;

    void Start()
    {
        if (!isServer) return;
        if (!spawnTransform) spawnTransform = transform;

        if (prefab.GetComponents<MaterialGenerator>().Length==0) throw new System.Exception("Prefabs must have Material Generator");

        Texture2D[] textures;
        if (name == "")
        {
            textures = FileFunctions.GetAtPath<Texture2D>(texturesPath);
        }
        else
        {
            textures = FileFunctions.GetAtPathByName<Texture2D>(texturesPath, name);
        }
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

            foreach (var generator in instance.GetComponents<MaterialGenerator>())
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

                AssetDatabase.CreateAsset(material, "Assets/GeneratedMats/" + texture.name + ".mat");
                material.mainTexture = texture;
            }
            NetworkServer.Spawn(instance);
            //i--;
            //RpcLoadMats(instance, textures[i].EncodeToPNG());
            //i++;

        }
    }

    //[ClientRpc]
    //void RpcLoadMats(GameObject instance, byte[] receivedByte)
    //{
    //    var receivedTexture = new Texture2D(1, 1);
    //    receivedTexture.LoadImage(receivedByte);
    //    foreach (var generator in instance.GetComponents<MaterialGenerator>())
    //    {
    //        Material material = generator.CreateMaterial();
    //        material.mainTexture = receivedTexture;
    //    }
    //}
}
