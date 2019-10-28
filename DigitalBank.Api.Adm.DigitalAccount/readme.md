# Digital Bank

>DigitalBank.Api.Adm.DigitalAccount - Api Administrativa de Contas Digitais


**Api Administrativa de Contas Digitais**

**Recursos disponiveis:**

| Rota | Versão |Descrição | HTTP Method | Autenticação |
| -- | -- | -- | -- | -- |
| / | v1 |Interface para documentação da API| GET | |
| /digitalaccount/v1/{customerId}/bycustomer| v1 | Método para buscar uma conta digital especifica pelo id do cliente | GET |  [:white_check_mark:] |
| /digitalaccount/v1/{id} | v1 | Método para buscar uma conta digital especifica | GET |  [:white_check_mark:] |
| /digitalaccount/v1 | v1 | Método para buscar todas as contas | GET |  [:white_check_mark:]|

## Configuração para Execução do projeto

**Secrets:**

```sh
- JWT_SECRET: Secret da geração dos tokens de acesso no projeto
- JWT_EXPIREHOURS: Tempo de expiração de token gerado no projeto
- ENCRYPTOR_SECRET: Secret da criptografia no projeto
- MYSQL_CONNECTIONSTRING: String de conexão com o MySQL
- RABBITMQ_HOST: Host de conexão rabbitmq
- RABBITMQ_USER_NAME: Usuario rabbitmq
- RABBITMQ_PASSWORD: Senha rabbitmq
- RABBITMQ_TRANSACTION_EXCHANGE: Exchange de transações
- RABBITMQ_TRANSACTION_QUEUE: Fila de transações
- RABBITMQ_TRANSACTION_RETRY: Intervalo retentativas
- RABBITMQ_TRANSACTION_COUNT: Quantidade retentativas
- INTERVAL_ATTEMPT_TRANSACTION: Intervalo em minuto de verificação de transações para fraude
- RETRY_ATTEMPT_TRANSACTION: Quantidade de transações para fraude no intervalo especificado
```

**Para ativar politica de secrets (Caso não ativo no docker):**

```sh
docker swarm init
```

**Executar Docker:**

```sh
docker-compose up -d
```