-------------------------------------------------- Inserção de valores  ----------------------------------------------------------------

-- Funcionario 
-- (func_ID, primeiroNome, ultimoNome, genero, morada, dataNascimento, email, noTelefone, salary)

-- RECECIONISTAS
INSERT INTO Funcionario VALUES (1, 'Miguel', 'Ferreira', 'M', 'Rua da FRENTE', '1970-08-11','miguelF@gmail.com', 911222333, 819.50)
-- ENFERMEIROS
INSERT INTO Funcionario VALUES (2, 'Maria', 'Sousa', 'F', 'Rua XPTO', '1980-01-01','mariaS@gmail.com', 911333444, 2000)	
INSERT INTO Funcionario VALUES (3, 'Juliana', 'Gomes', 'F', 'Rua A', '1980-08-11','julianaG@gmail.com', 922666777, 2000)		
INSERT INTO Funcionario VALUES (10, 'Catarina', 'Martins', 'F', 'Rua XW', '1970-01-15','catarinaM@gmail.com', 936732111, 2000)
INSERT INTO Funcionario VALUES (11, 'Diana', 'Rosa', 'F', 'Rua HH', '1965-01-15','dianaR@gmail.com', 944555666, 2000)	
INSERT INTO Funcionario VALUES (15, 'Eduardo', 'Fernades', 'M', 'Rua ED', '1965-06-20','eduardoF@gmail.com', 918780101, 2000)
INSERT INTO Funcionario VALUES (16, 'Diogo', 'Gomes', 'M', 'Rua DI', '1965-11-15','diogoG@gmail.com', 944555666, 2000)
-- MEDICOS
INSERT INTO Funcionario VALUES (4, 'Joao', 'Pereira', 'M', 'Rua B ', '1977-05-01','joaoP@gmail.com', 911222999,3223)		
INSERT INTO Funcionario VALUES (5, 'Ana', 'Silva', 'F', 'Rua C', '1969-01-01','anaS@gmail.com', 911555333, 5932.50)			
INSERT INTO Funcionario VALUES (6, 'Mariana', 'Costa', 'F', 'Rua D', '1990-03-03','marianaC@gmail.com', 968123123, 2637.50)  
INSERT INTO Funcionario VALUES (7, 'Ricardo', 'Amaral', 'M', 'Rua E', '1968-01-15','ricardoA@gmail.com', 936732111, 4029.50)	
INSERT INTO Funcionario VALUES (8, 'Manuel', 'Santos', 'M', 'Rua XP', '2000-01-15','manuelS@gmail.com', 918999333, 2738.60)	
INSERT INTO Funcionario VALUES (9, 'Silvia', 'Pombo', 'F', 'Rua XY', '2000-04-15','silviaP@gmail.com', 918882921, 4839)
INSERT INTO Funcionario VALUES (12, 'Adriano', 'Santos', 'M', 'Rua OO', '1970-07-15','adriano@gmail.com', 937900111, 4839)
INSERT INTO Funcionario VALUES (13, 'Alice', 'Silva', 'F', 'Rua VV', '1969-11-15','alice@gmail.com', 927891011, 4839)
INSERT INTO Funcionario VALUES (14, 'Andre', 'Fernandes', 'M', 'Rua EE', '1967-12-15','andre@gmail.com', 910003456, 4839)

-- Departamento 
-- (nome_dept, ID_dept, ID_supervisor_dept)
INSERT INTO Departamento VALUES ('Emergência', 1, NULL)
INSERT INTO Departamento VALUES ('Cardiologia', 2, NULL)
INSERT INTO Departamento VALUES ('Terapia intensiva',3, NULL)
INSERT INTO Departamento VALUES ('Neurologia', 4, NULL)
INSERT INTO Departamento VALUES ('Oncologia', 5, NULL)
INSERT INTO Departamento VALUES ('Obstetricia', 6,  NULL)
INSERT INTO Departamento VALUES ('Patologia', 7, NULL)
INSERT INTO Departamento VALUES ('Radiologia', 8, NULL)


-- Medico 
-- ( func_ID_Medico, ID_dept )	
INSERT INTO Medico VALUES (4, 2)
INSERT INTO Medico VALUES (5, 4)
INSERT INTO Medico VALUES (6, 4)
INSERT INTO Medico VALUES (7, 1)
INSERT INTO Medico VALUES (8, 7)
INSERT INTO Medico VALUES (9, 1)
INSERT INTO Medico VALUES (12, 2)
INSERT INTO Medico VALUES (13, 3)
INSERT INTO Medico VALUES (14, 8)


UPDATE Departamento SET ID_supervisor_dept = 9 WHERE ID_dept = 1; 
UPDATE Departamento SET ID_supervisor_dept = 4 WHERE ID_dept = 2; 
UPDATE Departamento SET ID_supervisor_dept = 13 WHERE ID_dept = 3;
UPDATE Departamento SET ID_supervisor_dept = 5 WHERE ID_dept = 4;
UPDATE Departamento SET ID_supervisor_dept = 8 WHERE ID_dept = 7;
UPDATE Departamento SET ID_supervisor_dept = 14 WHERE ID_dept = 8;



