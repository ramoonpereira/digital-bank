# Digital Bank

>Web Apis Digital Bank - Banco Digital

![image](https://credicarvantagens.com/wp-content/uploads/2019/07/banco-digital.jpg)

## Requisitos - Desenvolvedor
```sh
Asp .Net Core - >= 2.2
Docker Compose - >= 17.09.0
RabbitMQ - 3.8 
Visual Studio - 2019
MySql - 5.7
```

## Requisitos - Ambiente
```sh
Docker Compose - >= 17.09.0
```

## Instalação:

**Docker Compose:**

* [Visual Studio](https://www.docker.com/products/docker-desktop)

**Asp .Net Core:**

* [.NET Core SDK](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)

**RabbitMQ**

* [RabbitMQ](https://www.rabbitmq.com/download.html)

**Mysql:**

* [MySQL](https://www.mysql.com/downloads/)


**Visual Studio:**

* [Visual Studio](https://visualstudio.microsoft.com/pt-br/)


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

**Para criação de network (rede dos containers):**

```sh
docker network create --driver bridge digital-bank
```

**Executar Ambiente:**

```sh
./deploy-stack.sh
```

ou

```sh
Executar o comando dentro do repositorio de cada aplicação
docker-compose up -d
```

## Autenticação

**Administrador Padrão:**

```sh
Email: administrador@digitalbank.com
Senha: !@12QWqw
```

**Cliente:**

```sh
Efetuar cadastro da conta digital para geração de acesso conforme dados cadastrais.
```

## 
**Recursos disponiveis:**

| Recurso | Url |Versão | Documentação |
| -- | -- | -- | -- |
| Autenticação Pública | http://localhost:5001/ | v1 | [DigitalBank.Api.Pub.Authenticate](DigitalBank.Api.Pub.Authenticate/readme.md) |
| Conta Digital Pública | http://localhost:5002/ | v1 | [DigitalBank.Api.Pub.DigitalAccount](DigitalBank.Api.Pub.DigitalAccount/readme.md) |
| Transação Pública | http://localhost:5003/ | v1 | [DigitalBank.Api.Pub.Transaction](DigitalBank.Api.Pub.Transaction/readme.md) |
| Autenticação Administrativa | http://localhost:7001/ | v1 | [DigitalBank.Api.Adm.Authenticate](DigitalBank.Api.Adm.Authenticate/readme.md) |
| Conta Digital Administrativa | http://localhost:7002/ | v1 | [DigitalBank.Api.Adm.DigitalAccount](DigitalBank.Api.Adm.DigitalAccount/readme.md) |
| Transação Administrativa | http://localhost:7003/ | v1 | [DigitalBank.Api.Adm.Transaction](DigitalBank.Api.Adm.Transaction/readme.md) |
| Worker Transação | http://localhost:9001/ | v1 | [DigitalBank.Worker.Transaction](DigitalBank.Worker.Transaction/readme.md) |
| Migrations | http://localhost:9002/  | v1 | [DigitalBank.Migrations](DigitalBank.Migrations/DigitalBank.Migrations/readme.md) |
| MySQL | http://localhost:3306/ | 5.7 | [MySQL](DigitalBank.MySQL/readme.md) |
| RabbitMQ | http://localhost:15672/ | 3.8 | [RabbitMQ](DigitalBank.RabbitMQ/readme.md) |


