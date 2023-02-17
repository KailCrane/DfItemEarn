using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSelecter : MonoBehaviour
{
    public string sever;
    public static string[] severs ={"",""};

    public string character_name;
    
    public void ServerSelect()
    {

    }

    public void NickNameChange(string value)
    {
        character_name = value;
    }

}

public class SeverSelecter
{


}

