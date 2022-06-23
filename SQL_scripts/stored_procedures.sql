-------------------------------------------------------  PACIENTE ----------------------------------------------------------

/* Registar um Paciente */
DROP PROC sp_registoPaciente;
GO 
CREATE PROCEDURE sp_registoPaciente (@noUtenteSaude INT, @firstName CHAR(15), @lastName CHAR(15), @bDate DATE, @genero CHAR(1), @noTelefone INT, 
									@rececionistaID INT, @quartoID INT, @dataEntrada DATE, @dataSaida DATE)
AS 
	BEGIN
		
		DECLARE	@noCamasOcupapas AS INT;
		DECLARE @noCamasQuarto	AS INT;

		IF @quartoID is NULL -- Paciente não Internado
			BEGIN
				INSERT INTO Paciente 
				VALUES  (@noUtenteSaude, @firstName, @lastName, @bDate, @genero, @noTelefone, @rececionistaID, @quartoID, @dataEntrada, @dataSaida)
			END
		ELSE	-- Paciente Internado

			BEGIN
				-- Agrupar todas as camas do @quartoID
				-- Fazer contagem das que têm o atributo camaOcupada a 1 
				-- Verificar se o valor dessa contagem é igual ou superior ao valor de camas do @quartoID (tabela Quarto_Hospital)

				-- Representa a qtdd de camas ocupadas no @quartoID
				SELECT @noCamasOcupapas = COUNT(*) 
				FROM Cama_Hospital 
				WHERE (camaOcupada = 1 AND ID_Quarto = @quartoID);

				SELECT @noCamasQuarto = noCamas FROM Quarto_Hospital;

				IF @noCamasOcupapas <  @noCamasQuarto
					BEGIN
						INSERT INTO Paciente 
						VALUES  (@noUtenteSaude, @firstName, @lastName, @bDate, @genero, @noTelefone, @rececionistaID, @quartoID, @dataEntrada, @dataSaida)

						-- Atualização da Cama_Hospital: 1 cama fica ocupada 
						UPDATE TOP(1) Cama_Hospital 
						SET camaOcupada = 1
						WHERE (ID_Quarto = @quartoID AND camaOcupada = 0);
					END
				ELSE 
					raiserror('ERRO: Todas as camas do Quarto inserido ocupadas. Por favor insira outro quarto', 20, -1) with log
			END
	END

Select * from Paciente;
Select * from Cama_Hospital;

-- Teste 
EXEC sp_registoPaciente 111132, 'Maria', 'Mendes', '1970-03-14', 'F', '917483921', 1, NULL, NULL, NULL;
EXEC sp_registoPaciente 7429743, 'Vitor', 'Silveira', '2001-03-14', 'M', '917482920', 1, 2, '2022-06-17', NULL;


