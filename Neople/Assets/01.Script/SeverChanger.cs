using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeverChanger : MonoBehaviour
{
    private string curr_sever;
    private string curr_sever_id;
    public Text curr_sever_textbox;

    public List<string> sever_list = new List<string>();
    public List<string> sever_id_list = new List<string>();
    public List<Button> buttons = new List<Button>();

    private ContextMenu _contextMenu;

    private void Start()
    {
        _contextMenu = GetComponent<ContextMenu>();
        curr_sever = sever_list[0];
        curr_sever_id = sever_id_list[0];
        curr_sever_textbox.text = curr_sever;

        
        for (int i = 0; i < buttons.Count; i++)
        {
            int _i = i;
            buttons[i].onClick.AddListener(delegate { SeverChange(_i); });
        }
    }

    public string GetSever()
    {
        return curr_sever_id;
    }

    private void SeverChange(int num)
    {
        curr_sever = sever_list[num];
        curr_sever_id = sever_id_list[num];
        curr_sever_textbox.text = curr_sever;
        //모든 창을 꺼줘야함
        _contextMenu.Close();
    }
}
