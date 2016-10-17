using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace YiYue.App_Code
{
    public enum Yue_Status
    {
        Active = 1,
        Expired = 2,
        Cancelled = 3
    }

    public enum Interact_Status
    {
        Viewed = 0,
        Accept = 1,
        Tentative = 2,
        Reject = 3
    }

    public static class Utilities
    {
        /*
         * Display datetime in Chinese format
         * Parameters: datatime, offset, local_offset 
         * Return: string (e.g.: "10月28日 周日 20时整")
         * */
        public static string FormatDateTime(DateTime? dt, int offset, int local_offset)
        {
            string retStr = "";
            if (dt == null) return retStr;
            DateTime offsetDt = dt.Value.AddMinutes(0 - offset);
            if (offsetDt.Year != DateTime.Now.Year)
                retStr = String.Format("{0}年", offsetDt.Year.ToString());
            retStr += String.Format("{0}月{1}日 {2} {3}时{4}",
                offsetDt.Month.ToString(),
                offsetDt.Day.ToString(),
                ChineseWeekday((byte)offsetDt.DayOfWeek).ToString(),
                offsetDt.Hour.ToString(),
                offsetDt.Minute > 0 ? offsetDt.Minute.ToString() + "分" : "整");

            return retStr;
        }

        public static string ChineseWeekday(byte number)
        {
            switch (number)
            {
                case 0: return "周日";
                case 1: return "周一";
                case 2: return "周二";
                case 3: return "周三";
                case 4: return "周四";
                case 5: return "周五";
                case 6: return "周六";
                default: return "";
            }
        }

        public static string YueStatus(byte? index)
        {
            if (index == null)
                return "";
            switch (index.Value)
            {
                case ((byte)Yue_Status.Active): return "开启报名";
                case ((byte)Yue_Status.Expired): return "截止报名";
                case ((byte)Yue_Status.Cancelled): return "活动取消";
                default: return "";
            }
        }

        public static string InteractStatus(byte? index)
        {
            if (index == null)
                return "";
            switch (index.Value)
            {
                case ((byte)Interact_Status.Accept): return "参加";
                case ((byte)Interact_Status.Tentative): return "待定";
                case ((byte)Interact_Status.Reject): return "婉拒";
                case ((byte)Interact_Status.Viewed): return "看过";
                default: return "";
            }
        }

        /*
         * Display yue's title
         * Parameters: yueName, yueStartDateTime, titleType
         * Return: string
         * */
        public static string YueTitle(string yueName, string yueStartDateTime, string titleType = "约吗?")
        {
            return String.Format("{0} {1} {2}", titleType, yueName, yueStartDateTime);
        }

        /*
         * Display tags as a string
         * Parameters: tag ids (format: "1,2,13,19,")
         * Return: string (e.g.: "吃饭 唱歌 派对")
         * */
        public static string DisplayTags(string tags)
        {
            StringBuilder retStr = new StringBuilder();
            if (tags != null && !String.IsNullOrEmpty(tags))
            {
                string[] tagIDs = tags.Split(',');
                foreach (string tagID in tagIDs)
                {
                    short id = 0;
                    if (short.TryParse(tagID, out id))
                    {
                        Tags t = Tags.Get(id);
                        if (t != null)
                            retStr.Append(t.TagName + " ");
                    }
                }
            }
            return retStr.ToString().Trim();
        }

    }
}