/* Eliminar um Paciente do sistema em função do seu noUtendeSaude */ 
DROP PROC sp_eliminarPaciente;
GO 
CREATE PROCEDURE sp_eliminarPaciente (@noUtenteSaude INT)
AS 
	BEGIN
		DECLARE @idQuarto AS INT;
		DECLARE @noUtenteS_consulta AS INT;
		DECLARE @noUtenteS_cirurgia AS INT;

		SELECT @idQuarto = ID_QUARTO  FROM Paciente WHERE noUtenteSaude = @noUtenteSaude;

		
		IF @idQuarto is NULL	-- Eliminar paciente não internado
			BEGIN

				DELETE FROM Enf_Auxilia WHERE noUtenteSaude = @noUtenteSaude;

				-- Verificar se o paciente tinha consulta marcada
				SELECT @noUtenteS_consulta = COUNT (*) FROM Consulta WHERE noUtenteSaude = @noUtenteSaude;
				IF @noUtenteS_consulta > 0	-- Paciente tem consulta
				   UPDATE Consulta SET noUtenteSaude = NULL, dataConsulta = NULL, hora = NULL WHERE noUtenteSaude = @noUtenteSaude;

				-- Verificar se o paciente tinha cirurgia marcada
				SELECT @noUtenteS_cirurgia = COUNT (*) FROM Cirurgia WHERE noUtenteSaude = @noUtenteSaude;
				IF @noUtenteS_cirurgia > 0	-- Paciente tem cirurgia
					UPDATE Cirurgia 
					SET noUtenteSaude = NULL, dataCirurgia = NULL, Hora_Inicio = NULL, Duracao = NULL 
					WHERE noUtenteSaude = @noUtenteSaude;

				DELETE FROM Paciente WHERE noUtenteSaude = @noUtenteSaude;

			END
		ELSE		-- Eliminar paciente internado
			BEGIN

				DELETE FROM Enf_Auxilia WHERE noUtenteSaude = @noUtenteSaude;

				-- Verificar se o paciente tinha consulta marcada
				SELECT @noUtenteS_consulta = COUNT (*) FROM Consulta WHERE noUtenteSaude = @noUtenteSaude;
				IF @noUtenteS_consulta > 0	-- Paciente tem consulta
				   UPDATE Consulta SET noUtenteSaude = NULL, dataConsulta = NULL, hora = NULL WHERE noUtenteSaude = @noUtenteSaude;

				-- Verificar se o paciente tinha cirurgia marcada
				SELECT @noUtenteS_cirurgia = COUNT (*) FROM Cirurgia WHERE noUtenteSaude = @noUtenteSaude;
				IF @noUtenteS_cirurgia > 0	-- Paciente tem cirurgia
					UPDATE Cirurgia 
					SET noUtenteSaude = NULL, dataCirurgia = NULL, Hora_Inicio = NULL, Duracao = NULL 
					WHERE noUtenteSaude = @noUtenteSaude;

				DELETE FROM Paciente WHERE noUtenteSaude = @noUtenteSaude;

				-- Atualização Cama_Hospital: 1 cama passa a estar livre 
				UPDATE TOP(1) Cama_Hospital 
						SET camaOcupada = 0
						WHERE (ID_Quarto = @idQuarto AND camaOcupada = 1);

			END
	END	

Select * from Paciente;
Select * from Cama_Hospital;
Select * from Enf_Auxilia;
Select * from Consulta;
Select * from Cirurgia;
-- Teste 
EXEC sp_eliminarPaciente 111132;



/* Atualizar os dados de um Paciente no Sistema. */
-- NOTA: O número de Utente de Saude não pode ser atualizado.
DROP PROC sp_updateInfoPaciente;
GO 
CREATE PROCEDURE sp_updateInfoPaciente (@noUtenteSaude INT, @firstName CHAR(15), @lastName CHAR(15), @bDate DATE, @genero CHAR(1), @noTelefone INT, 
									@rececionistaID INT, @quartoID INT, @dataEntrada DATE, @dataSaida DATE)
