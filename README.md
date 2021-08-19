# Meus Produtos
API RESTful simples usando ASP .NET 5 com C# e persistência de dados com Sqlite.

## Pré-Requisitos
- .NET SDK
- VS Code ou Visual Studio

## Intruções
Para executar o projeto no terminal, digite o seguinte comando:
```bash
dotnet watch run
```

Após isso, o projeto pode ser visualizado no seguinte endereço:
```bash
http://localhost:5001/
```

A documentação gerada pelo Swagger pode ser acessada no endereço:
```bash
https://localhost:5001/swagger/index.html
```

Os verbos POST, PUT e DELETE de usuário são autenticados.<br>
Já existe um usuário padrão salvo no banco para para fazer login e poder cadastrar, deletar e atualizar usuários.
```bash
{
    "name": "Admin",
    "email": "admin@admin.com",
    "password": "administrador"
}
```

## Desafios/Problemas

Não tive problemas durante a implementação desse projeto, já que eu já possuo um certo conhecimento na criação de APIs.<br>
Meu maior desafio foi durante a implementação da autenticação com jwt, porque eu não possuia muito conhecimento sobre o assunto. Mas depois de algumas leituras ficou claro para mim como esse sistema de degração de token funciona.
