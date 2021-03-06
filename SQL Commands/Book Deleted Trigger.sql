USE [DBSahaf]
GO
/****** Object:  Trigger [dbo].[Deleted_Book]    Script Date: 3.04.2022 02:57:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[Deleted_Book]
ON [dbo].[Book]
AFTER DELETE
AS
	BEGIN
		UPDATE dbo.[User] SET bookBorrowDate = null, bookReturnDate = null WHERE bookId IS NULL
	END;