AS
	BEGIN 
		BEGIN TRANSACTION
		SET NOCOUNT ON

		BEGIN TRY

			DECLARE @OLD_quartoID AS INT;
			DECLARE @noCamasOcupapas AS INT;
			DECLARE @noCamasQuarto AS INT;

			SELECT @OLD_quartoID = ID_Quarto FROM Paciente WHERE noUtenteSaude = @noUtenteSaude;

			IF @firstName is not NULL
			BEGIN
				UPDATE Paciente SET primeiroNome = @firstName WHERE noUtenteSaude = @noUtenteSaude;
			END

			IF @lastName is not NULL
			BEGIN
				UPDATE Paciente SET ultimoNome = @lastName WHERE noUtenteSaude = @noUtenteSaude;
			END

			IF @bDate is not NULL
			BEGIN
				UPDATE Paciente SET dataNascimento = @bDate WHERE noUtenteSaude = @noUtenteSaude;
			END

			IF @genero is not NULL
			BEGIN
				UPDATE Paciente SET genero = @genero WHERE noUtenteSaude = @noUtenteSaude;
			END

			IF @noTelefone is not NULL
			BEGIN
				UPDATE Paciente SET noTelefone = @noTelefone WHERE noUtenteSaude = @noUtenteSaude;
			END

			IF @rececionistaID is not NULL
			BEGIN
				UPDATE Paciente SET func_ID_Rec = @rececionistaID WHERE noUtenteSaude = @noUtenteSaude;
			END

			-- Atualização do quarto
			UPDATE Paciente SET ID_Quarto = @quartoID WHERE noUtenteSaude = @noUtenteSaude;
			IF @quartoID is NULL -- Paciente não internado
				BEGIN 
					-- Atualização Cama_Hospital: 1 cama passa a estar livre + data Entrada e Saida = NULL
					UPDATE TOP(1) Cama_Hospital 
					SET camaOcupada = 0
					WHERE (ID_Quarto = @OLD_quartoID AND camaOcupada = 1);
				END
			ELSE
				BEGIN 
					SELECT @noCamasOcupapas = COUNT(*) 
					FROM Cama_Hospital 
					WHERE (camaOcupada = 1 AND ID_Quarto = @quartoID);

					SELECT @noCamasQuarto = noCamas FROM Quarto_Hospital;

					IF @noCamasOcupapas <  @noCamasQuarto
						BEGIN
							-- Atualização da Cama_Hospital: 1 cama fica ocupada + contém a data de entrada do dia
							UPDATE TOP(1) Cama_Hospital 
							SET camaOcupada = 1
							WHERE (ID_Quarto = @quartoID AND camaOcupada = 0);
						END
					ELSE 
						raiserror('ERRO: Todas as camas do Quarto inserido ocupadas. Por favor insira outro quarto', 20, -1) with log

					-- O Paciente altera de quarto, sendo que o quarto antigo passa a ter uma cama livre 
					IF @OLD_quartoID is not NULL
					BEGIN
						-- Atualização Cama_Hospital: 1 cama passa a estar livre + data Entrada e Saida = NULL
						UPDATE TOP(1) Cama_Hospital 
						SET camaOcupada = 0
						WHERE (ID_Quarto = @OLD_quartoID AND camaOcupada = 1);	
					END
				END

				-- Atualização data de Entrada e Saida
				UPDATE Paciente SET dataEntrada = @dataEntrada Where noUtenteSaude = @noUtenteSaude;
				UPDATE Paciente SET dataSaida = @dataSaida Where noUtenteSaude = @noUtenteSaude;

			
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK
		END CATCH
			
	END 

Select * from Paciente;
Select * from Cama_Hospital;
-- Teste 
EXEC sp_updateInfoPaciente 111132, 'Maria', 'Mendes', '1970-03-14', 'F', '917483921', 1, 2, '2022-06-18', NULL;
EXEC sp_updateInfoPaciente 12345070, 'Mario', 'Silva', '1999-12-02', 'M', '921811818', 1, NULL, NULL, NULL;
-- EXEC sp_updateInfoPaciente 87969404, 'Afonso', 'Pereira', '2000-06-02', 'M', '967821111', 1, NULL;
-- EXEC sp_updateInfoPaciente 44445533, 'Mariana', 'Amaral', '1977-05-02', 'F', '924444442', 1, NULL;



/** Eliminar um Paciente da lista de Pacientes internados e atualizar a cama para livre */
DROP PROC UpdatePaciente_NaoInternado;
GO 
CREATE PROCEDURE UpdatePaciente_NaoInternado (@noUtenteSaude INT, @quartoID INT)
AS
	BEGIN 
		BEGIN TRANSACTION
		SET NOCOUNT ON

		BEGIN TRY

			DECLARE @camaOcupada AS BIT;
			DECLARE @IDCama AS CHAR(10);

			SELECT @IDCama = ID_Cama, @camaOcupada = camaOcupada FROM Cama_Hospital
			WHERE ID_Quarto = @quartoID AND camaOcupada = 0;

			-- Paciente deixa de estar internado no Hospital
			UPDATE Paciente 
			SET ID_Quarto = NULL, dataEntrada = NULL, dataSaida = NULL
			WHERE noUtenteSaude = @noUtenteSaude;

			UPDATE TOP(1) Cama_Hospital 
			SET camaOcupada = 0
			WHERE (ID_Quarto = @quartoID AND camaOcupada = 1);

			IF @camaOcupada = 0
			BEGIN
				DELETE FROM Enf_Supervisiona WHERE ID_Cama_EnfS = @IDCama; 
			END
			
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK
		END CATCH
			
	END 

