using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class FootccerExtensions
{
    /// <summary>
    /// "2023-09-09 오후 9:50:30"; 형태로 받아온다고 가정합니다.
    /// </summary>
    /// <param name="dateStr"></param>
    /// <param name="indicateYear"></param>
    /// <returns></returns>
    public static string ParseToString_FromDateString(this string dateStr, bool indicateYear)
    {
        string[] splits = dateStr.Split(' ');

        string strYYYYMMDD = splits[0];
        string[] dateParts = strYYYYMMDD.Split('-');
        int Year = int.Parse(dateParts[0]);
        int Month = int.Parse(dateParts[1]);
        int Day = int.Parse(dateParts[2]);

        string AMPM = splits[1]; //오전, 오후 두 값 중 하나입니다.

        string strHHMMSS = splits[2];
        string[] timeParts = strHHMMSS.Split(':');
        int Hour = int.Parse(timeParts[0]);
        int Minute = int.Parse(timeParts[1]);
        int Second = int.Parse(timeParts[2]);

        string result =
            (indicateYear ? $"{Year}년 " : string.Empty) +
            $"{Month}월 {Day}일 {AMPM} {Hour}시 {Minute}분";
        return result;
    }
    public static string ParseToString_FromDateTime(this DateTime dt, bool indicateYear)
    {
        string datePart =
            indicateYear ? $"{dt.Year}-" : string.Empty +
            $"{dt.Month}-{dt.Day}";

        string AMPM = (dt.Hour < 12) ? "오전" : "오후";

        int hour = dt.Hour % 12;
        hour += (hour == 0) ? 12 : 0;

        string timePart = $"{hour}:{dt.Minute}";

        string result = datePart + AMPM + timePart;
        return result;
    }
}

