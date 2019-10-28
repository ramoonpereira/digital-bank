# Digital Bank

>Worker Transaction - Worker de Transações


**Worker de Transações**

* Responsável por efetuar o processamento das transações do sistema



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