-- Teste 
SELECT * FROM Paciente;
SELECT * FROM Cama_Hospital;
SELECT * FROM Enf_Supervisiona;
EXEC UpdatePaciente_NaoInternado 87969404, 4; 



/** Atribuir um quarto a um Paciente,
 -- Adicionar o Paciente à lista de pacientes internados 
 -- atualizar o estado de uma cama do quarto para 1 (Ocupado) */
DROP PROC UpdatePaciente_Internado;
GO
CREATE PROCEDURE UpdatePaciente_Internado (@noUtenteSaude INT, @dataEntrada DATE, @dataSaida DATE, @quartoID INT)
AS 
	BEGIN
		BEGIN TRANSACTION
		SET NOCOUNT ON

		BEGIN TRY

			-- Paciente passa a estar internado no Hospital
			UPDATE Paciente 
			SET ID_Quarto = @quartoID, dataEntrada = @dataEntrada, dataSaida = @dataSaida
			WHERE noUtenteSaude = @noUtenteSaude;

			UPDATE TOP(1) Cama_Hospital 
			SET camaOcupada = 1
			WHERE (ID_Quarto = @quartoID AND camaOcupada = 0);
			
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK
		END CATCH
	END

-- Teste 
SELECT * FROM Paciente;
EXEC UpdatePaciente_Internado  22222730, '2022-06-22', '2022-07-22', 6; 


/*** Atualização da data de Entrada e Saida de um Paciente internado **/
DROP UpdateDadosPaciente_Internado;
GO
CREATE PROCEDURE UpdateDadosPaciente_Internado (@noUtenteSaude INT, @dataEntrada DATE, @dataSaida DATE)
AS 
	BEGIN
		BEGIN TRANSACTION
		SET NOCOUNT ON

		BEGIN TRY

			-- Paciente passa a estar internado no Hospital
			UPDATE Paciente 
			SET dataEntrada = @dataEntrada, dataSaida = @dataSaida
			WHERE noUtenteSaude = @noUtenteSaude;
			
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK
		END CATCH
	END

-- Teste 
SELECT * FROM Paciente;
SELECT * FROM Cama_Hospital;
EXEC UpdateDadosPaciente_Internado  22222730, '2022-06-22', NULL;

------------------------------------------------------ FUNCIONÁRIO ------------------------------------------------------------------


/* Inserir um Funcionário no sistema do Hospital  */
DROP PROC sp_registoFuncionario;
GO 
CREATE PROCEDURE sp_registoFuncionario (@funcID INT, @primeiroNome CHAR(15), @ultimoNome CHAR(15), @dataNascimento DATE, @genero CHAR(1), @telefone CHAR(9), 
									@morada CHAR(40), @salary SMALLMONEY, @email CHAR(30), @tipo CHAR(1), @deptID SMALLINT, @balcao CHAR(1))
AS 
BEGIN

	DECLARE	@getID AS INT;

	SELECT @getID = COUNT(*) FROM Funcionario WHERE @funcID = func_ID;

	IF @getID = 1 
		BEGIN
			RAISERROR('ERRO: Já existe um funcionário com esse ID!', 16, 1) WITH LOG;
		END
	ELSE
		IF @tipo = 'M'
			BEGIN
				INSERT INTO Funcionario VALUES  (@funcID, @primeiroNome, @ultimoNome, @dataNascimento, @genero, @telefone, @morada, @salary, @email, @tipo);
				INSERT INTO Medico VALUES  (@funcID, @deptID);
				PRINT 'Sucess';
			END
		ELSE IF @tipo = 'E'
			BEGIN
				INSERT INTO Funcionario VALUES  (@funcID, @primeiroNome, @ultimoNome, @dataNascimento, @genero, @telefone, @morada, @salary, @email, @tipo);
				INSERT INTO Enfermeiro VALUES  (@funcID, @deptID);
				PRINT 'Sucess';
			END
		ELSE
			BEGIN
				INSERT INTO Funcionario VALUES  (@funcID, @primeiroNome, @ultimoNome, @dataNascimento, @genero, @telefone, @morada, @salary, @email, @tipo);
				INSERT INTO Rececionista VALUES  (@funcID, @balcao);
				PRINT 'Sucess';
			END
