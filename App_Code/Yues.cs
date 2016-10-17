using System;
using System.Linq;
using System.Text;
using YiYue.App_Code;

public partial class Yues
{
    /*
     * Draft post for current Yue
     *  
     * Return: string 
     * */
    public string DraftPost()
    {
        StringBuilder retStr = new StringBuilder();
        //draft basic info
        string tags = Utilities.DisplayTags(Tags);
        retStr.AppendFormat("小伙伴们，{0}吗？\n", string.IsNullOrEmpty(tags) ? "约" : tags );
        retStr.AppendFormat("现在开始组织活动--{0}\n", YueName);
        retStr.AppendFormat("预计于{0}开始，地点在{1}\n", Utilities.FormatDateTime(YueDateTime, Offset.Value, Offset.Value), Location);
        if (!string.IsNullOrEmpty(Description))
            retStr.AppendFormat("{0}\n", Description);

        //draft players list
        int i = 2;
        Interacts search = new Interacts();
        search.YueId = YueID;
        Interacts[] players = Interacts.Search(search);
        if (players != null && players.Length > 0)
        {
            retStr.AppendFormat("目前人气{0} （{1}人参加，{2}人想来）\n",
                players.Length.ToString(),
                players.Count(p => p.Status == (byte)Interact_Status.Accept).ToString(),
                players.Count(p => p.Status == (byte)Interact_Status.Tentative).ToString());
            retStr.AppendFormat("1. {0}\n", CreatedBy);

            foreach (Interacts player in players.Where(p => p.Status == (byte)Interact_Status.Accept).OrderBy(p => p.UpdatedAt))
            {
                retStr.AppendFormat("{0}. {1}\n", i.ToString(), player.Player);
                i++;
            }
        }
        else
        {
            retStr.AppendFormat("1. {0}\n", CreatedBy);
        }

        int max = 10;
        if (Maximum != null && Maximum.Value > 0)
        {
            max = Math.Min(Maximum.Value, 20);
        }
        for (int j = i; j <= max; j++)
        {
            retStr.AppendFormat("{0}. \n", j.ToString());
        }

        return retStr.ToString();
    }
}

