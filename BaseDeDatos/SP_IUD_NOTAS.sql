USE [DigitalWare1]
GO

/****** Object:  StoredProcedure [dbo].[SP_IUD_NOTAS]    Script Date: 8/12/2022 9:29:47 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IUD_NOTAS]
	
	@PI_IDNOTA int =NULL,
	@PI_ELIMINAR bit = NULL,
	@PI_ACTUALIZAR bit = NULL,


	@PI_INSERTAR bit = NULL,
	@PI_IDMATERIA int = NULL,
	@PI_IDALUMNO int = NULL,
	@PI_IDPERIODO int = NULL,
	@PI_NOT_VALOR int = NULL,


	@PO_OUTPUT bit output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	IF @PI_ELIMINAR IS NOT NULL
	BEGIN
		
		   BEGIN TRY
			DELETE FROM [dbo].[TBL_NOTA] WHERE PK_IDNOTA = @PI_IDNOTA
			SET @PO_OUTPUT = 1
		   END TRY
		   BEGIN CATCH
			SET @PO_OUTPUT = 0
		   END CATCH
		   RETURN
	END

	IF @PI_ACTUALIZAR IS NOT NULL
	BEGIN
		
		   BEGIN TRY
			UPDATE [dbo].[TBL_NOTA] SET NOT_VALOR = @PI_NOT_VALOR WHERE PK_IDNOTA = @PI_IDNOTA
			SET @PO_OUTPUT = 1
		   END TRY
		   BEGIN CATCH
			SET @PO_OUTPUT = 0
		   END CATCH
		   RETURN

	END 

	IF @PI_INSERTAR IS NOT NULL
	BEGIN
		BEGIN TRY

					INSERT INTO [dbo].[TBL_NOTA]
				   ([NOT_VALOR]
				   ,[FK_IDMATERIA]
				   ,[FK_IDALUMNO]
				   ,[FK_PERIODO])
					VALUES
				   (
					@PI_NOT_VALOR,
					@PI_IDMATERIA,
					@PI_IDALUMNO,
					@PI_IDPERIODO
				   )

				   SET @PO_OUTPUT = SCOPE_IDENTITY()
		END TRY
		BEGIN CATCH
			SET @PO_OUTPUT = 0
		END CATCH

	END

   
END
GO


