-- Um paciente não pode fazer mais que uma cirurgia do mesmo tipo no mesmo dia
DROP TRIGGER too_much_surgery;
GO
CREATE TRIGGER too_much_surgery ON Cirurgia
INSTEAD OF INSERT
AS

	SET NOCOUNT ON;

	DECLARE @id AS INT;
	DECLARE @type AS CHAR(40);
	DECLARE @data AS DATE;
	DECLARE @tipoCirurgia AS CHAR(40);
	DECLARE @dataCirurgia AS DATE;
	DECLARE @noUtenteSaude AS INT;

	SELECT @id = noUtenteSaude, @type = tipoCirurgia, @data = dataCirurgia FROM inserted;

	DECLARE C CURSOR
	FOR
		SELECT noUtenteSaude, tipoCirurgia, dataCirurgia
		FROM Cirurgia;
	OPEN C;
	FETCH C INTO  @noUtenteSaude, @tipoCirurgia, @dataCirurgia;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@noUtenteSaude = @id AND @tipoCirurgia = @type AND @data = @dataCirurgia)
		BEGIN
			RAISERROR('Um paciente não pode fazer mais que uma cirurgia do mesmo tipo no mesmo dia!', 16, 1);
			ROLLBACK TRAN;
			CLOSE C;
			DEALLOCATE C;
			RETURN;
		END
		FETCH C INTO @dataCirurgia, @tipoCirurgia;
	END
	CLOSE C;
	DEALLOCATE C;

	INSERT INTO Cirurgia SELECT * FROM inserted;
GO

--Teste
INSERT INTO Cirurgia VALUES ('Cirurgia cardiaca', '2022-7-02', '5h PM', '6h30', 1, 5, 66654311);
SELECT * FROM Cirurgia;