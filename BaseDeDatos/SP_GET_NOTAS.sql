USE [DigitalWare1]
GO

/****** Object:  StoredProcedure [dbo].[SP_GET_NOTAS]    Script Date: 8/12/2022 9:29:05 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_NOTAS]
	@PI_IDALUMNO int ,
	@PI_PERIODO int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	SELECT 
	PK_IDALUMNO,
	NOTA.PK_IDNOTA as IdNota,
	CONCAT(ALU_NOMBRE,' ',ALU_APELLIDO) as ALUMNO,
	MAT.MAT_NOMBRE as MATERIA,
	NOTA.NOT_VALOR as NOTA,
	CONCAT('PERIODO: ', NOTA.FK_PERIODO) as PERIODO
	FROM [dbo].[TBL_MATERIA] as MAT
	LEFT JOIN [dbo].[TBL_NOTA]  as NOTA
	ON NOTA.FK_IDMATERIA = MAT.PK_IDMATERIA
	LEFT JOIN  TBL_ALUMNO As ALU
	ON ALU.PK_IDALUMNO = NOTA.FK_IDALUMNO
	WHERE ALU.PK_IDALUMNO = @PI_IDALUMNO AND NOTA.FK_PERIODO = ISNULL(@PI_PERIODO,NOTA.FK_PERIODO)

END
GO


