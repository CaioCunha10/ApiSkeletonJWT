# WebApiJWT
<p>
   <h1>WebApi Security Authentication</h1>
</p>
<img src="https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExdm5vM3lpbDBlbXVsNG55aGJ2YWhnMGFoZGR3eDA0MmcxeDE5ZHZoaiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/gHPOb1fEVWu5GHL2tk/giphy.gif" width="300" height="300"/>


## Descrição
Este é um projeto de exemplo que demonstra a implementação de autenticação JWT em uma API Web utilizando ASP.NET Core.

## Recursos
- Implementação de autenticação JWT para proteger endpoints da API.
- Exemplo de registro de usuários e geração de tokens JWT.
- Exemplo de autenticação e autorização de usuários para acessar recursos protegidos.

## Requisitos
- [ASP.NET Core](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [Postman](https://www.postman.com/downloads/) ou qualquer outro cliente HTTP para testar a API.

## Configuração
1. Clone este repositório em sua máquina local.
git clone https://github.com/CaioCunha10/WebApiJWT.git

2. Abra o projeto no Visual Studio ou Visual Studio Code.

3. Configure sua conexão com o banco de dados no arquivo `appsettings.json`.

4. Compile e execute o projeto.

## Como Usar
1. Faça uma solicitação POST para `/api/auth/register` com os dados do usuário para se registrar.

POST /api/auth/register
{
"username": "usuario",
"password": "senha"
}

2. Faça uma solicitação POST para `/api/auth/login` com os dados de autenticação para obter um token JWT.
   
POST /api/auth/login
{
"username": "usuario",
"password": "senha"
}
3. Use o token JWT recebido para acessar os endpoints protegidos, incluindo o cabeçalho `Authorization: Bearer <token>` nas solicitações HTTP.

## Endpoints
- `POST /api/auth/register`: Registrar um novo usuário.
- `POST /api/auth/login`: Autenticar um usuário e obter um token JWT.
- Exemplos de endpoints protegidos que requerem autenticação:
- `GET /api/users`: Obter todos os usuários.
- `GET /api/users/{id}`: Obter detalhes de um usuário específico
