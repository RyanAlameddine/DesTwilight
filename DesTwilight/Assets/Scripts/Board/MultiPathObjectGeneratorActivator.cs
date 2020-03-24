using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Creates objects from prefab with a material created with all textures found in the texturesPath directory
/// </summary>
public class MultiPathObjectGeneratorActivator : Activator
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    string[] texturesPath;

    [SerializeField]
    Transform spawnTransform;

    [SerializeField]
    Texture2D alternator;

    [SerializeField]
    string name;

    [SerializeField]
    int duplicates = 0;

    static int y = 0;

    private void FixedUpdate()
    {
        y = 0;
    }

    [Command]
    public override void CmdActivate(GameObject boardGameObject)
    {
        if (!spawnTransform) spawnTransform = transform;

        for (int k = 0; k < texturesPath.Length; k++)
        {
            if (prefab.GetComponents<MaterialGenerator>().Length == 0) throw new System.Exception("Prefabs must have Material Generator");

            Texture2D[] textures;
            if (name == "")
            {
                textures = FileFunctions.GetAtPath<Texture2D>(texturesPath[k]);
            }
            else if (name == ".MaterialName")
            {

                string name = GetComponent<MeshRenderer>().material.name;
                name = name.Remove(name.Length - 11, 11);
                Debug.Log(name);
                textures = FileFunctions.GetAtPathByName<Texture2D>(texturesPath[k], name);
            }
            else if (name == ".Name")
            {
                textures = FileFunctions.GetAtPathByName<Texture2D>(texturesPath[k], gameObject.name);
            }
            else
            {
                textures = FileFunctions.GetAtPathByName<Texture2D>(texturesPath[k], name);
            }
            bool alternation = true;
            for (int i = 0; i < textures.Length;)
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
                    material.mainTexture = texture;
                }
                NetworkServer.Spawn(instance);

                for (int j = 0; j < duplicates; j++)
                {
                    NetworkServer.Spawn(Instantiate(instance));
                    y += 1;
                }
            }
        }
        if (chain)
            chain.CmdActivate(boardGameObject);
    }
}