END
/* Eliminar um Funcionário do sistema em função do seu func_ID */
DROP PROC sp_eliminarFuncionario;
GO 
CREATE PROCEDURE sp_eliminarFuncionario (@func_ID INT)
AS 
BEGIN
		DECLARE @type AS CHAR(1);
		DECLARE @medico_consulta AS INT;
		DECLARE @medico_cirurgia AS INT;
		DECLARE @enfermeiro_cirurgia AS INT;
		DECLARE @equipa_cirurgia AS INT;
		DECLARE @enfermeiro_supervisiona AS INT;
		DECLARE @enfermeiro_auxilia AS INT;

		SELECT @type = tipo FROM Funcionario WHERE @func_ID = func_ID;
		SELECT @equipa_cirurgia = Cirurgia.EquipaM_ID FROM Cirurgia JOIN EM_contemMed ON Cirurgia.EquipaM_ID = EM_contemMed.EquipaM_ID WHERE @func_ID = func_ID_Medico;

		IF @type = 'M'
			BEGIN
				-- Verificar se o medico tinha consulta marcada
				SELECT @medico_consulta = COUNT (*) FROM Consulta WHERE func_ID_Medico = @func_ID;
				IF @medico_consulta > 0	-- medico tem consulta
				   UPDATE Consulta SET func_ID_Medico = NULL, noUtenteSaude = NULL, dataConsulta = NULL, hora = NULL WHERE func_ID_Medico = @func_ID;

				-- Verificar se o medico tinha cirurgia marcada
				SELECT @medico_cirurgia = COUNT (*) FROM Cirurgia JOIN EM_contemMed ON Cirurgia.EquipaM_ID = EM_contemMed.EquipaM_ID WHERE func_ID_Medico = @func_ID;
				IF @medico_cirurgia > 0	-- medico tem cirurgia
					UPDATE Cirurgia
					SET tipoCirurgia = NULL, noUtenteSaude = NULL, dataCirurgia = NULL, Hora_Inicio = NULL, Duracao = NULL, EquipaM_ID = NULL, noBlocoOperatorio = NULL
					WHERE EquipaM_ID = @equipa_cirurgia;

				DELETE FROM Medico WHERE @func_ID = func_ID_Medico;
				DELETE FROM Funcionario WHERE @func_ID = func_ID;			
			END

		ELSE IF @type = 'E'
			BEGIN
				--Verificar se o enfermeiro tinha cirurgia marcada
				SELECT @enfermeiro_cirurgia = COUNT (*) FROM Cirurgia JOIN EM_contemEnf ON Cirurgia.EquipaM_ID = EM_contemEnf.EquipaM_ID WHERE func_ID_Enf = @func_ID;
				IF @enfermeiro_cirurgia > 0	-- enfermeiro tem cirurgia
					UPDATE Cirurgia
					SET tipoCirurgia = NULL, noUtenteSaude = NULL, dataCirurgia = NULL, Hora_Inicio = NULL, Duracao = NULL, EquipaM_ID = NULL, noBlocoOperatorio = NULL
					WHERE EquipaM_ID = @equipa_cirurgia;
				/*
				--Verificar se supervisiona alguma cama
				SELECT @enfermeiro_supervisiona = COUNT (*) FROM Enf_Supervisiona JOIN Cama_Hospital ON Enf_Supervisiona.ID_Cama = Cama_Hospital.ID_Cama WHERE func_ID_Enf = @func_ID AND Cama_Hospital.camaLivre = 1;
				IF @enfermeiro_supervisiona > 0 --enfermeiro supervisiona
					UPDATE Enf_Supervisiona
					SET func_ID_Enf = NULL, ID_Cama = NULL
					WHERE func_ID_Enf = @func_ID;

				--Verificar se auxilia algum paciente
				SELECT @enfermeiro_auxilia = COUNT (*) FROM Enf_Auxilia WHERE func_ID_Enf = @func_ID;
				IF @enfermeiro_auxilia > 0
					UPDATE Enf_Auxilia
					SET func_ID_Enf = NULL, noUtenteSaude = NULL
					WHERE func_ID_Enf = @func_ID;
				*/
				DELETE FROM Enf_Supervisiona WHERE @func_ID = func_ID_Enf; --não tenho a certeza destes 2
				DELETE FROM Enf_Auxilia WHERE @func_ID = func_ID_Enf;
				DELETE FROM Enfermeiro WHERE @func_ID = func_ID_Enf;
				DELETE FROM Funcionario WHERE @func_ID = func_ID;
			END
		ELSE
			BEGIN
				DELETE FROM Rececionista WHERE @func_ID = func_ID_Rec;
				DELETE FROM Funcionario WHERE @func_ID = func_ID;
			END
		END
