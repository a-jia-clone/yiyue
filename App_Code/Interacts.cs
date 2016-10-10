using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
public partial class Interacts
{
    private Yues _yue;
    public Yues Yue
    {
        get
        {
            return _yue;
        }
        set
        {
            _yue = value;
        }
    }

    public static Interacts[] SearchFull(Interacts searchObject)
    {
        DataSet ds;
        Database db;
        string sqlCommand;
        DbCommand dbCommand;

        db = DatabaseFactory.CreateDatabase();
        sqlCommand = "[dbo].gspInteracts_SEARCH_FULL";
        dbCommand = db.GetStoredProcCommand(sqlCommand, searchObject.YueId, searchObject.Player, searchObject.Status);

        ds = db.ExecuteDataSet(dbCommand);
        ds.Tables[0].TableName = TABLE_NAME;
        return Interacts.MapFromFull(ds);
    }

    public static Interacts[] MapFromFull(DataSet ds)
    {
        List<Interacts> objects;

        // Initialise Collection.
        objects = new List<Interacts>();

        // Validation.
        if (ds == null)
            throw new ApplicationException("Cannot map to dataset null.");
        else if (ds.Tables[TABLE_NAME].Rows.Count == 0)
            return objects.ToArray();

        if (ds.Tables[TABLE_NAME] == null)
            throw new ApplicationException("Cannot find table [dbo].[Interacts] in DataSet.");

        if (ds.Tables[TABLE_NAME].Rows.Count < 1)
            throw new ApplicationException("Table [dbo].[Interacts] is empty.");

        // Map DataSet to Instance.
        foreach (DataRow dr in ds.Tables[TABLE_NAME].Rows)
        {
            Interacts instance = new Interacts();
            instance.MapFromFull(dr);
            objects.Add(instance);
        }

        // Return collection.
        return objects.ToArray();
    }

    protected void MapFromFull(DataRow dr)
    {
        InteractId = dr["InteractId"] != DBNull.Value ? Convert.ToInt64(dr["InteractId"]) : InteractId = null;
        YueId = dr["YueId"] != DBNull.Value ? Convert.ToInt64(dr["YueId"]) : YueId = null;
        Player = dr["Player"] != DBNull.Value ? Convert.ToString(dr["Player"]) : Player = null;
        ViewedAt = dr["ViewedAt"] != DBNull.Value ? Convert.ToDateTime(dr["ViewedAt"]) : ViewedAt = null;
        UpdatedAt = dr["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(dr["UpdatedAt"]) : UpdatedAt = null;
        Status = dr["Status"] != DBNull.Value ? Convert.ToByte(dr["Status"]) : Status = null;
        Notes = dr["Notes"] != DBNull.Value ? Convert.ToString(dr["Notes"]) : Notes = null;
        Offset = dr["Offset"] != DBNull.Value ? Convert.ToInt32(dr["Offset"]) : Offset = null;
        if (Yue == null) Yue = new Yues();
        Yue.YueID = dr["YueID"] != DBNull.Value ? Convert.ToInt64(dr["YueID"]) : Yue.YueID = null;
        Yue.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToString(dr["CreatedBy"]) : Yue.CreatedBy = null;
        Yue.CreatedAt = dr["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(dr["CreatedAt"]) : Yue.CreatedAt = null;
        Yue.ModifiedAt = dr["ModifiedAt"] != DBNull.Value ? Convert.ToDateTime(dr["ModifiedAt"]) : Yue.ModifiedAt = null;
        Yue.Status = dr["Status"] != DBNull.Value ? Convert.ToByte(dr["YueStatus"]) : Yue.Status = null;
        Yue.YueName = dr["YueName"] != DBNull.Value ? Convert.ToString(dr["YueName"]) : Yue.YueName = null;
        Yue.YueDateTime = dr["YueDateTime"] != DBNull.Value ? Convert.ToDateTime(dr["YueDateTime"]) : Yue.YueDateTime = null;
        Yue.Duration = dr["Duration"] != DBNull.Value ? Convert.ToString(dr["Duration"]) : Yue.Duration = null;
        Yue.Minimum = dr["Minimum"] != DBNull.Value ? Convert.ToInt32(dr["Minimum"]) : Yue.Minimum = null;
        Yue.Maximum = dr["Maximum"] != DBNull.Value ? Convert.ToInt32(dr["Maximum"]) : Yue.Maximum = null;
        Yue.Tags = dr["Tags"] != DBNull.Value ? Convert.ToString(dr["Tags"]) : Yue.Tags = null;
        Yue.Description = dr["Description"] != DBNull.Value ? Convert.ToString(dr["Description"]) : Yue.Description = null;
        Yue.Location = dr["Location"] != DBNull.Value ? Convert.ToString(dr["Location"]) : Yue.Location = null;
        Yue.MapUrl = dr["MapUrl"] != DBNull.Value ? Convert.ToString(dr["MapUrl"]) : Yue.MapUrl = null;
        Yue.RegiterDue = dr["RegiterDue"] != DBNull.Value ? Convert.ToDateTime(dr["RegiterDue"]) : Yue.RegiterDue = null;
        Yue.Notes = dr["Notes"] != DBNull.Value ? Convert.ToString(dr["YueNotes"]) : Yue.Notes = null;
        Yue.Offset = dr["Offset"] != DBNull.Value ? Convert.ToInt32(dr["YueOffset"]) : Yue.Offset = null;
    }
}

