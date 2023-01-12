--DQL

USE Roman

SELECT * FROM TipoUsuario

SELECT TipoUsuario.Ne FROM Usuario

SELECT * FROM Equipe

SELECT NomeProjeto,NomeTema,Descricao FROM Projeto
INNER JOIN Tema
ON Projeto.IdTema = Tema.IdTema

SELECT * FROM Tema