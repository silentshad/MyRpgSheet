using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Crosstales.FB;
using UnityEngine.UI;
using System.IO;
using System;

public class file_menu : MonoBehaviour
{
    [SerializeField] private GameObject img_panel;
  
    public void exit()
    {
        Application.Quit();
    }

    public void new_file()
    {
        // temporary
        import();
        // temporary
    }

    public void import(string path, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {
        img_panel.SetActive(true);
       Image img = img_panel.transform.GetChild(0).gameObject.GetComponent<Image>();

        Texture2D SpriteTexture = LoadTexture(path);
        Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);

        img.sprite = NewSprite;
    }

    private Texture2D LoadTexture(string path)
    {
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(path))
        {
            FileData = File.ReadAllBytes(path);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    public void import()
    {
        string path = FileBrowser.OpenSingleFile("png");

        import(path);
    }


}
