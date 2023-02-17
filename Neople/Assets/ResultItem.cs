using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultItem : MonoBehaviour
{
    public Item item;
    private Image item_image;
    public Sprite null_image;
    public EarnItem earn_item;
    private ItemInfo _item_info;
    private Button btn;
    public ItemDescibe _item_describe;

    private void Awake()
    {
        item_image = transform.GetChild(0).gameObject.GetComponent<Image>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    private void Click()
    {
        _item_describe.gameObject.SetActive(true);
        _item_describe.date.text = earn_item.date;
        if(earn_item.channel_name =="null")
        {
            _item_describe.channel_name.text = "";
        }
        else
        {
            _item_describe.channel_name.text = earn_item.channel_name;
        }
        if (earn_item.channel_no == "null")
        {
            _item_describe.channel_no.text = "";
        }
        else
        {
            _item_describe.channel_no.text = earn_item.channel_no;
        }
    }
    
    private void Update()
    {
        if (item != null)
        {
           item_image.sprite= item.sprite;
        }
    }
}
