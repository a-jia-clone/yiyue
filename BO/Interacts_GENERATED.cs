/****************************************************************************/
/* Code Author (written by Xin Zhao)                                        */
/*                                                                          */
/* This file was automatically generated using Code Author.                 */
/* Any manual changes to this file will be overwritten by a automated tool. */
/*                                                                          */
/* Date Generated: 2016/10/7 23:37:20                                    */
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
public partial class Interacts
{
	
	
	#region Constants
	private static readonly string TABLE_NAME = "[dbo].[Interacts]";
	
	#endregion
	
	
	#region Fields
	private System.Int64? _interactId;
	private System.Int64? _yueId;
	private System.String _player;
	private System.DateTime? _viewedAt;
	private System.DateTime? _updatedAt;
	private System.Byte? _status;
	private System.String _notes;
	private System.Int32? _offset;
	
	#endregion
	
	
	#region Properties
	public System.Int64? InteractId
	{
		get
		{
			return _interactId;
		}
		set
		{
			_interactId = value;
		}
	}
	
	public System.Int64? YueId
	{
		get
		{
			return _yueId;
		}
		set
		{
			_yueId = value;
		}
	}
	
	public System.String Player
	{
		get
		{
			return _player;
		}
		set
		{
			_player = value;
		}
	}
	
	public System.DateTime? ViewedAt
	{
		get
		{
			return _viewedAt;
		}
		set
		{
			_viewedAt = value;
		}
	}
	
