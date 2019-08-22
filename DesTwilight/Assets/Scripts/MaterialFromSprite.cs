using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Uses MaterialGenerator to create material and set texture to a loaded sprite
/// </summary>
[RequireComponent(typeof(MaterialGenerator))]
public class MaterialFromSprite : MonoBehaviour
{
    [SerializeField]
    Sprite sprite;

    void Awake()
    {
        Material mat = GetComponent<MaterialGenerator>().CreateMaterial();

        var texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        var pixels = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                (int)sprite.textureRect.y,
                                                (int)sprite.textureRect.width,
                                                (int)sprite.textureRect.height);
        texture.SetPixels(pixels);
        texture.Apply();
        mat.mainTexture = texture;
    }
}
