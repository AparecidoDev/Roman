# O que é o Roman?
É um app pensado para auxíliar professores na hora de encontrar ou criar situações-problema para os seus projetos que serão propostos em sala de aula. Ou seja, é uma plataforma para sugestão de projetos.

# Quais tecnologias foram utilizadas no desenvolvimento?
Foram utilizadas diversas tecnologias durante o processo de desenvolvimento:

<table>
  <thead>
     <tr>
      <th>Database</th>
      <th>Back-End</th>
      <th>Mobile</th>
      <th>Teste</th>
      <th>Prototipagem</th>
      <th>Gerenciamento do projeto</th>
      <th>Documentação da API</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><a target='_blank' href='https://www.microsoft.com/pt-br/sql-server/sql-server-2019'>SQL Server</a></td>
      <td><a target='_blank' href='https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-5.0'>Web Api (C#)</a></td>
      <td><a target='_blank' href='https://reactnative.dev/'>React Native</a></td>
      <td><a target='_blank' href='https://www.postman.com/'>Postman</a></td>
      <td><a target='_blank' href='https://www.figma.com/?fuid='>Figma</a></td>
      <td><a target='_blank' href='https://trello.com/pt-BR'>Trello</a></td>
      <td><a target='_blank' href='https://swagger.io/'>Swagger</a></td>
    </tr>
        <tr>
      <td>
        <a target='_blank' href='https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15'>SQL Server Management Studio</a>           </td>
      <td><a target='_blank' href='https://docs.microsoft.com/pt-br/ef/'>Entity Framework</a></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
    </tr>
  </tbody>
</table>


# Como rodar o projeto na sua máquina?
Siga o passo a passo abaixo para conseguir executar o app.
## Passo 1:
Clone o repositório na sua máquina.

https://user-images.githubusercontent.com/73193391/123517963-38122700-d67a-11eb-8d89-e828b6d56977.mp4

## Passo 2:
Dentro da pasta **Front_End**, abra a pasta **projeto_roman** no VS Code.

https://user-images.githubusercontent.com/73193391/123518251-765c1600-d67b-11eb-9dd5-d5046df33ffd.mp4

## Passo 3:
Execute no terminal o comando **npm install** para instalar os módulos do node.

https://user-images.githubusercontent.com/73193391/123518558-c1c2f400-d67c-11eb-8986-32a5f616cd24.mp4

## Passo 4:
Execute o comando **expo start** para inicializar o projeto e, logo em seguida, clique na opção **Run in web browser**.

https://user-images.githubusercontent.com/73193391/123518908-86c1c000-d67e-11eb-84b9-eccee7aae150.mp4

Obs: Utilize este E-Mail e Senha para realizar login no app:


E-Mail: **Aparecido@email.com**


Senha: **1234**


## Passo 5:
Abra o SQL Server Management Studio(SSMS) e execute os arquivos DDL, DML e DQL que estão na pasta **Scripts**.

https://user-images.githubusercontent.com/73193391/123519327-ddc89480-d680-11eb-9b4b-0ce6ec526b32.mp4

## Passo 6:
Dentro da pasta **WebApi**, abra a pasta **Roman.WebApi** e clique no arquivo **Roman.WebApi.sln** para abri-lo no Visual Studio 2019:

https://user-images.githubusercontent.com/73193391/123519822-ea9ab780-d683-11eb-9e83-b09e3f03f69a.mp4

## Passo 7:
Abra o arquivo **RomanContext.cs** e altere o **DataSource**, coloque o nome da instância do seu SQL Server e **salve a alteração**:

https://user-images.githubusercontent.com/73193391/123520052-23875c00-d685-11eb-9825-5fd4bf44728c.mp4

## Passo 8:
Execute a WebApi.

https://user-images.githubusercontent.com/73193391/123520199-ecfe1100-d685-11eb-9727-8bc3d858875f.mp4

# Pronto! Agora, você já pode utilizar o app!
