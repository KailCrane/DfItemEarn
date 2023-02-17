using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class NameSearcher : MonoBehaviour
{
    private string information = "검색할 닉네임을 적어주세요";
    public InputField search_field;//닉네임을 입력할 필드
    private string curr_name;


    public void Start()
    {
        if (search_field == null)
        {
            //Debug.LogError("검색 창이 존재 하지 않습니다, 드래그 드롭이 되어있는지 확인 해주시길 바랍니다");
            search_field.GetComponent<InputField>();
        }
        search_field.lineType = InputField.LineType.SingleLine; //무조건 한줄만 검색할 수 있음
        search_field.text = information;
        search_field.textComponent.color = Color.gray; //아직 닉네임을 검색 하지않은 상태임으로 안내 글자니까 색을 검정으로 바꿔야 한다.
        search_field.onValueChanged.AddListener(delegate { RemoveSpace(); });
        search_field.onValueChanged.AddListener(delegate { SpecialSymbol(); });
        search_field.onEndEdit.AddListener(delegate { EditDone(); });
    }
    public void Update()
    {
        if (search_field.isFocused)//클릭되어 있는 상태일때
        {
            print("포커스 상태");
            if (search_field.text == information)//만약에 안내 문구인 상태라면
            {
                search_field.text = ""; // 안내 문구를 지우고 백지로 만들어준다
                search_field.textComponent.color = Color.black; //회색이였다 문자를 검은색으로 바꿔준다
            }
        }
        else
        {
            return;
        }

    }

    public void EditDone()
    {
        //print("에딧 완료");
        if (search_field.text == "")
        {
            curr_name = search_field.text;
            Reset();
           //  print("아무것도 입력하지 않았습니다");
        }
        else
        {
            curr_name = search_field.text;
        }
    }

    public void RemoveSpace() //텍스트 필드의 스페이스바 입력을 금지 시키는것 스페이스바를 입력하면 바""로 대체 해버려 금지된것 처럼 만드는것이다
    {
        //print("공백 제거");
        search_field.text = search_field.text.Replace(" ", "");
    }

    public void SpecialSymbol() //위의 공백 제거와 같은 원리 던파에서는 사용할 수 있는 특수 기호가 있으니 주의
    {

    }

    public string GetName()
    {
        return curr_name;
    }

    public void Reset()
    {
        search_field.text = information;
        search_field.textComponent.color = Color.gray;
    }
}