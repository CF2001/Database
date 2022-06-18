
/** Pesquisar um Paciente em fun��o do seu n�mero de utente (noUtenteSaude) */
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


/** Pesquisar um Paciente em fun��o do seu nome (primeiro e ultimo) */
DROP FUNCTION getPacienteBy_Name;
GO 
CREATE FUNCTION getPacienteBy_Name (@firstName CHAR(15),@lastName CHAR(15)) RETURNS TABLE
AS 
	RETURN (SELECT *
			FROM Paciente 
			WHERE ( (primeiroNome LIKE '%' + @firstName + '%') OR (ultimoNome LIKE '%' + @lastName + '%') ) 
			)
			 
GO
-- Teste
SELECT * FROM getPacienteBy_Name ('Ines', 'Matins');		--- VER MELHOR


/** Pesquisar Pacientes em fun��o do ID do quarto */

/** Pesquisar as camas e o seu estado em fun��o do ID do quarto */
