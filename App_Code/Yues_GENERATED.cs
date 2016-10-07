/****************************************************************************/
/* Code Author (written by Xin Zhao)                                        */
/*                                                                          */
/* This file was automatically generated using Code Author.                 */
/* Any manual changes to this file will be overwritten by a automated tool. */
/*                                                                          */
/* Date Generated: 2016/10/6 20:42:46                                    */
/*                                                                          */
/* www.CodeAuthor.org                                                       */
/****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

[DataObject]
[Serializable]
public partial class Yues
{
	
	
	#region Constants
	private static readonly string TABLE_NAME = "[dbo].[Yues]";
	
	#endregion
	
	
	#region Fields
	private System.Int64? _yueID;
	private System.String _createdBy;
	private System.DateTime? _createdAt;
	private System.DateTime? _modifiedAt;
	private System.Byte? _status;
	private System.String _yueName;
	private System.DateTime? _yueDateTime;
	private System.String _duration;
	private System.Int32? _minimum;
	private System.Int32? _maximum;
	private System.String _tags;
	private System.String _description;
	private System.String _location;
	private System.String _mapUrl;
	private System.DateTime? _regiterDue;
	private System.String _notes;
	
	#endregion
	
	
	#region Properties
	public System.Int64? YueID
	{
		get
		{
			return _yueID;
		}
		set
		{
			_yueID = value;
		}
	}
	
	public System.String CreatedBy
	{
		get
		{
			return _createdBy;
		}
		set
		{
			_createdBy = value;
		}
	}
	
	public System.DateTime? CreatedAt
	{
		get
		{
			return _createdAt;
		}
		set
		{
			_createdAt = value;
		}
	}
	
	public System.DateTime? ModifiedAt
	{
		get
		{
			return _modifiedAt;
		}
		set
		{
			_modifiedAt = value;
		}
	}
	
	public System.Byte? Status
	{
		get
		{
			return _status;
		}
		set
		{
			_status = value;
		}
	}
	
	public System.String YueName
	{
		get
		{
			return _yueName;
		}
		set
		{
			_yueName = value;
		}
	}
	
	public System.DateTime? YueDateTime
	{
		get
		{
			return _yueDateTime;
		}
		set
		{
			_yueDateTime = value;
		}
	}
	
	public System.String Duration
	{
		get
		{
			return _duration;
		}
		set
		{
			_duration = value;
		}
	}
	
	public System.Int32? Minimum
	{
		get
		{
			return _minimum;
		}
		set
		{
			_minimum = value;
		}
	}
	
	public System.Int32? Maximum
	{
		get
		{
			return _maximum;
		}
		set
		{
			_maximum = value;
		}
	}
	
	public System.String Tags
	{
		get
		{
			return _tags;
		}
		set
		{
			_tags = value;
		}
	}
	
	public System.String Description
	{
		get
		{
			return _description;
		}
		set
		{
			_description = value;
		}
	}
	
	public System.String Location
	{
		get
		{
			return _location;
		}
		set
		{
			_location = value;
		}
	}
	
	public System.String MapUrl
	{
		get
		{
			return _mapUrl;
		}
		set
		{
			_mapUrl = value;
		}
	}
	
	public System.DateTime? RegiterDue
	{
		get
		{
			return _regiterDue;
		}
		set
		{
			_regiterDue = value;
		}
	}
	
	public System.String Notes
	{
		get
		{
			return _notes;
		}
		set
		{
			_notes = value;
		}
	}
	
	#endregion
	
	
	#region Methods
	
	
	#region Mapping Methods
	
	protected void MapTo(DataSet ds)
	{
		DataRow dr;
		
		
		if (ds == null)
		ds = new DataSet();
		
		if (ds.Tables["TABLE_NAME"] == null)
		ds.Tables.Add(TABLE_NAME);
		
		ds.Tables[TABLE_NAME].Columns.Add("YueID", typeof(System.Int64) );
		ds.Tables[TABLE_NAME].Columns.Add("CreatedBy", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("CreatedAt", typeof(System.DateTime) );
		ds.Tables[TABLE_NAME].Columns.Add("ModifiedAt", typeof(System.DateTime) );
		ds.Tables[TABLE_NAME].Columns.Add("Status", typeof(System.Byte) );
		ds.Tables[TABLE_NAME].Columns.Add("YueName", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("YueDateTime", typeof(System.DateTime) );
		ds.Tables[TABLE_NAME].Columns.Add("Duration", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("Minimum", typeof(System.Int32) );
		ds.Tables[TABLE_NAME].Columns.Add("Maximum", typeof(System.Int32) );
		ds.Tables[TABLE_NAME].Columns.Add("Tags", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("Description", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("Location", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("MapUrl", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("RegiterDue", typeof(System.DateTime) );
		ds.Tables[TABLE_NAME].Columns.Add("Notes", typeof(System.String) );
		
		dr = ds.Tables[TABLE_NAME].NewRow();
		
		if (YueID == null)
		dr["YueID"] = DBNull.Value;
		else
		dr["YueID"] = YueID;
		
		if (CreatedBy == null)
		dr["CreatedBy"] = DBNull.Value;
		else
		dr["CreatedBy"] = CreatedBy;
		
		if (CreatedAt == null)
		dr["CreatedAt"] = DBNull.Value;
		else
		dr["CreatedAt"] = CreatedAt;
		
		if (ModifiedAt == null)
		dr["ModifiedAt"] = DBNull.Value;
		else
		dr["ModifiedAt"] = ModifiedAt;
		
		if (Status == null)
		dr["Status"] = DBNull.Value;
		else
		dr["Status"] = Status;
		
		if (YueName == null)
		dr["YueName"] = DBNull.Value;
		else
		dr["YueName"] = YueName;
		
		if (YueDateTime == null)
		dr["YueDateTime"] = DBNull.Value;
		else
		dr["YueDateTime"] = YueDateTime;
		
		if (Duration == null)
		dr["Duration"] = DBNull.Value;
		else
		dr["Duration"] = Duration;
		
		if (Minimum == null)
		dr["Minimum"] = DBNull.Value;
		else
		dr["Minimum"] = Minimum;
		
		if (Maximum == null)
		dr["Maximum"] = DBNull.Value;
		else
		dr["Maximum"] = Maximum;
		
		if (Tags == null)
		dr["Tags"] = DBNull.Value;
		else
		dr["Tags"] = Tags;
		
		if (Description == null)
		dr["Description"] = DBNull.Value;
		else
		dr["Description"] = Description;
		
		if (Location == null)
		dr["Location"] = DBNull.Value;
		else
		dr["Location"] = Location;
		
		if (MapUrl == null)
		dr["MapUrl"] = DBNull.Value;
		else
		dr["MapUrl"] = MapUrl;
		
		if (RegiterDue == null)
		dr["RegiterDue"] = DBNull.Value;
		else
		dr["RegiterDue"] = RegiterDue;
		
		if (Notes == null)
		dr["Notes"] = DBNull.Value;
		else
		dr["Notes"] = Notes;
		
		
		ds.Tables[TABLE_NAME].Rows.Add(dr);
		
	}
	
	protected void MapFrom(DataRow dr)
	{
		YueID = dr["YueID"] != DBNull.Value ? Convert.ToInt64(dr["YueID"]) : YueID = null;
		CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToString(dr["CreatedBy"]) : CreatedBy = null;
		CreatedAt = dr["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(dr["CreatedAt"]) : CreatedAt = null;
		ModifiedAt = dr["ModifiedAt"] != DBNull.Value ? Convert.ToDateTime(dr["ModifiedAt"]) : ModifiedAt = null;
		Status = dr["Status"] != DBNull.Value ? Convert.ToByte(dr["Status"]) : Status = null;
		YueName = dr["YueName"] != DBNull.Value ? Convert.ToString(dr["YueName"]) : YueName = null;
		YueDateTime = dr["YueDateTime"] != DBNull.Value ? Convert.ToDateTime(dr["YueDateTime"]) : YueDateTime = null;
		Duration = dr["Duration"] != DBNull.Value ? Convert.ToString(dr["Duration"]) : Duration = null;
		Minimum = dr["Minimum"] != DBNull.Value ? Convert.ToInt32(dr["Minimum"]) : Minimum = null;
		Maximum = dr["Maximum"] != DBNull.Value ? Convert.ToInt32(dr["Maximum"]) : Maximum = null;
		Tags = dr["Tags"] != DBNull.Value ? Convert.ToString(dr["Tags"]) : Tags = null;
		Description = dr["Description"] != DBNull.Value ? Convert.ToString(dr["Description"]) : Description = null;
		Location = dr["Location"] != DBNull.Value ? Convert.ToString(dr["Location"]) : Location = null;
		MapUrl = dr["MapUrl"] != DBNull.Value ? Convert.ToString(dr["MapUrl"]) : MapUrl = null;
		RegiterDue = dr["RegiterDue"] != DBNull.Value ? Convert.ToDateTime(dr["RegiterDue"]) : RegiterDue = null;
		Notes = dr["Notes"] != DBNull.Value ? Convert.ToString(dr["Notes"]) : Notes = null;
	}
	
	public static Yues[] MapFrom(DataSet ds)
	{
		List<Yues> objects;
		
		
		// Initialise Collection.
		objects = new List<Yues>();
		
		// Validation.
		if (ds == null)
		throw new ApplicationException("Cannot map to dataset null.");
		else if (ds.Tables[TABLE_NAME].Rows.Count == 0)
		return objects.ToArray();
		
		if (ds.Tables[TABLE_NAME] == null)
		throw new ApplicationException("Cannot find table [dbo].[Yues] in DataSet.");
		
		if (ds.Tables[TABLE_NAME].Rows.Count < 1)
		throw new ApplicationException("Table [dbo].[Yues] is empty.");
		
		// Map DataSet to Instance.
		foreach (DataRow dr in ds.Tables[TABLE_NAME].Rows)
		{
			Yues instance = new Yues();
			instance.MapFrom(dr);
			objects.Add(instance);
		}
		
		// Return collection.
		return objects.ToArray();
	}
	
	
	#endregion
	
	
	#region CRUD Methods
	
	[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
	public static Yues Get(System.Int64 yueID)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		Yues instance;
		
		
		instance = new Yues();
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_SELECT";
		dbCommand = db.GetStoredProcCommand(sqlCommand, yueID);
		
		// Get results.
		ds = db.ExecuteDataSet(dbCommand);
		// Verification.
		if (ds == null || ds.Tables[0].Rows.Count == 0) throw new ApplicationException("Could not get Yues ID:" + yueID.ToString()+ " from Database.");
		// Return results.
		ds.Tables[0].TableName = TABLE_NAME;
		
		instance.MapFrom( ds.Tables[0].Rows[0] );
		return instance;
	}
	
	#region INSERT
	public void Insert(System.String createdBy, System.DateTime? createdAt, System.DateTime? modifiedAt, System.Byte? status, System.String yueName, System.DateTime? yueDateTime, System.String duration, System.Int32? minimum, System.Int32? maximum, System.String tags, System.String description, System.String location, System.String mapUrl, System.DateTime? regiterDue, System.String notes, DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_INSERT";
		dbCommand = db.GetStoredProcCommand(sqlCommand, createdBy, createdAt, modifiedAt, status, yueName, yueDateTime, duration, minimum, maximum, tags, description, location, mapUrl, regiterDue, notes);
		
		if (transaction == null)
		this.YueID = Convert.ToInt64(db.ExecuteScalar(dbCommand));
		else
		this.YueID = Convert.ToInt64(db.ExecuteScalar(dbCommand, transaction));
		return;
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
	public void Insert(System.String createdBy, System.DateTime? createdAt, System.DateTime? modifiedAt, System.Byte? status, System.String yueName, System.DateTime? yueDateTime, System.String duration, System.Int32? minimum, System.Int32? maximum, System.String tags, System.String description, System.String location, System.String mapUrl, System.DateTime? regiterDue, System.String notes)
	{
		Insert(createdBy, createdAt, modifiedAt, status, yueName, yueDateTime, duration, minimum, maximum, tags, description, location, mapUrl, regiterDue, notes, null);
	}
	/// <summary>
	/// Insert current Yues to database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Insert(DbTransaction transaction)
	{
		Insert(CreatedBy, CreatedAt, ModifiedAt, Status, YueName, YueDateTime, Duration, Minimum, Maximum, Tags, Description, Location, MapUrl, RegiterDue, Notes, transaction);
	}
	
	/// <summary>
	/// Insert current Yues to database.
	/// </summary>
	public void Insert()
	{
		this.Insert((DbTransaction)null);
	}
	#endregion
	
	
	#region UPDATE
	public static void Update(System.Int64? yueID, System.String createdBy, System.DateTime? createdAt, System.DateTime? modifiedAt, System.Byte? status, System.String yueName, System.DateTime? yueDateTime, System.String duration, System.Int32? minimum, System.Int32? maximum, System.String tags, System.String description, System.String location, System.String mapUrl, System.DateTime? regiterDue, System.String notes, DbTransaction transaction)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_UPDATE";
		dbCommand = db.GetStoredProcCommand(sqlCommand);
		db.DiscoverParameters(dbCommand);
		dbCommand.Parameters["@yueID"].Value = yueID;
		dbCommand.Parameters["@createdBy"].Value = createdBy;
		dbCommand.Parameters["@createdAt"].Value = createdAt;
		dbCommand.Parameters["@modifiedAt"].Value = modifiedAt;
		dbCommand.Parameters["@status"].Value = status;
		dbCommand.Parameters["@yueName"].Value = yueName;
		dbCommand.Parameters["@yueDateTime"].Value = yueDateTime;
		dbCommand.Parameters["@duration"].Value = duration;
		dbCommand.Parameters["@minimum"].Value = minimum;
		dbCommand.Parameters["@maximum"].Value = maximum;
		dbCommand.Parameters["@tags"].Value = tags;
		dbCommand.Parameters["@description"].Value = description;
		dbCommand.Parameters["@location"].Value = location;
		dbCommand.Parameters["@mapUrl"].Value = mapUrl;
		dbCommand.Parameters["@regiterDue"].Value = regiterDue;
		dbCommand.Parameters["@notes"].Value = notes;
		
		if (transaction == null)
		db.ExecuteNonQuery(dbCommand);
		else
		db.ExecuteNonQuery(dbCommand, transaction);
		return;
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
	public static void Update(System.Int64? yueID, System.String createdBy, System.DateTime? createdAt, System.DateTime? modifiedAt, System.Byte? status, System.String yueName, System.DateTime? yueDateTime, System.String duration, System.Int32? minimum, System.Int32? maximum, System.String tags, System.String description, System.String location, System.String mapUrl, System.DateTime? regiterDue, System.String notes)
	{
		Update(yueID, createdBy, createdAt, modifiedAt, status, yueName, yueDateTime, duration, minimum, maximum, tags, description, location, mapUrl, regiterDue, notes, null);
	}
	
	public static void Update(Yues yues)
	{
		yues.Update();
	}
	
	public static void Update(Yues yues, DbTransaction transaction)
	{
		yues.Update(transaction);
	}
	
	/// <summary>
	/// Updates changes to the database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Update(DbTransaction transaction)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_UPDATE";
		dbCommand = db.GetStoredProcCommand(sqlCommand);
		db.DiscoverParameters(dbCommand);
		dbCommand.Parameters["@yueID"].SourceColumn = "YueID";
		dbCommand.Parameters["@createdBy"].SourceColumn = "CreatedBy";
		dbCommand.Parameters["@createdAt"].SourceColumn = "CreatedAt";
		dbCommand.Parameters["@modifiedAt"].SourceColumn = "ModifiedAt";
		dbCommand.Parameters["@status"].SourceColumn = "Status";
		dbCommand.Parameters["@yueName"].SourceColumn = "YueName";
		dbCommand.Parameters["@yueDateTime"].SourceColumn = "YueDateTime";
		dbCommand.Parameters["@duration"].SourceColumn = "Duration";
		dbCommand.Parameters["@minimum"].SourceColumn = "Minimum";
		dbCommand.Parameters["@maximum"].SourceColumn = "Maximum";
		dbCommand.Parameters["@tags"].SourceColumn = "Tags";
		dbCommand.Parameters["@description"].SourceColumn = "Description";
		dbCommand.Parameters["@location"].SourceColumn = "Location";
		dbCommand.Parameters["@mapUrl"].SourceColumn = "MapUrl";
		dbCommand.Parameters["@regiterDue"].SourceColumn = "RegiterDue";
		dbCommand.Parameters["@notes"].SourceColumn = "Notes";
		
		ds = new DataSet();
		this.MapTo( ds );
		ds.AcceptChanges();
		ds.Tables[0].Rows[0].SetModified();
		if (transaction == null)
		db.UpdateDataSet(ds, TABLE_NAME, null, dbCommand, null, UpdateBehavior.Standard);
		else
		db.UpdateDataSet(ds, TABLE_NAME, null, dbCommand, null, transaction);
		return;
	}
	
	/// <summary>
	/// Updates changes to the database.
	/// </summary>
	public void Update()
	{
		this.Update((DbTransaction)null);
	}
	#endregion
	
	
	#region DELETE
	[DataObjectMethodAttribute(DataObjectMethodType.Delete, false)]
	public static void Delete(System.Int64? yueID, DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_DELETE";
		dbCommand = db.GetStoredProcCommand(sqlCommand, yueID);
		
		// Execute.
		if (transaction != null)
		{
			db.ExecuteNonQuery(dbCommand, transaction);
		}
		else
		{
			db.ExecuteNonQuery(dbCommand);
		}
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
	public static void Delete(System.Int64? yueID)
	{
		Delete(
		yueID, (DbTransaction)null);
	}
	
	/// <summary>
	/// Delete current Yues from database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Delete(DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_DELETE";
		dbCommand = db.GetStoredProcCommand(sqlCommand, YueID);
		
		// Execute.
		if (transaction != null)
		{
			db.ExecuteNonQuery(dbCommand, transaction);
		}
		else
		{
			db.ExecuteNonQuery(dbCommand);
		}
		this.YueID = null;
	}
	
	/// <summary>
	/// Delete current Yues from database.
	/// </summary>
	public void Delete()
	{
		this.Delete((DbTransaction)null);
	}
	
	#endregion
	
	
	#region SEARCH
	[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
	public static Yues[] Search(System.Int64? yueID, System.String createdBy, System.DateTime? createdAt, System.DateTime? modifiedAt, System.Byte? status, System.String yueName, System.DateTime? yueDateTime, System.String duration, System.Int32? minimum, System.Int32? maximum, System.String tags, System.String description, System.String location, System.String mapUrl, System.DateTime? regiterDue, System.String notes)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspYues_SEARCH";
		dbCommand = db.GetStoredProcCommand(sqlCommand, yueID, createdBy, createdAt, modifiedAt, status, yueName, yueDateTime, duration, minimum, maximum, tags, description, location, mapUrl, regiterDue, notes);
		
		ds = db.ExecuteDataSet(dbCommand);
		ds.Tables[0].TableName = TABLE_NAME;
		return Yues.MapFrom(ds);
	}
	
	
	public static Yues[] Search(Yues searchObject)
	{
		return Search ( searchObject.YueID, searchObject.CreatedBy, searchObject.CreatedAt, searchObject.ModifiedAt, searchObject.Status, searchObject.YueName, searchObject.YueDateTime, searchObject.Duration, searchObject.Minimum, searchObject.Maximum, searchObject.Tags, searchObject.Description, searchObject.Location, searchObject.MapUrl, searchObject.RegiterDue, searchObject.Notes);
	}
	
	/// <summary>
	/// Returns all Yues objects.
	/// </summary>
	/// <returns>List of all Yues objects. </returns>
	[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
	public static Yues[] Search()
	{
		return Search ( null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
	}
	
	#endregion
	
	
	#endregion
	
	
	#endregion
	
	
}

