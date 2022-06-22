
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

SELECT * FROM Cama_Hospital;
SELECT * FROM Enf_Supervisiona;
-- Teste
SELECT * FROM getEnfSupervisorBy_IDQuarto (2);


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