-- Especialização_Medico
-- (func_ID_Medico, especializacao)
INSERT INTO Especializacao_Medico VALUES (4, 'Cirurgia Cardiaca')
INSERT INTO Especializacao_Medico VALUES (5, 'Neurologia')
INSERT INTO Especializacao_Medico VALUES (6, 'Neurologia')
INSERT INTO Especializacao_Medico VALUES (7, 'Cirurgia Geral')
INSERT INTO Especializacao_Medico VALUES (8, 'Patologia')
INSERT INTO Especializacao_Medico VALUES (9, 'Cirugia Geral')


-- Enfermeiro
-- (func_ID_Enf, ID_dept)
INSERT INTO Enfermeiro VALUES (2, 6)
INSERT INTO Enfermeiro VALUES (3, 7)
INSERT INTO Enfermeiro VALUES (10, 3)
INSERT INTO Enfermeiro VALUES (11, 4)
INSERT INTO Enfermeiro VALUES (15, 1)
INSERT INTO Enfermeiro VALUES (16, 2)


-- Rececionista 
-- (func_ID_Rec, Balcao)
INSERT INTO Rececionista VALUES (1,'A')


-- Paciente 
-- (noUtenteSaude, primeiroNome, ultimoNome, dataNascimento, genero, noTelefone, func_ID_Rec, ID_Quarto, dataEntrada, dataSaida)

-- NÃO Internados
INSERT INTO Paciente VALUES (23456701, 'Maria', 'Ferandes', '2000-05-2', 'F', 911237643, 1, NULL, NULL, NULL)
INSERT INTO Paciente VALUES (34521102, 'Carlos', 'Silva', '1999-05-2', 'M', 922333876, 1, NULL, NULL, NULL)
INSERT INTO Paciente VALUES (67890510, 'Andre', 'Rosa', '2003-01-15', 'M', 937848321, 1, NULL, NULL, NULL)
INSERT INTO Paciente VALUES (22222730, 'Vitor', 'Martins', '1980-02-3', 'M', 962876123, 1, NULL, NULL, NULL)
INSERT INTO Paciente VALUES (11111740, 'Joao', 'Sousa', '2000-05-20', 'M', 968911111, 1, NULL, NULL, NULL)
INSERT INTO Paciente VALUES (33333744, 'Pedro', 'Gomes', '1969-05-2', 'M', 911999999, 1, NULL, NULL, NULL)


-- Quarto_Hospital
-- (ID_Quarto, noCamas)
-- NOTA: Estes valores têm de ser inseridos primeiro que os pacientes internados !!
INSERT INTO Quarto_Hospital VALUES (1, 3)
INSERT INTO Quarto_Hospital VALUES (2, 1)
INSERT INTO Quarto_Hospital VALUES (3, 3)
INSERT INTO Quarto_Hospital VALUES (4, 1)
INSERT INTO Quarto_Hospital VALUES (5, 2)
INSERT INTO Quarto_Hospital VALUES (6, 3)
INSERT INTO Quarto_Hospital VALUES (7, 1)
INSERT INTO Quarto_Hospital VALUES (8, 2)


-- Pacientes Internados
INSERT INTO Paciente VALUES (44445533, 'Mariana', 'Amaral', '1977-05-02', 'F', 924444442, 1, 5, '2022-06-17', NULL)
INSERT INTO Paciente VALUES (66654311, 'Catatina', 'Costa', '1980-11-02', 'F', 917777888, 1, 5, '2022-06-17', NULL)
INSERT INTO Paciente VALUES (12345070, 'Mario', 'Silva', '1999-12-02', 'M', 921811818, 1, 2, '2022-06-17', NULL)
INSERT INTO Paciente VALUES (87969404, 'Afonso', 'Pereira', '2000-06-02', 'M', 967821111, 1, 4, '2022-06-17', NULL)



-- Cama_Hospital
-- (ID_Cama, camaOcupada, ID_Quarto) -- 0 : livre , 1: ocupado

-- Quarto 1
INSERT INTO Cama_Hospital VALUES ('A1', 0, 1)
INSERT INTO Cama_Hospital VALUES ('B1', 0, 1)
INSERT INTO Cama_Hospital VALUES ('C1', 0, 1)
-- Quarto 2
INSERT INTO Cama_Hospital VALUES ('A2', 1, 2)
-- Quarto 3
INSERT INTO Cama_Hospital VALUES ('A3', 0, 3)
INSERT INTO Cama_Hospital VALUES ('B3', 0, 3)
INSERT INTO Cama_Hospital VALUES ('C3', 0, 3)
-- Quarto 4
INSERT INTO Cama_Hospital VALUES ('A4', 1, 4)
-- Quarto 5
INSERT INTO Cama_Hospital VALUES ('A5', 1, 5)
INSERT INTO Cama_Hospital VALUES ('B5', 1, 5)
-- Quarto 6
INSERT INTO Cama_Hospital VALUES ('A6', 0, 6)
INSERT INTO Cama_Hospital VALUES ('B6', 0, 6)
INSERT INTO Cama_Hospital VALUES ('C6', 0, 6)
-- Quarto 7
INSERT INTO Cama_Hospital VALUES ('A7', 0, 7)
-- Quarto 8
INSERT INTO Cama_Hospital VALUES ('A8', 0, 8)
INSERT INTO Cama_Hospital VALUES ('B8', 0, 8)




