using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasChanger : MonoBehaviour
{
    public GameObject search_canvas;
    public GameObject result_canvas;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public Button btn;

    public void Awake()
    {
        search_canvas = GameObject.Find("SearchCanvas");
        result_canvas = GameObject.Find("ResultCanvas");
        btn.onClick.AddListener(SearchOn);
    }

    public void SearchOn()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        search_canvas.SetActive(true);
        result_canvas.SetActive(false);
    }

    public void ResultOn()
    {
        result_canvas.SetActive(true);
        search_canvas.SetActive(false);
    }
    
}
