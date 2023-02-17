using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpicPanelClose : MonoBehaviour
{
    private Button close_btn;
    public GameObject earnList_panel;
    public GameObject describe;

    private void Awake()
    {
        close_btn = GetComponent<Button>();
        close_btn.onClick.AddListener(Close);
    }

    public void Close()
    {
        describe.SetActive(false);
        earnList_panel.SetActive(false);
    }
}
