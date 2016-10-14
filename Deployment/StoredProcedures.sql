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
/*************************************************/
/* [dbo].gspTags_INSERT */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspTags_INSERT') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspTags_INSERT
GO

CREATE PROCEDURE [dbo].gspTags_INSERT
(
@tagId AS smallint = null,
@tagName AS nvarchar(500) = null,
@tagIcon AS nvarchar(500) = null
)
AS

INSERT INTO
  [dbo].[Tags]
(
  [TagId],
  [TagName],
  [TagIcon]
)
VALUES
(
  @tagId,
  @tagName,
  @tagIcon
)

SELECT SCOPE_IDENTITY()

GO

/*************************************************/
/* [dbo].gspTags_SELECT */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspTags_SELECT') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspTags_SELECT
GO

CREATE PROCEDURE [dbo].gspTags_SELECT
(
@tagId AS smallint
)
AS

SELECT
  *
FROM
  [dbo].[Tags]
WHERE
  TagId = @tagId

GO

/*************************************************/
/* [dbo].gspTags_UPDATE */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspTags_UPDATE') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspTags_UPDATE
GO

CREATE PROCEDURE [dbo].gspTags_UPDATE
(
@tagId smallint = null,
@tagName nvarchar(500) = null,
@tagIcon nvarchar(500) = null
)
AS

UPDATE
  [dbo].[Tags]
SET
  [TagId] = @tagId,
  [TagName] = @tagName,
  [TagIcon] = @tagIcon
WHERE
  [TagId] = @tagId

GO

/*************************************************/
/* [dbo].gspTags_DELETE */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspTags_DELETE') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspTags_DELETE
GO

CREATE PROCEDURE [dbo].gspTags_DELETE
(
@tagId smallint
)
AS

DELETE
  [dbo].[Tags]
WHERE
  [TagId] = @tagId

GO

/*************************************************/
/* [dbo].gspTags_SEARCH */
/*************************************************/

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].gspTags_SEARCH') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].gspTags_SEARCH
GO

CREATE PROCEDURE [dbo].gspTags_SEARCH
(
@tagId smallint = null,
@tagName nvarchar(500) = null,
@tagIcon nvarchar(500) = null
)
AS

SELECT
  *
FROM
  [dbo].[Tags]
WHERE
  (@tagId IS NULL OR [TagId] = @tagId)
AND
  (@tagName IS NULL OR @tagName = '' OR [TagName] LIKE @tagName + '%')
AND
  (@tagIcon IS NULL OR @tagIcon = '' OR [TagIcon] LIKE @tagIcon + '%')

GO

