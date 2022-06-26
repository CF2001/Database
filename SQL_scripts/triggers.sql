-- Um paciente não pode fazer mais que uma cirurgia do mesmo tipo no mesmo dia
DROP TRIGGER too_much_surgery;
GO
CREATE TRIGGER too_much_surgery ON Cirurgia
AFTER INSERT
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



-- Um médico só pode supervisionar no máximo uma equipa médica
DROP TRIGGER supervisor_once;
GO
CREATE TRIGGER supervisor_once ON Equipa_Medica
AFTER INSERT
AS

	SET NOCOUNT ON;

	DECLARE @id AS INT;
	DECLARE @equipa AS INT;
	DECLARE @Super_func_ID_Medico AS INT;
	DECLARE @equipaM_ID AS INT

	SELECT @id = Super_func_ID_Medico, @equipa = equipaM_ID FROM inserted;

	DECLARE C CURSOR
	FOR
		SELECT Super_func_ID_Medico, equipaM_ID
		FROM Equipa_Medica;
	OPEN C;
	FETCH C INTO  @Super_func_ID_Medico, @equipaM_ID;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@Super_func_ID_Medico = @id)
		BEGIN
			RAISERROR('Este Médico já é supervisor de uma equipa médica!', 16, 1);
			ROLLBACK TRAN;
			CLOSE C;
			DEALLOCATE C;
			RETURN;
		END
		FETCH C INTO @Super_func_ID_Medico, @equipaM_ID;
	END
	CLOSE C;
	DEALLOCATE C;

	INSERT INTO Equipa_Medica SELECT * FROM inserted;
GO

--Teste
INSERT INTO Equipa_Medica VALUES (7, 12);
SELECT * FROM Equipa_Medica;

-- marcar uma Consulta
DROP TRIGGER schedule_apointment;
GO
CREATE TRIGGER schedule_apointment ON Consulta
INSTEAD OF INSERT
AS

	SET NOCOUNT ON;

	DECLARE @noUtente AS INT;
	DECLARE @data AS DATE;
	DECLARE @numero AS INT;
	DECLARE @dataC AS DATE;

	SELECT @noUtente = noUtenteSaude, @data = dataConsulta FROM inserted;

	DECLARE C CURSOR
	FOR
		SELECT noUtenteSaude, dataConsulta
		FROM Consulta;
	OPEN C;
	FETCH C INTO  @numero, @dataC;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF (@noUtente = @numero AND @data = @dataC)
		BEGIN
			RAISERROR('Este paciente já tem uma consulta nessa data!', 16, 1);
			ROLLBACK TRAN;
			CLOSE C;
			DEALLOCATE C;
			RETURN;
		END
		FETCH C INTO @numero, @dataC;
	END
	CLOSE C;
	DEALLOCATE C;

	INSERT INTO Consulta SELECT * FROM inserted;
GO

--Teste
SELECT * FROM Consulta;
INSERT INTO Consulta VALUES (13, 23456701, 5, '2022-06-11', '3h PM');