END	
/* Atualizar os dados de um Funcionário no Sistema.	*/
DROP PROC sp_updateInfoFuncionario;
GO 
CREATE PROCEDURE sp_updateInfoFuncionario (@funcID INT, @primeiroNome CHAR(15), @ultimoNome CHAR(15), @dataNascimento DATE, @genero CHAR(1), @telefone CHAR(9), 
									@morada CHAR(40), @salary SMALLMONEY, @email CHAR(30), @tipo CHAR(1))
AS
BEGIN 
	BEGIN TRY
		BEGIN TRANSACTION
		SET NOCOUNT ON
			DECLARE @funcID_old AS INT;
			DECLARE @primeiroNome_old AS CHAR(15);
			DECLARE @ultimoNome_old AS CHAR(15);
			DECLARE @dataNascimento_old AS DATE;
			DECLARE @genero_old AS CHAR(1);
			DECLARE @telefone_old AS CHAR(9);
			DECLARE @morada_old AS CHAR(40);
			DECLARE @salary_old AS SMALLMONEY;
			DECLARE @email_old AS CHAR(30);

			SELECT @funcID_old = func_ID, @primeiroNome_old = primeiroNome, @ultimoNome_old = ultimoNome, @dataNascimento_old = dataNascimento, 
			@genero_old = genero, @telefone_old = noTelefone, @morada_old = morada, @salary_old = salary, @email_old = email
			FROM Funcionario
			WHERE func_ID = @funcID;

			IF @funcID != @funcID_old
			BEGIN
				UPDATE Funcionario SET func_ID = @funcID WHERE func_ID = @funcID_old;
			END

			IF @primeiroNome != @primeiroNome_old
			BEGIN
				UPDATE Funcionario SET primeiroNome = @primeiroNome WHERE func_ID = @funcID_old;
			END

			IF @ultimoNome != @ultimoNome_old
			BEGIN
				UPDATE Funcionario SET ultimoNome = @ultimoNome WHERE func_ID = @funcID_old;
			END

			IF @dataNascimento != @dataNascimento_old
			BEGIN
				UPDATE Funcionario SET dataNascimento = @dataNascimento WHERE func_ID = @funcID_old;
			END

			IF @genero != @genero_old
			BEGIN
				UPDATE Funcionario SET genero = @genero WHERE func_ID = @funcID_old;
			END

			IF @telefone != @telefone_old
			BEGIN
				UPDATE Funcionario SET noTelefone = @telefone WHERE func_ID = @funcID_old;
			END

			IF @morada != @morada_old
			BEGIN
				UPDATE Funcionario SET morada = @morada WHERE func_ID = @funcID_old;
			END

			IF @salary != @salary_old
			BEGIN
				UPDATE Funcionario SET salary = @salary WHERE func_ID = @funcID_old;
			END

			IF @email != @email_old
			BEGIN
				UPDATE Funcionario SET email = @email WHERE func_ID = @funcID_old;
			END
			
			COMMIT TRANSACTION
		END TRY

		BEGIN CATCH
			PRINT ERROR_MESSAGE()
			ROLLBACK
		END CATCH	
END 