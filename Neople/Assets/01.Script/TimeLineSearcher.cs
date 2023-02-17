using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineSearcher : MonoBehaviour
{

    // 타임 라인 검색에 필요한것.
    // 1. 서버.
    // 2. 플레이어 고유 코드.
    // 3. 검색 시작 일자.
    // 4. 검색 종료 일자.
    // 6. 검색 범위 (에픽을 디푤트로 잡아 놓자 )


    [System.Serializable]
    public struct Code
    {
        public int num;
        public string content;
    }

    public List<Code> timeline_code = new List<Code>();

    private int month;

}
