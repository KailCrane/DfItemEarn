using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Image character_image;
    public Text sever_textbox;
    public Text character_name_box;
    public Text epic_amount_box;
    public Text mythology_amount_box;
    public GameObject OpenPanel;

    public void ShowResult(Texture2D texture2D, string sever, string character_name, int epic_amount, int mythology_amount)
    {
        //character_image.GetComponent<Sprite>().texture = texture2D;
    }


}
