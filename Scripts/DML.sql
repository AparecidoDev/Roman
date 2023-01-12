--DML
USE Roman
GO

INSERT INTO TipoUsuario (NomeTipoUsuario)
VALUES					('Administrador')
						,('Professor');
GO

INSERT INTO Usuario  ( IdTipoUsuario , NomeUsuario  , Email   ,			Senha, IdEquipe )
VALUES				 (  1			,'Caique'	,'Caique@adm.com'		,1234, 1)
					,(	1			,'saulo'	,'Saulo@adm.com	'		,1234, 1)
					,(	2			,'Aparecido','Aparecido@email.com'	,1234, 1)
					,(	2			,'Carlos'	,'Carlos@email.com'		,1234, 2)
					,(	2			,'João'		,'Joao@email.com'		,1234, 2)
					,(	2			,'Joyce'	,'Joyce@email.com'		,1234, 3)
					,(	2			,'Yuri'		,'Yuri@email.com'		,1234, 3);
GO


INSERT INTO Equipe (NomeEquipe)
VALUES				('Desenvolvimento')
					,('Redes'		  )
					,('Multimídia'	  );
GO

INSERT INTO Projeto (IdUsuario,	NomeProjeto, Idtema, Descricao)
VALUES				( 2,	'Controle de Estoque', 1, 'Programa para gerir empresas' );

GO

INSERT INTO Tema ( NomeTema, Ativo)
VALUES			('Gestão',	1)
				,('HQs',  1);
GO


