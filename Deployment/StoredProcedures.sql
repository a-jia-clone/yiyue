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
/*************************************************/
/* [dbo].gspInteracts_INSERT */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspInteracts_INSERT') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspInteracts_INSERT
GO

CREATE PROCEDURE [dbo].gspInteracts_INSERT
(
@yueId AS bigint = null,
@player AS nvarchar(255) = null,
@viewedAt AS datetime = null,
@updatedAt AS datetime = null,
@status AS tinyint = null,
@notes AS nvarchar(MAX) = null,
@offset AS int = null
)
AS

INSERT INTO
  [dbo].[Interacts]
(
  [YueId],
  [Player],
  [ViewedAt],
  [UpdatedAt],
  [Status],
  [Notes],
  [Offset]
)
VALUES
(
  @yueId,
  @player,
  @viewedAt,
  @updatedAt,
  @status,
  @notes,
  @offset
)

SELECT SCOPE_IDENTITY()

GO

/*************************************************/
/* [dbo].gspInteracts_SELECT */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspInteracts_SELECT') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspInteracts_SELECT
GO

CREATE PROCEDURE [dbo].gspInteracts_SELECT
(
@interactId AS bigint
)
AS

SELECT
  *
FROM
  [dbo].[Interacts]
WHERE
  InteractId = @interactId

GO

/*************************************************/
/* [dbo].gspInteracts_UPDATE */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspInteracts_UPDATE') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspInteracts_UPDATE
GO

CREATE PROCEDURE [dbo].gspInteracts_UPDATE
(
@interactId bigint = null,
@yueId bigint = null,
@player nvarchar(255) = null,
@viewedAt datetime = null,
@updatedAt datetime = null,
@status tinyint = null,
@notes nvarchar(MAX) = null,
@offset int = null
)
AS

UPDATE
  [dbo].[Interacts]
SET
  [YueId] = @yueId,
  [Player] = @player,
  [ViewedAt] = @viewedAt,
  [UpdatedAt] = @updatedAt,
  [Status] = @status,
  [Notes] = @notes,
  [Offset] = @offset
WHERE
  [InteractId] = @interactId

GO

/*************************************************/
/* [dbo].gspInteracts_DELETE */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspInteracts_DELETE') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspInteracts_DELETE
GO

CREATE PROCEDURE [dbo].gspInteracts_DELETE
(
@interactId bigint
)
AS

DELETE
  [dbo].[Interacts]
WHERE
  [InteractId] = @interactId

GO

/*************************************************/
/* [dbo].gspInteracts_SEARCH */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspInteracts_SEARCH') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspInteracts_SEARCH
GO

CREATE PROCEDURE [dbo].gspInteracts_SEARCH
(
@interactId bigint = null,
@yueId bigint = null,
@player nvarchar(255) = null,
@viewedAt datetime = null,
@updatedAt datetime = null,
@status tinyint = null,
@notes nvarchar(MAX) = null,
@offset int = null
)
AS

SELECT
  *
FROM
  [dbo].[Interacts]
WHERE
  (@interactId IS NULL OR [InteractId] = @interactId)
AND
  (@yueId IS NULL OR [YueId] = @yueId)
AND
  (@player IS NULL OR @player = '' OR [Player] LIKE @player + '%')
AND
  (@viewedAt IS NULL OR [ViewedAt] = @viewedAt)
AND
  (@updatedAt IS NULL OR [UpdatedAt] = @updatedAt)
AND
  (@status IS NULL OR [Status] = @status)
AND
  (@offset IS NULL OR [Offset] = @offset)

GO

/*************************************************/
/* [dbo].gspYues_INSERT */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspYues_INSERT') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspYues_INSERT
GO

CREATE PROCEDURE [dbo].gspYues_INSERT
(
@createdBy AS nvarchar(255) = null,
@createdAt AS datetime = null,
@modifiedAt AS datetime = null,
@status AS tinyint = null,
@yueName AS nvarchar(255) = null,
@yueDateTime AS date = null,
@duration AS nvarchar(255) = null,
@minimum AS int = null,
@maximum AS int = null,
@tags AS nvarchar(MAX) = null,
@description AS nvarchar(MAX) = null,
@location AS nvarchar(255) = null,
@mapUrl AS nvarchar(MAX) = null,
@regiterDue AS datetime = null,
@notes AS nvarchar(MAX) = null,
@offset AS int = null
)
AS

INSERT INTO
  [dbo].[Yues]
