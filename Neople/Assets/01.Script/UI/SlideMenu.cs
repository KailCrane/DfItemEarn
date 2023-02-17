using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideMenu : MonoBehaviour
{
    public GameObject content;
    public List<GameObject> contents = new List<GameObject>();
    public Vector3 init_vec3;
    public float space_y;
    public Button menu_btn;
    public GameObject enable_panel;

    void Start()
    {
        for (int i = 0; i < contents.Count; i++)
        {
            contents[i].transform.SetParent(content.transform);
            contents[i].transform.localPosition = init_vec3 + new Vector3(0, space_y * i, 0);
        }
        menu_btn.onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {
        enable_panel.SetActive(true);
    }
}
