using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public ItemInfo _iteminfo;

    public Text sever_text_box;
    public Text charactet_textbox;
    public Text total_epic_textbox;
    public Text total_mythology_textbox;
    public Text total_luck_textbox;
    public CanvasChanger _changer;

    public List<EarnItem> earn_list;
    public GameObject detail_panel;
    public GameObject detail_panel2;
    public GameObject epic_detail_panel;
    public GameObject mythology_detail_panel;


    public Button detail_epic_button;
    public Button detail_mythology_button;

    public Image score_image;

    public List<Sprite> score_sprites = new List<Sprite>();

    int epic_amount = 0;
    int mythology_amount = 0;
    int total_value = 0;

    public Image player_image;

    public void Awake()
    {
        sever_text_box = GameObject.Find("Sever_Text_Box").GetComponent<Text>();
        charactet_textbox = GameObject.Find("Charactet_Textbox").GetComponent<Text>();
        total_epic_textbox = GameObject.Find("Total_Epic_Textbox").GetComponent<Text>();
        total_mythology_textbox = GameObject.Find("Total_Mythology_Textbox").GetComponent<Text>();
        total_luck_textbox = GameObject.Find("Total_Luck_Textbox").GetComponent<Text>();
        _changer = GameObject.Find("CanvasChanger").GetComponent<CanvasChanger>();
    }
    public void Start()
    {
        _changer.SearchOn();
        detail_epic_button.onClick.AddListener(DetailInfoEpic);
        detail_mythology_button.onClick.AddListener(DetailInfoMythology);
    }

    public void Show(List<EarnItem> _earns, string character_name, string sever_name, Texture2D _player_image)
    {
        earn_list = new List<EarnItem>();
        earn_list = _earns;

        List<EarnItem> epic_list = new List<EarnItem>();
        List<EarnItem> mythology_list = new List<EarnItem>();

        epic_amount = 0;
        mythology_amount = 0;
        total_value = 0;

        for (int i = 0; i < detail_panel.transform.childCount; i++)
        {
            detail_panel.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < earn_list.Count; i++)
        {
            for (int j = 0; j < _iteminfo.item_list.Count; j++)
            {
                if (earn_list[i].epic_name == _iteminfo.item_list[j].name)
                {
                    total_value += _iteminfo.item_list[j].value;

                    if (_iteminfo.item_list[j].rarity == Item.Rarity.Epic)
                    {
                        print(_iteminfo.item_list[j].name);
                        epic_amount++;
                        epic_list.Add(earn_list[i]);
                    }
                    if (_iteminfo.item_list[j].rarity == Item.Rarity.Mythology)
                    {
                        print(_iteminfo.item_list[j].name);
                        mythology_list.Add(earn_list[i]);
                        mythology_amount++;
                    }
                }
            }
        }
        print("결과 확인");

        for (int i = 0; i < epic_list.Count; i++)
        {
            detail_panel.transform.GetChild(i).gameObject.SetActive(true);
            detail_panel.transform.GetChild(i).GetComponent<ResultItem>().earn_item = epic_list[i];
            detail_panel.transform.GetChild(i).gameObject.name = epic_list[i].epic_name;
        }
        for (int i = 0; i < epic_list.Count; i++)
        {
            for (int j = 0; j < _iteminfo.item_list.Count; j++)
            {
                if (detail_panel.transform.GetChild(i).gameObject.name == _iteminfo.item_list[j].name)
                {
                    print($"{epic_list[i].epic_name} 과 {_iteminfo.item_list[j].name}");

                    detail_panel.transform.GetChild(i).GetComponent<ResultItem>().item = _iteminfo.item_list[j];
                    break;
                }
            }
        }
        for (int i = 0; i < detail_panel2.transform.childCount; i++)
        {
            detail_panel2.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < mythology_list.Count; i++)
        {
            detail_panel2.transform.GetChild(i).gameObject.SetActive(true);
            detail_panel2.transform.GetChild(i).GetComponent<ResultItem>().earn_item = mythology_list[i];
            detail_panel2.transform.GetChild(i).gameObject.name = mythology_list[i].epic_name;
        }
        for (int i = 0; i < mythology_list.Count; i++)
        {
            for (int j = 0; j < _iteminfo.item_list.Count; j++)
            {
                if (detail_panel2.transform.GetChild(i).gameObject.name == _iteminfo.item_list[j].name)
                {
                    print($"{mythology_list[i].epic_name} 과 {_iteminfo.item_list[j].name}");

                    detail_panel2.transform.GetChild(i).GetComponent<ResultItem>().item = _iteminfo.item_list[j];
                    break;
                }
            }
        }

        total_epic_textbox.text = epic_amount.ToString();
        total_mythology_textbox.text = mythology_amount.ToString();
        total_luck_textbox.text = total_value.ToString();
        charactet_textbox.text = character_name;
        sever_text_box.text = sever_name;
        Rect rect = new Rect(0, 0, _player_image.width, _player_image.height);
        player_image.sprite = Sprite.Create(_player_image, rect, new Vector2(_player_image.width/2, _player_image.height / 2));



        if (total_value>= 0 && 70 > total_value)
        {
            score_image.sprite = score_sprites[0];
        }
        if (total_value >= 70 && 100 > total_value)
        {
            score_image.sprite = score_sprites[1];
        }
        if (total_value >= 100 && 150 > total_value)
        {
            score_image.sprite = score_sprites[2];
        }
        if (total_value >= 150 && 200 > total_value)
        {
            score_image.sprite = score_sprites[3];
        }
        if (total_value >= 200)
        {
            score_image.sprite = score_sprites[4];
        }
    }

    public void DetailInfoEpic()
    {
        epic_detail_panel.SetActive(true);
    }
    public void DetailInfoMythology()
    {
        mythology_detail_panel.SetActive(true);
    }
}
