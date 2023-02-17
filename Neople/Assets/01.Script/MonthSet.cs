using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthSet : MonoBehaviour
{
    private int curr_month;
    private int default_month = 1;
    
    public Text curr_month_textbox;

    private List<int> month_list = new List<int>();
    public List<Button> buttons = new List<Button>();
    public GameObject disable_panel;

    private void Start()
    {
        curr_month = default_month;

        for (int i = 1; i < 13; i++)
        {
            month_list.Add(i);
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            int _i = i;
            buttons[i].onClick.AddListener(delegate { MonthChange(_i); });
            buttons[i].gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i+1).ToString();
        }
    }

    public int GetMonth()
    {
        return curr_month;
    }

    private void MonthChange(int num)
    {
        //print(num);
        curr_month = month_list[num];
        curr_month_textbox.text = curr_month.ToString();
        disable_panel.SetActive(false);
        //모든 창을 꺼줘야함
        //_contextMenu.Close();
    }
}
