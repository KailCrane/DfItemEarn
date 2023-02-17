using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSearcher : MonoBehaviour
{
    private string sever;
    private string nickname;
    private int month;
    public Button search_button;

    public SeverChanger _sever;
    public NameSearcher _name;
    public MonthSet _month;
    List<EarnItem> getepic_list = new List<EarnItem>();
    public Text debugbox;

    public ShowResult _show_reuslt;
    public CanvasChanger _changer;

    public void Awake()
    {
        _changer = GameObject.Find("CanvasChanger").GetComponent<CanvasChanger>();
    }

    public void Start()
    {
        search_button.onClick.AddListener(Search);
    }

    public void Search()
    {
        try
        {
            sever = _sever.GetSever();
            nickname = _name.GetName();
            month = _month.GetMonth();
            getepic_list.Clear();
            getepic_list.Clear();
        }
        catch
        {
            print("에러남");
            return;
        }

        //try
        //{
        if (sever != "" && nickname != "")
        {
            var split_info = Function.SplitInfo(Function.GetPlayerInfo(sever, nickname));

            /*for (int i = 0; i < split_info.Length; i++)
            {
                print(split_info[i]);
            }
            */
            //print(Function.GetTimeLine(sever, split_info[1], "20201213T0000", "20201214T2359"));
            //var timeline_result = Function.GetTimeLine(sever, split_info[1], $"{dater}20210101T0000", "20210127T2359");

            var times = Function.GetTimeLineTime(month);

            var timeline_result = Function.GetTimeLine(sever, split_info[1], times[0], times[1]);
            var player_image = Function.GetPlayerImage(sever, split_info[1]);
            //print(times[0]);
            //print(times[1]);
            //debugbox.text = Function.GetTimeLine(sever, split_info[1], "20201213T0000", "20201214T2359");

            string[] split_array = timeline_result.Split(',');

            for (int i = 0; i < split_array.Length; i++)
            {
                print($"{i}번째 칸은 {split_array[i]} 입니다.");

                if (split_array[i].Contains("아이템 획득(던전)") && (split_array[i + 4].Contains("에픽") || split_array[i + 4].Contains("신화")))
                {
                    EarnItem getEpic;
                    getEpic.date = Function.SplitEpicName(split_array[i + 1]);
                    getEpic.epic_name = Function.SplitEpicName(split_array[i + 3]);
                    getEpic.rarerity = Function.SplitEpicName(split_array[i + 4]);
                    getEpic.channel_name = Function.SplitEpicName(split_array[i + 5]);
                    if (i + 6 < split_array.Length)
                    {
                        if (split_array[i + 6].Contains("channelNo"))
                        {
                            getEpic.channel_no = Function.SplitChannelNo(split_array[i + 6]);
                        }
                        else
                        {
                            getEpic.channel_no = null;
                        }
                    }
                    else
                    {
                        getEpic.channel_no = "null";
                    }
                    getepic_list.Add(getEpic);
                }
                if (split_array[i].Contains("아이템 획득(지옥 파티)") && (split_array[i + 4].Contains("에픽") || split_array[i + 4].Contains("신화")))
                {
                    EarnItem getEpic;
                    getEpic.date = Function.SplitEpicName(split_array[i + 1]);
                    getEpic.epic_name = Function.SplitEpicName(split_array[i + 3]);
                    getEpic.rarerity = Function.SplitEpicName(split_array[i + 4]);
                    getEpic.channel_name = Function.SplitEpicName(split_array[i + 5]);
                    if(i+6 < split_array.Length)
                    {
                        getEpic.channel_no = Function.SplitChannelNo(split_array[i + 6]);
                    }
                    else
                    {
                        getEpic.channel_no = "null";
                    }
                    getepic_list.Add(getEpic);
                }
                if (split_array[i].Contains("아이템 획득(레이드)") && (split_array[i + 4].Contains("에픽") || split_array[i + 4].Contains("신화")))
                {
                    EarnItem getEpic;
                    getEpic.date = Function.SplitEpicName(split_array[i + 1 ]);
                    getEpic.epic_name = Function.SplitEpicName(split_array[i + 3]);
                    getEpic.rarerity = Function.SplitEpicName(split_array[i + 4]);
                    getEpic.channel_name = "null";
                    getEpic.channel_no = "null";
                    getepic_list.Add(getEpic);
                }
                if (split_array[i].Contains("아이템 획득(항아리)") && (split_array[i + 4].Contains("에픽") || split_array[i + 4].Contains("신화")))
                {
                    EarnItem getEpic;
                    getEpic.date = Function.SplitEpicName(split_array[i + 1]);
                    getEpic.epic_name = Function.SplitEpicName(split_array[i + 3]);
                    getEpic.rarerity = Function.SplitEpicName(split_array[i + 4]);
                    getEpic.channel_name = Function.SplitEpicName(split_array[i + 5]);
                    getEpic.channel_no = Function.SplitChannelNo(split_array[i + 6]);
                    getepic_list.Add(getEpic);
                }
            }
            for (int i = 0; i < getepic_list.Count; i++)
            {
                print(getepic_list[i].epic_name);
                print(getepic_list[i].rarerity);
            }
            _changer.ResultOn();
            _show_reuslt.Show(getepic_list, nickname, sever, player_image);
        }
        else
        {
            return;
        }
            
            //캐릭터 서칭을 하여 리턴된 값이  "rows" : [ ]라면 존재하지 않는 캐릭터 곘고 있으면은 거기서 id를 추출해내서 캐릭터 이미지를 뽑아내야지
        //}
        //catch
        //{
        //    MessageAlert.OnAlertEvent("해당 캐릭터는 존재하지 않거나. 다른 서버의 캐릭터입니다.");
        //    //에러 메세지 출력
        //}
    }

   
    public struct SendData
    {
        public Texture2D texture;
        public int epic_drop_amount;
        public int mythology_drop_amount;
        public string nickname;
        public string sever_name;
    }
}


public struct EarnItem
{
    public string epic_name;
    public string rarerity;
    public string date;
    public string channel_name;
    public string channel_no;
}

