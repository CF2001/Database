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






------------------------------------------------------ FUNCIONÁRIO ------------------------------------------------------------------


/* Inserir um Funcionário no sistema do Hospital  */

/* Eliminar um Funcionário do sistema em função do seu func_ID */

/* Atualizar os dados de um Funcionário no Sistema.	*/


/**** NOTA: Para UDFs fazer filtragem de DADOS !!!!!