using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using System;

public static class Function
{
    #region "플레이어 정보 반환"

    public static string GetPlayerInfo(string sever, string playername)
    {
        string fixed_url = "https://api.neople.co.kr/df/servers/" + sever + "/characters?characterName=" + TSTU(playername) + "&apikey=" +PublicKey.api_key;
        // HttpWebRequest 타입은 내부적으로 TCP 소켓을 생성하고
        HttpWebRequest req = WebRequest.Create(fixed_url) as HttpWebRequest;

        // GetResponse 호출 단계에서 지정된 웹 서버로 HTTP 요청을 보내고, 응답을 받는다.
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            string responseText = sr.ReadToEnd();
            return responseText;
        }
    }
    #endregion

    #region "플레이어 정보 끊기"
    public static string[] SplitInfo(string value)
    {
        string[] split_aray = value.Split(new char[] { '"' });

        split_aray[16] = split_aray[16].Replace(":","");
        split_aray[16] = split_aray[16].Replace(",","");
        string[] fixed_array = { split_aray[5], split_aray[9], split_aray[13], split_aray[16], split_aray[19], split_aray[23], split_aray[27], split_aray[31] };
        //6 , 10, 14, 17, 20, 24 ,28, 32
        return fixed_array;
    }
    #endregion

    #region "플레이어 이미지 텍스쳐 반환" 
    public static Texture2D GetPlayerImage(string sever, string player_id)
    {
        //string url = "https://img-api.neople.co.kr/df/servers/casillas/characters/e092eef6bb731a16afe953a4b4fbc8a4?zoom=3";
        string fixed_url = "https://img-api.neople.co.kr/df/servers/" + sever + "/characters/" + player_id + "?zoom=" + 3.ToString();
        HttpWebRequest req = WebRequest.Create(fixed_url) as HttpWebRequest;

        // GetResponse 호출 단계에서 지정된 웹 서버로 HTTP 요청을 보내고, 응답을 받는다.
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        byte[] data = null;

        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            using (MemoryStream mr = new MemoryStream())
            {
                var buffer = new byte[512];
                var bytesRead = default(int);
                while ((bytesRead = sr.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    mr.Write(buffer, 0, bytesRead);
                }
                data = mr.ToArray();
            }
        }
        return  bytesToTexture2D(data);
    }
    #endregion

    #region "아이템 정보 반환"
    public static string GetItemInfo(string item_name)
    {

        return null;
    }

    #endregion

    #region "아이템 이미지 ID 반환"

    public static string GetItemId(string item_name)
    {
        return null;
    }

    #endregion

    #region "아이템 이미지 반환"
    public static Texture GetItemImage(string item_id)
    {
        string url = "https://img-api.neople.co.kr/df/items/e98db581d86ffc2098c66049b019cf83";
        HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;

        // GetResponse 호출 단계에서 지정된 웹 서버로 HTTP 요청을 보내고, 응답을 받는다.
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        byte[] data = null;

        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            using (MemoryStream mr = new MemoryStream())
            {
                var buffer = new byte[512];
                var bytesRead = default(int);
                while ((bytesRead = sr.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    mr.Write(buffer, 0, bytesRead);
                }
                data = mr.ToArray();
            }
        }
        return bytesToTexture2D(data);
    }
    #endregion

    #region "이미지 바이트 텍스쳐 전환"
    public static Texture2D bytesToTexture2D(byte[] imageBytes)
    {
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imageBytes);
        return tex;
    }
    #endregion

    #region "string 유니코드 변환"
    public static string TSTU(string value)
    {
        return Uri.EscapeUriString(value);
    }

    #endregion

    #region "시작 시간 끝 시간 반환"

    public static string[] GetTimeLineTime(int month)
    {
        string curr_year = DateTime.Now.ToString("yyyy");
        string curr_month = month.ToString("D2");
        string start_day = "01";
        string end_day;

        string start_time;
        string end_time;


        string[] return_value = new string[2];

        start_time = "0000";

        if (curr_month == DateTime.Now.ToString("MM"))
        {
            end_day = DateTime.Now.ToString("dd");
            end_time = DateTime.Now.ToString("HHmm");
        }
        else
        {
            end_day = DateTime.DaysInMonth(Convert.ToInt32(curr_year), Convert.ToInt32(curr_month)).ToString("D2");
            end_time = "2359";
        }
        return_value[0] = curr_year + curr_month + start_day + "T" + start_time;
        return_value[1] = curr_year + curr_month + end_day + "T" + end_time;

        return return_value;
    }

    #endregion

    #region "에픽 이름 짜르기"

    public static string SplitEpicName(string value)
    {
        string[] first_split = value.Split('"');

        string return_value;

        return_value = first_split[3];

        return return_value;
    }

    #endregion

    #region "채널 번호 짜르기"

    public static string SplitChannelNo(string value)
    {
        string[] first_split = value.Split('"');

        string return_value;

        return_value = first_split[2].Replace(":","");

        return return_value;
    }
    #endregion

    #region "타임라인 반환"

    #region "검색 일자 포함 반환"
    public static string GetTimeLine(string sever, string player_id,string start, string end)
    {
        string url = "https://api.neople.co.kr/df/servers/<serverId>/characters/<characterId>/timeline?limit=100&startDate=<startDate>&endDate=<endDate>&apikey=<apikey>";
        string fixed_url;
        fixed_url = url.Replace("<serverId>", sever);
        fixed_url = fixed_url.Replace("<characterId>", player_id);
        fixed_url = fixed_url.Replace("<startDate>", start);
        fixed_url = fixed_url.Replace("<endDate>", end);
        fixed_url = fixed_url.Replace("<apikey>", PublicKey.api_key);

        HttpWebRequest req = WebRequest.Create(fixed_url) as HttpWebRequest;

        // GetResponse 호출 단계에서 지정된 웹 서버로 HTTP 요청을 보내고, 응답을 받는다.
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            string responseText = sr.ReadToEnd();
            return responseText;
        }
    }
    #endregion

    #region "검색 일자 미포함 반환"
    public static string GetTimeLine(string sever, string player_id)
    {
        string url = "https://api.neople.co.kr/df/servers/<serverId>/characters/<characterId>/timeline?apikey=<apikey>";
        string fixed_url;
        fixed_url = url.Replace("<serverId>", sever);
        fixed_url = fixed_url.Replace("<characterId>", player_id);
        fixed_url = fixed_url.Replace("<apikey>", PublicKey.api_key);

        HttpWebRequest req = WebRequest.Create(fixed_url) as HttpWebRequest;

        // GetResponse 호출 단계에서 지정된 웹 서버로 HTTP 요청을 보내고, 응답을 받는다.
        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
        {
            string responseText = sr.ReadToEnd();
            return responseText;
        }
    }
    #endregion

    #endregion
}