	public System.DateTime? UpdatedAt
	{
		get
		{
			return _updatedAt;
		}
		set
		{
			_updatedAt = value;
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
	
	public System.Int32? Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
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
		
		ds.Tables[TABLE_NAME].Columns.Add("InteractId", typeof(System.Int64) );
		ds.Tables[TABLE_NAME].Columns.Add("YueId", typeof(System.Int64) );
		ds.Tables[TABLE_NAME].Columns.Add("Player", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("ViewedAt", typeof(System.DateTime) );
		ds.Tables[TABLE_NAME].Columns.Add("UpdatedAt", typeof(System.DateTime) );
		ds.Tables[TABLE_NAME].Columns.Add("Status", typeof(System.Byte) );
		ds.Tables[TABLE_NAME].Columns.Add("Notes", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("Offset", typeof(System.Int32) );
		
		dr = ds.Tables[TABLE_NAME].NewRow();
		
		if (InteractId == null)
		dr["InteractId"] = DBNull.Value;
		else
		dr["InteractId"] = InteractId;
		
		if (YueId == null)
		dr["YueId"] = DBNull.Value;
		else
		dr["YueId"] = YueId;
		
		if (Player == null)
		dr["Player"] = DBNull.Value;
		else
		dr["Player"] = Player;
		
		if (ViewedAt == null)
		dr["ViewedAt"] = DBNull.Value;
		else
		dr["ViewedAt"] = ViewedAt;
		
		if (UpdatedAt == null)
		dr["UpdatedAt"] = DBNull.Value;
		else
		dr["UpdatedAt"] = UpdatedAt;
		
		if (Status == null)
		dr["Status"] = DBNull.Value;
		else
		dr["Status"] = Status;
		
		if (Notes == null)
		dr["Notes"] = DBNull.Value;
		else
		dr["Notes"] = Notes;
		
		if (Offset == null)
		dr["Offset"] = DBNull.Value;
		else
		dr["Offset"] = Offset;
		
		
		ds.Tables[TABLE_NAME].Rows.Add(dr);
		
	}
	
	protected void MapFrom(DataRow dr)
	{
		InteractId = dr["InteractId"] != DBNull.Value ? Convert.ToInt64(dr["InteractId"]) : InteractId = null;
		YueId = dr["YueId"] != DBNull.Value ? Convert.ToInt64(dr["YueId"]) : YueId = null;
		Player = dr["Player"] != DBNull.Value ? Convert.ToString(dr["Player"]) : Player = null;
		ViewedAt = dr["ViewedAt"] != DBNull.Value ? Convert.ToDateTime(dr["ViewedAt"]) : ViewedAt = null;
		UpdatedAt = dr["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(dr["UpdatedAt"]) : UpdatedAt = null;
		Status = dr["Status"] != DBNull.Value ? Convert.ToByte(dr["Status"]) : Status = null;
		Notes = dr["Notes"] != DBNull.Value ? Convert.ToString(dr["Notes"]) : Notes = null;
		Offset = dr["Offset"] != DBNull.Value ? Convert.ToInt32(dr["Offset"]) : Offset = null;
	}
	
	public static Interacts[] MapFrom(DataSet ds)
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
			instance.MapFrom(dr);
			objects.Add(instance);
		}
		
		// Return collection.
		return objects.ToArray();
	}
	
	
	#endregion
	
	
	#region CRUD Methods
	
	[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
	public static Interacts Get(System.Int64 interactId)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		Interacts instance;
		
		
		instance = new Interacts();
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspInteracts_SELECT";
		dbCommand = db.GetStoredProcCommand(sqlCommand, interactId);
		
		// Get results.
		ds = db.ExecuteDataSet(dbCommand);
		// Verification.
		if (ds == null || ds.Tables[0].Rows.Count == 0) throw new ApplicationException("Could not get Interacts ID:" + interactId.ToString()+ " from Database.");
		// Return results.
		ds.Tables[0].TableName = TABLE_NAME;
		
		instance.MapFrom( ds.Tables[0].Rows[0] );
		return instance;
	}
	
	#region INSERT
	public void Insert(System.Int64? yueId, System.String player, System.DateTime? viewedAt, System.DateTime? updatedAt, System.Byte? status, System.String notes, System.Int32? offset, DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspInteracts_INSERT";
		dbCommand = db.GetStoredProcCommand(sqlCommand, yueId, player, viewedAt, updatedAt, status, notes, offset);
		
		if (transaction == null)
		this.InteractId = Convert.ToInt64(db.ExecuteScalar(dbCommand));
		else
		this.InteractId = Convert.ToInt64(db.ExecuteScalar(dbCommand, transaction));
		return;
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
	public void Insert(System.Int64? yueId, System.String player, System.DateTime? viewedAt, System.DateTime? updatedAt, System.Byte? status, System.String notes, System.Int32? offset)
	{
		Insert(yueId, player, viewedAt, updatedAt, status, notes, offset, null);
	}
	/// <summary>
	/// Insert current Interacts to database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Insert(DbTransaction transaction)
	{
		Insert(YueId, Player, ViewedAt, UpdatedAt, Status, Notes, Offset, transaction);
	}
	
	/// <summary>
	/// Insert current Interacts to database.
	/// </summary>
	public void Insert()
	{
		this.Insert((DbTransaction)null);
	}
	#endregion
	
	
	#region UPDATE
	public static void Update(System.Int64? interactId, System.Int64? yueId, System.String player, System.DateTime? viewedAt, System.DateTime? updatedAt, System.Byte? status, System.String notes, System.Int32? offset, DbTransaction transaction)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspInteracts_UPDATE";
		dbCommand = db.GetStoredProcCommand(sqlCommand);
		db.DiscoverParameters(dbCommand);
		dbCommand.Parameters["@interactId"].Value = interactId;
		dbCommand.Parameters["@yueId"].Value = yueId;
		dbCommand.Parameters["@player"].Value = player;
		dbCommand.Parameters["@viewedAt"].Value = viewedAt;
		dbCommand.Parameters["@updatedAt"].Value = updatedAt;
		dbCommand.Parameters["@status"].Value = status;
		dbCommand.Parameters["@notes"].Value = notes;
		dbCommand.Parameters["@offset"].Value = offset;
		
		if (transaction == null)
		db.ExecuteNonQuery(dbCommand);
		else
		db.ExecuteNonQuery(dbCommand, transaction);
		return;
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
	public static void Update(System.Int64? interactId, System.Int64? yueId, System.String player, System.DateTime? viewedAt, System.DateTime? updatedAt, System.Byte? status, System.String notes, System.Int32? offset)
	{
		Update(interactId, yueId, player, viewedAt, updatedAt, status, notes, offset, null);
	}
	
	public static void Update(Interacts interacts)
	{
		interacts.Update();
	}
	
	public static void Update(Interacts interacts, DbTransaction transaction)
	{
		interacts.Update(transaction);
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
		sqlCommand = "[dbo].gspInteracts_UPDATE";
		dbCommand = db.GetStoredProcCommand(sqlCommand);
		db.DiscoverParameters(dbCommand);
		dbCommand.Parameters["@interactId"].SourceColumn = "InteractId";
		dbCommand.Parameters["@yueId"].SourceColumn = "YueId";
		dbCommand.Parameters["@player"].SourceColumn = "Player";
		dbCommand.Parameters["@viewedAt"].SourceColumn = "ViewedAt";
		dbCommand.Parameters["@updatedAt"].SourceColumn = "UpdatedAt";
		dbCommand.Parameters["@status"].SourceColumn = "Status";
		dbCommand.Parameters["@notes"].SourceColumn = "Notes";
		dbCommand.Parameters["@offset"].SourceColumn = "Offset";
		
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
	public static void Delete(System.Int64? interactId, DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspInteracts_DELETE";
		dbCommand = db.GetStoredProcCommand(sqlCommand, interactId);
		
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
	public static void Delete(System.Int64? interactId)
	{
		Delete(
		interactId);
	}
	
	/// <summary>
	/// Delete current Interacts from database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Delete(DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspInteracts_DELETE";
		dbCommand = db.GetStoredProcCommand(sqlCommand, InteractId);
		
		// Execute.
		if (transaction != null)
		{
			db.ExecuteNonQuery(dbCommand, transaction);
		}
		else
		{
			db.ExecuteNonQuery(dbCommand);
		}
		this.InteractId = null;
	}
	
	/// <summary>
	/// Delete current Interacts from database.
	/// </summary>
	public void Delete()
	{
		this.Delete((DbTransaction)null);
	}
	
	#endregion
	
	
	#region SEARCH
	[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
	public static Interacts[] Search(System.Int64? interactId, System.Int64? yueId, System.String player, System.DateTime? viewedAt, System.DateTime? updatedAt, System.Byte? status, System.String notes, System.Int32? offset)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspInteracts_SEARCH";
		dbCommand = db.GetStoredProcCommand(sqlCommand, interactId, yueId, player, viewedAt, updatedAt, status, notes, offset);
		
		ds = db.ExecuteDataSet(dbCommand);
		ds.Tables[0].TableName = TABLE_NAME;
		return Interacts.MapFrom(ds);
	}
	
	
	public static Interacts[] Search(Interacts searchObject)
	{
		return Search ( searchObject.InteractId, searchObject.YueId, searchObject.Player, searchObject.ViewedAt, searchObject.UpdatedAt, searchObject.Status, searchObject.Notes, searchObject.Offset);
	}
	
	/// <summary>
	/// Returns all Interacts objects.
	/// </summary>
	/// <returns>List of all Interacts objects. </returns>
	[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
	public static Interacts[] Search()
	{
		return Search ( null, null, null, null, null, null, null, null);
	}
	
	#endregion
	
	
	#endregion
	
	
	#endregion
	
	
}

