using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectChercker : MonoBehaviour
{

    public void Start()
    {
        ConnectCheck();
    }

    public void ConnectCheck()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            print("네트워크 연결이 되지 않음");
            MessageAlert.OnAlertEvent("네트워크가 연결되지 않았습니다. 네트워크 연결뒤 다시 실행 시켜 주십시오");
            StartCoroutine("QuitApk");
        }
        else
        {
            print("네트워크 연결 됨");
       
        }
    }

    private IEnumerator QuitApk()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}