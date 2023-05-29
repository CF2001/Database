
/** Pesquisar um Paciente em função do seu número de utente (noUtenteSaude) */
DROP FUNCTION getPacienteBy_NoUtenteSaude;
GO 
CREATE FUNCTION getPacienteBy_NoUtenteSaude (@noUtenteSaude INT) RETURNS TABLE
AS 
	RETURN (SELECT * 
			FROM Paciente
			WHERE noUtenteSaude = @noUtenteSaude 
			)

GO
-- Teste
SELECT * FROM getPacienteBy_NoUtenteSaude(22222730);


/** Pesquisar um Paciente em função do seu nome (primeiro e ultimo) */
--DROP FUNCTION getPacienteBy_Name;
--GO 
--CREATE FUNCTION getPacienteBy_Name (@firstName CHAR(15),@lastName CHAR(15)) RETURNS TABLE
--AS 
--	RETURN (SELECT *
--			FROM Paciente 
--			WHERE ( (primeiroNome LIKE '%' + @firstName + '%') OR (ultimoNome LIKE '%' + @lastName + '%') ) 
--			)
			 
--GO
---- Teste
--SELECT * FROM getPacienteBy_Name ('Ines', 'Matins');		--- VER MELHOR


/** Pesquisar Pacientes em função do ID do quarto */
DROP FUNCTION getPacienteBy_IDQuarto
GO
CREATE FUNCTION getPacienteBy_IDQuarto (@quartoID INT)	RETURNS TABLE
AS 
	RETURN (SELECT noUtenteSaude, primeiroNome, ultimoNome, dataEntrada, dataSaida
			FROM Paciente
			WHERE ID_Quarto = @quartoID)
GO

--Teste
SELECT * FROM getPacienteBy_IDQuarto (4);


/** Pesquisar as camas e o seu estado em função do ID do quarto */
DROP FUNCTION getCamaHospitalBy_IDQuarto
GO
CREATE FUNCTION  getCamaHospitalBy_IDQuarto (@quartoID INT)	RETURNS TABLE
AS 
	RETURN (SELECT ID_Cama, camaOcupada
			FROM Cama_Hospital
			WHERE ID_Quarto = @quartoID )
GO

--Teste
SELECT * FROM Paciente;
SELECT * FROM Cama_Hospital;
SELECT * FROM  getCamaHospitalBy_IDQuarto (2);


/** Pesquisar os enfermeiros supervisores de um determinado quarto */
DROP FUNCTION getEnfSupervisorBy_IDQuarto;
GO
CREATE FUNCTION getEnfSupervisorBy_IDQuarto (@quartoID INT)	RETURNS TABLE
AS 
	RETURN (SELECT ID_Cama, func_ID_EnfS
			FROM Cama_Hospital, Enf_Supervisiona
			WHERE ID_Quarto = @quartoID AND ID_Cama = ID_Cama_EnfS)
GO


/** Devolve uma lista de enfermeiros que não estão a supervisionar uma cama */
DROP FUNCTION getEnfermeiros_naoS;
GO
CREATE FUNCTION getEnfermeiros_naoS() RETURNS TABLE
AS 
	RETURN (Select func_ID_Enf
			From Enfermeiro LEFT OUTER JOIN Enf_Supervisiona ON func_ID_Enf = func_ID_EnfS
			WHERE func_ID_EnfS is NULL)
GO

-- Teste
Select * FROM getEnfermeiros_naoS();


/** Pesquisar um Departamento pelo seu nome **/
DROP FUNCTION getDepartBy_Name;
GO 
CREATE FUNCTION getDepartBy_Name (@nomeDep CHAR(20) ) RETURNS TABLE
AS 
	RETURN (SELECT *
			FROM Departamento 
			WHERE ( (nome_dept LIKE '%' + @nomeDep + '%'))
			)
GO
--Teste
SELECT * FROM getDepartBy_Name('Emergência');



/** Pesquisar um Funcionario em função do seu ID */
DROP FUNCTION getFuncByID;
GO 
CREATE FUNCTION getFuncByID (@funcID INT) RETURNS TABLE
AS 
	RETURN (SELECT * 
			FROM Funcionario
			WHERE func_ID = @funcID 
			)

GO
-- Teste
SELECT * FROM getFuncByID(3);


/** Pesquisar uma Consulta pelo numero de Utente de Saude do Paciente **/
DROP FUNCTION getConsulta;
GO 
CREATE FUNCTION getConsulta (@noUtenteSaude INT ) RETURNS TABLE
AS 
	RETURN (SELECT *
			FROM Consulta 
			WHERE @noUtenteSaude = noUtenteSaude
			)
GO
--Teste
SELECT * FROM getConsulta(12345070);


/** Pesquisar uma Cirurgia pelo numero de Utente de Saude do Paciente **/
DROP FUNCTION getCirurgia;
GO 
CREATE FUNCTION getCirurgia (@noUtenteSaude INT ) RETURNS TABLE
AS 
	RETURN (SELECT *
			FROM Cirurgia 
			WHERE @noUtenteSaude = noUtenteSaude
			)
GO
--Teste
select * from Cirurgia
SELECT * FROM getCirurgia(66654311);