-- Enf_Auxilia										
-- (func_ID_Enf, noUtenteSaude)
INSERT INTO Enf_Auxilia VALUES (2, 12345070)
INSERT INTO Enf_Auxilia VALUES (3, 87969404)
INSERT INTO Enf_Auxilia VALUES (10, 44445533)
INSERT INTO Enf_Auxilia VALUES (11, 66654311)
INSERT INTO Enf_Auxilia VALUES (15, 23456701)
INSERT INTO Enf_Auxilia VALUES (16, 34521102)


-- Enf_Supervisiona								
-- (func_ID_Enf, ID_Cama_EnfS)

INSERT INTO Enf_Supervisiona VALUES (2, 'A2')
INSERT INTO Enf_Supervisiona VALUES (3, 'A4')
INSERT INTO Enf_Supervisiona VALUES (10, 'A5')
INSERT INTO Enf_Supervisiona VALUES (11, 'B5')



-- Consulta
-- (func_ID_Medico, noUtenteSaude, noConsulta, dataConsulta, hora)
INSERT INTO Consulta VALUES (12, 23456701, 1, '2022-06-11', '10h AM')
INSERT INTO Consulta VALUES (5, 67890510, 2, '2022-08-04', '5h30 PM')
INSERT INTO Consulta VALUES (7, 22222730, 3, '2022-06-20', '11h AM')
INSERT INTO Consulta VALUES (8, 12345070, 4, '2022-07-02', '3h PM')


-- Farmaco 
-- ( codigo, nome, custo )
INSERT INTO Farmaco VALUES (234,'Algimate', 10)
INSERT INTO Farmaco VALUES (165,'Cloxam', 20)
INSERT INTO Farmaco VALUES (7654,'CitraFleet', 24)
INSERT INTO Farmaco VALUES (1096,'Egostar', 15)
INSERT INTO Farmaco VALUES (9821,'Colchicine', 13)



-- Prescreve
-- (func_ID_Medico, noConsulta, codigo_Farmaco, qtdCaixa)
INSERT INTO Prescreve VALUES (12, 1, 234, 1)
INSERT INTO Prescreve VALUES (5, 2, 7654, 2)
INSERT INTO Prescreve VALUES (7, 3, 1096, 1)
INSERT INTO Prescreve VALUES (8, 4, 9821, 1)


--Equipa_Medica 
-- ( equipaM_ID, Super_func_ID_Medico )
INSERT INTO Equipa_Medica VALUES (1, 4)
INSERT INTO Equipa_Medica VALUES (2, 6)

-- Bloco_Operatorio
-- (noBloco, utilizacao)	-- 0: livre , 1 : ocupado
INSERT INTO Bloco_Operatorio VALUES (1,0)
INSERT INTO Bloco_Operatorio VALUES (2,0)
INSERT INTO Bloco_Operatorio VALUES (3,0)
INSERT INTO Bloco_Operatorio VALUES (4,0)
INSERT INTO Bloco_Operatorio VALUES (5,0)
INSERT INTO Bloco_Operatorio VALUES (6,0)
INSERT INTO Bloco_Operatorio VALUES (7,0)

-- Cirurgia 
-- (tipoCirurgia, dataCirurgia, Hora_Inicio, Duracao, EquipaM_ID, noBlocoOperatorio, noUtenteSaude)
INSERT INTO Cirurgia VALUES ('Cirurgia cardiaca', '2022-7-02', '10h AM', '6h30', 1, 5, 66654311)
INSERT INTO Cirurgia VALUES ('Cirurgia neurologica', '2022-7-10', '2h30 PM', '12h',2, 7, 22222730)
INSERT INTO Cirurgia VALUES ('Cirurgia torácica', '2022-8-19', '8h30 AM', '7h', 1, 3, 66654311 )


-- EM_contemEnf
-- (func_ID_Enf, EquipaM_ID)
INSERT INTO EM_contemEnf VALUES (16,1)
INSERT INTO EM_contemEnf  VALUES (11,1)
INSERT INTO EM_contemEnf  VALUES (15,1)
INSERT INTO EM_contemEnf  VALUES (11,2)
INSERT INTO EM_contemEnf  VALUES (15,2)
INSERT INTO EM_contemEnf  VALUES (3,2)


--  EM_contemMed
-- (func_ID_Medico, EquipaM_ID)
INSERT INTO EM_contemMed VALUES (9, 1)
INSERT INTO EM_contemMed VALUES (4, 2)


-- TESTES 
-- DELETE FROM Cama_Hospital;
--SELECT * FROM Paciente;
--DELETE FROM Paciente WHERE noUtenteSaude=1237858;