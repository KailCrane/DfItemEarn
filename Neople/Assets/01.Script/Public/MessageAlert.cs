using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAlert : MonoBehaviour
{
    public GameObject alert_panel;
    public Text alert_textbox;
    private float timer;
    private float reset_time = 3;
    private bool isMessageOn = false;

    public delegate void AlertEvent(string message);
    public static AlertEvent OnAlertEvent;

    private void Awake()
    {
        OnAlertEvent += new AlertEvent(AlertMessageSend);
    }

    private void Start()
    {
        isMessageOn = false;
        timer = reset_time;
        alert_panel.SetActive(false);
    }

    void Update()
    {
        if (isMessageOn)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = reset_time;
                alert_panel.SetActive(false);
                isMessageOn = false;
            }
        }
    }

    public void AlertMessageSend(string message)
    {
        alert_panel.SetActive(true);
        alert_textbox.text = message;
        isMessageOn = true;
    }
}