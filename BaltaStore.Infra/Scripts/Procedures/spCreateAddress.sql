CREATE PROCEDURE spCreateAddress
@Id UNIQUEIDENTIFIER,
@CustomerId UNIQUEIDENTIFIER,
@Number VARCHAR(10),
@Complement VARCHAR(40),
@District VARCHAR(60),
@City VARCHAR(60),
@State CHAR(2),
@Country VARCHAR(60),
@ZipCode CHAR(8),
@Type INT

AS
	INSERT INTO [dbo].[Address]
           ([Id]
           ,[CustomerId]
           ,[Number]
           ,[Complement]
           ,[District]
           ,[City]
           ,[State]
           ,[Country]
           ,[ZipCode]
           ,[Type])
     VALUES
           (@Id,
            @CustomerId,
			@Number,
			@Complement,
			@District,
			@City,
			@State,
			@Country,
			@ZipCode,
			@Type)
