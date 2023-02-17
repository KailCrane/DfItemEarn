using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Test : MonoBehaviour
{
    public Image image;

    public void Start()
    {
        ShowImage();
    }

    public void ShowImage()
    {
        Texture2D texture = Function.GetItemImage("")as Texture2D;
        Rect rect = new Rect(0, 0, texture.width, texture.height);

        image.GetComponent<Image>().sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));





        //image.GetComponent<Sprite>().texture = Function.GetItemImage("");
    }
}