(
  [CreatedBy],
  [CreatedAt],
  [ModifiedAt],
  [Status],
  [YueName],
  [YueDateTime],
  [Duration],
  [Minimum],
  [Maximum],
  [Tags],
  [Description],
  [Location],
  [MapUrl],
  [RegiterDue],
  [Notes],
  [Offset]
)
VALUES
(
  @createdBy,
  @createdAt,
  @modifiedAt,
  @status,
  @yueName,
  @yueDateTime,
  @duration,
  @minimum,
  @maximum,
  @tags,
  @description,
  @location,
  @mapUrl,
  @regiterDue,
  @notes,
  @offset
)

SELECT SCOPE_IDENTITY()

GO

/*************************************************/
/* [dbo].gspYues_SELECT */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspYues_SELECT') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspYues_SELECT
GO

CREATE PROCEDURE [dbo].gspYues_SELECT
(
@yueID AS bigint
)
AS

SELECT
  *
FROM
  [dbo].[Yues]
WHERE
  YueID = @yueID

GO

/*************************************************/
/* [dbo].gspYues_UPDATE */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspYues_UPDATE') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspYues_UPDATE
GO

CREATE PROCEDURE [dbo].gspYues_UPDATE
(
@yueID bigint = null,
@createdBy nvarchar(255) = null,
@createdAt datetime = null,
@modifiedAt datetime = null,
@status tinyint = null,
@yueName nvarchar(255) = null,
@yueDateTime date = null,
@duration nvarchar(255) = null,
@minimum int = null,
@maximum int = null,
@tags nvarchar(MAX) = null,
@description nvarchar(MAX) = null,
@location nvarchar(255) = null,
@mapUrl nvarchar(MAX) = null,
@regiterDue datetime = null,
@notes nvarchar(MAX) = null,
@offset int = null
)
AS

UPDATE
  [dbo].[Yues]
SET
  [CreatedBy] = @createdBy,
  [CreatedAt] = @createdAt,
  [ModifiedAt] = @modifiedAt,
  [Status] = @status,
  [YueName] = @yueName,
  [YueDateTime] = @yueDateTime,
  [Duration] = @duration,
  [Minimum] = @minimum,
  [Maximum] = @maximum,
  [Tags] = @tags,
  [Description] = @description,
  [Location] = @location,
  [MapUrl] = @mapUrl,
  [RegiterDue] = @regiterDue,
  [Notes] = @notes,
  [Offset] = @offset
WHERE
  [YueID] = @yueID

GO

/*************************************************/
/* [dbo].gspYues_DELETE */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspYues_DELETE') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspYues_DELETE
GO

CREATE PROCEDURE [dbo].gspYues_DELETE
(
@yueID bigint
)
AS

DELETE
  [dbo].[Yues]
WHERE
  [YueID] = @yueID

GO

/*************************************************/
/* [dbo].gspYues_SEARCH */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspYues_SEARCH') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspYues_SEARCH
GO

CREATE PROCEDURE [dbo].gspYues_SEARCH
(
@yueID bigint = null,
@createdBy nvarchar(255) = null,
@createdAt datetime = null,
@modifiedAt datetime = null,
@status tinyint = null,
@yueName nvarchar(255) = null,
@yueDateTime date = null,
@duration nvarchar(255) = null,
@minimum int = null,
@maximum int = null,
@tags nvarchar(MAX) = null,
@description nvarchar(MAX) = null,
@location nvarchar(255) = null,
@mapUrl nvarchar(MAX) = null,
@regiterDue datetime = null,
@notes nvarchar(MAX) = null,
@offset int = null
)
AS

SELECT
  *
FROM
  [dbo].[Yues]
WHERE
  (@yueID IS NULL OR [YueID] = @yueID)
AND
  (@createdBy IS NULL OR @createdBy = '' OR [CreatedBy] LIKE @createdBy + '%')
AND
  (@createdAt IS NULL OR [CreatedAt] = @createdAt)
AND
  (@modifiedAt IS NULL OR [ModifiedAt] = @modifiedAt)
AND
  (@status IS NULL OR [Status] = @status)
AND
  (@yueName IS NULL OR @yueName = '' OR [YueName] LIKE @yueName + '%')
AND
  (@yueDateTime IS NULL OR [YueDateTime] = @yueDateTime)
AND
  (@duration IS NULL OR @duration = '' OR [Duration] LIKE @duration + '%')
AND
  (@minimum IS NULL OR [Minimum] = @minimum)
AND
  (@maximum IS NULL OR [Maximum] = @maximum)
AND
  (@location IS NULL OR @location = '' OR [Location] LIKE @location + '%')
AND
  (@regiterDue IS NULL OR [RegiterDue] = @regiterDue)
AND
  (@offset IS NULL OR [Offset] = @offset)

GO

