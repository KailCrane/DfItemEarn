using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public List<Item> item_list = new List<Item>();


    public void Start()
    {
        for (int i = 0; i < item_list.Count; i++)
        {
            if (item_list[i].value == 0)
            {
                print(item_list[i].name);
            }
        }
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public int value;
    public enum Rarity {Epic ,Mythology };
    public Rarity rarity;
    public Sprite sprite;
}
