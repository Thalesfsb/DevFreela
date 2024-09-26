# DevFreela

## Descrição

O **DevFreela** é uma aplicação backend desenvolvida em .NET Core como parte de uma mentoria para aprimorar habilidades em arquitetura de software, microsserviços, mensageria, autenticação e autorização com JWT, e testes unitários com xUnit. A plataforma simula um marketplace para desenvolvedores freelancers, onde clientes podem contratar profissionais para realizar projetos de desenvolvimento de software.

## Funcionalidades

- Cadastro de usuários (clientes e freelancers)
- Autenticação e autorização com JWT
- Criação, gerenciamento e conclusão de projetos

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET Core
- **Design de Software**: SOLID
- **Padrão de Arquitetura**: CQRS
- **Arquitetura**: DDD com Padrão repository
- **Banco de Dados**: SQL Server
- **Autenticação**: JWT
- **Testes Unitários**: xUnit
- **Controle de versão**: Git

## Estrutura do Projeto

- **DevFreela.API**: Camada de apresentação (API)
- **DevFreela.Application**: Lógica de negócios e regras de aplicação
- **DevFreela.Core**: Classes principais e entidades do domínio
- **DevFreela.Infrastructure**: Acesso a dados e integração com serviços externos
- **DevFreela.UnitTests**: Testes unitários utilizando xUnit

## Configuração e Execução do Projeto

### Pré-requisitos

- .NET Core SDK 6.0+
- SQL Server
- RabbitMQ

### Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/Thalesfsb/DevFreela.git

2. Navegue até o diretório do projeto:
   ```bash
   cd DevFreela
   
3. Configure a string de conexão do banco de dados no arquivo appsettings.json.
   
4. Execute as migrações do Entity Framework para criar as tabelas no banco de dados:
   ```bash
   dotnet ef database update
   
5. Inicie o projeto:
   ```bash
   dotnet run --project DevFreela.API
   
6. Acesse a API em http://localhost:5000.

## Próximos Passos
- Implementar novas funcionalidades como chat entre clientes e freelancers.
- Integração com gateways de pagamento reais.
- Melhoria nas métricas e monitoramento com ferramentas como o AWS CloudWatch.

## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou fazer um pull request.

## Licença
Este projeto está licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.
