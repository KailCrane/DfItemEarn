using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    public GameObject main_body; //메인 바디 제일 상위 개체
    public GameObject sub_body; //보조 개체 내용 부분에 해당 됩니다.

    public void Update()
    {
        Point();
    }

    public void Point() //포인트 중인 서브 메뉴를 하이라트 처리하라고 명령을 때려줄 것이다.
    {

    }

    public void MainClick()
    {
        sub_body.SetActive(true);
    }

    public void Close()
    {
        //닫는 조건
        //1. 메인 메뉴나 서브 메뉴가 아닌 다른 오브젝트가 클릭 되었을 때
        //2. 선택을 완료하여 명령을 해야 할때
        // 여기에 사용되는 Close는 모두를 끄는것을 가정하자
        sub_body.SetActive(false);
    }


}