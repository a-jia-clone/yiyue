/****************************************************************************/
/* Code Author (written by Xin Zhao)                                        */
/*                                                                          */
/* This file was automatically generated using Code Author.                 */
/* Any manual changes to this file will be overwritten by a automated tool. */
/*                                                                          */
/* Date Generated: 2016/10/13 23:20:55                                    */
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
public partial class Tags
{
	
	
	#region Constants
	private static readonly string TABLE_NAME = "[dbo].[Tags]";
	
	#endregion
	
	
	#region Fields
	private System.Int16? _tagId;
	private System.String _tagName;
	private System.String _tagIcon;
	
	#endregion
	
	
	#region Properties
	public System.Int16? TagId
	{
		get
		{
			return _tagId;
		}
		set
		{
			_tagId = value;
		}
	}
	
	public System.String TagName
	{
		get
		{
			return _tagName;
		}
		set
		{
			_tagName = value;
		}
	}
	
	public System.String TagIcon
	{
		get
		{
			return _tagIcon;
		}
		set
		{
			_tagIcon = value;
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
		
		ds.Tables[TABLE_NAME].Columns.Add("TagId", typeof(System.Int16) );
		ds.Tables[TABLE_NAME].Columns.Add("TagName", typeof(System.String) );
		ds.Tables[TABLE_NAME].Columns.Add("TagIcon", typeof(System.String) );
		
		dr = ds.Tables[TABLE_NAME].NewRow();
		
		if (TagId == null)
		dr["TagId"] = DBNull.Value;
		else
		dr["TagId"] = TagId;
		
		if (TagName == null)
		dr["TagName"] = DBNull.Value;
		else
		dr["TagName"] = TagName;
		
		if (TagIcon == null)
		dr["TagIcon"] = DBNull.Value;
		else
		dr["TagIcon"] = TagIcon;
		
		
		ds.Tables[TABLE_NAME].Rows.Add(dr);
		
	}
	
	protected void MapFrom(DataRow dr)
	{
		TagId = dr["TagId"] != DBNull.Value ? Convert.ToInt16(dr["TagId"]) : TagId = null;
		TagName = dr["TagName"] != DBNull.Value ? Convert.ToString(dr["TagName"]) : TagName = null;
		TagIcon = dr["TagIcon"] != DBNull.Value ? Convert.ToString(dr["TagIcon"]) : TagIcon = null;
	}
	
	public static Tags[] MapFrom(DataSet ds)
	{
		List<Tags> objects;
		
		
		// Initialise Collection.
		objects = new List<Tags>();
		
		// Validation.
		if (ds == null)
		throw new ApplicationException("Cannot map to dataset null.");
		else if (ds.Tables[TABLE_NAME].Rows.Count == 0)
		return objects.ToArray();
		
		if (ds.Tables[TABLE_NAME] == null)
		throw new ApplicationException("Cannot find table [dbo].[Tags] in DataSet.");
		
		if (ds.Tables[TABLE_NAME].Rows.Count < 1)
		throw new ApplicationException("Table [dbo].[Tags] is empty.");
		
		// Map DataSet to Instance.
		foreach (DataRow dr in ds.Tables[TABLE_NAME].Rows)
		{
			Tags instance = new Tags();
			instance.MapFrom(dr);
			objects.Add(instance);
		}
		
		// Return collection.
		return objects.ToArray();
	}
	
	
	#endregion
	
	
	#region CRUD Methods
	
	[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
	public static Tags Get(System.Int16 tagId)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		Tags instance;
		
		
		instance = new Tags();
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspTags_SELECT";
		dbCommand = db.GetStoredProcCommand(sqlCommand, tagId);
		
		// Get results.
		ds = db.ExecuteDataSet(dbCommand);
		// Verification.
		if (ds == null || ds.Tables[0].Rows.Count == 0) throw new ApplicationException("Could not get Tags ID:" + tagId.ToString()+ " from Database.");
		// Return results.
		ds.Tables[0].TableName = TABLE_NAME;
		
		instance.MapFrom( ds.Tables[0].Rows[0] );
		return instance;
	}
	
	#region INSERT
	public void Insert(System.Int16? tagId, System.String tagName, System.String tagIcon, DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspTags_INSERT";
		dbCommand = db.GetStoredProcCommand(sqlCommand, tagId, tagName, tagIcon);
		
		if (transaction == null)
		db.ExecuteScalar(dbCommand);
		else
		db.ExecuteScalar(dbCommand, transaction);
		return;
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
	public void Insert(System.Int16? tagId, System.String tagName, System.String tagIcon)
	{
		Insert(tagId, tagName, tagIcon, null);
	}
	/// <summary>
	/// Insert current Tags to database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Insert(DbTransaction transaction)
	{
		Insert(TagId, TagName, TagIcon, transaction);
	}
	
	/// <summary>
	/// Insert current Tags to database.
	/// </summary>
	public void Insert()
	{
		this.Insert((DbTransaction)null);
	}
	#endregion
	
	
	#region UPDATE
	public static void Update(System.Int16? tagId, System.String tagName, System.String tagIcon, DbTransaction transaction)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspTags_UPDATE";
		dbCommand = db.GetStoredProcCommand(sqlCommand);
		db.DiscoverParameters(dbCommand);
		dbCommand.Parameters["@tagId"].Value = tagId;
		dbCommand.Parameters["@tagName"].Value = tagName;
		dbCommand.Parameters["@tagIcon"].Value = tagIcon;
		
		if (transaction == null)
		db.ExecuteNonQuery(dbCommand);
		else
		db.ExecuteNonQuery(dbCommand, transaction);
		return;
	}
	
	[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
	public static void Update(System.Int16? tagId, System.String tagName, System.String tagIcon)
	{
		Update(tagId, tagName, tagIcon, null);
	}
	
	public static void Update(Tags tags)
	{
		tags.Update();
	}
	
	public static void Update(Tags tags, DbTransaction transaction)
	{
		tags.Update(transaction);
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
		sqlCommand = "[dbo].gspTags_UPDATE";
		dbCommand = db.GetStoredProcCommand(sqlCommand);
		db.DiscoverParameters(dbCommand);
		dbCommand.Parameters["@tagId"].SourceColumn = "TagId";
		dbCommand.Parameters["@tagName"].SourceColumn = "TagName";
		dbCommand.Parameters["@tagIcon"].SourceColumn = "TagIcon";
		
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
	public static void Delete(System.Int16? tagId, DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspTags_DELETE";
		dbCommand = db.GetStoredProcCommand(sqlCommand, tagId);
		
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
	public static void Delete(System.Int16? tagId)
	{
		Delete(
		tagId, (DbTransaction)null);
	}
	
	/// <summary>
	/// Delete current Tags from database.
	/// </summary>
	/// <param name="transaction">optional SQL Transaction</param>
	public void Delete(DbTransaction transaction)
	{
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspTags_DELETE";
		dbCommand = db.GetStoredProcCommand(sqlCommand, TagId);
		
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
	
	/// <summary>
	/// Delete current Tags from database.
	/// </summary>
	public void Delete()
	{
		this.Delete((DbTransaction)null);
	}
	
	#endregion
	
	
	#region SEARCH
	[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
	public static Tags[] Search(System.Int16? tagId, System.String tagName, System.String tagIcon)
	{
		DataSet ds;
		Database db;
		string sqlCommand;
		DbCommand dbCommand;
		
		
		db = DatabaseFactory.CreateDatabase();
		sqlCommand = "[dbo].gspTags_SEARCH";
		dbCommand = db.GetStoredProcCommand(sqlCommand, tagId, tagName, tagIcon);
		
		ds = db.ExecuteDataSet(dbCommand);
		ds.Tables[0].TableName = TABLE_NAME;
		return Tags.MapFrom(ds);
	}
	
	
	public static Tags[] Search(Tags searchObject)
	{
		return Search ( searchObject.TagId, searchObject.TagName, searchObject.TagIcon);
	}
	
	/// <summary>
	/// Returns all Tags objects.
	/// </summary>
	/// <returns>List of all Tags objects. </returns>
	[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
	public static Tags[] Search()
	{
		return Search ( null, null, null);
	}
	
	#endregion
	
	
	#endregion
	
	
	#endregion
	
	
}

