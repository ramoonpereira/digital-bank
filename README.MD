# Digital Bank

>Web Apis Digital Bank - Banco Digital

![image](https://credicarvantagens.com/wp-content/uploads/2019/07/banco-digital.jpg)

## Requisitos - Desenvolvedor
```sh
Asp .Net Core - >= 2.2
Docker Compose - >= 17.09.0
RabbitMQ - 3.0 
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

* [Secrets](secrets)

```sh
- JWT_SECRET: Secret da geração dos tokens de acesso do projeto
- JWT_EXPIREHOURS: Tempo de expiração do token gerado no projeto
- ENCRYPTOR_SECRET: Secret da criptografia do projeto
- MYSQL_CONNECTIONSTRING: String de conexão com o MySQL
```


**Executar Docker:**

```sh
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

## WEB APIs

**Recursos disponiveis:**

| Recurso | Url |Versão | Documentação |
| -- | -- | -- | -- |
| Autenticação Pública | http://localhost:5001/ | v1 | [DigitalBank.Api.Pub.Authenticate](DigitalBank.Api.Pub/DigitalBank.Api.Pub.Authenticate/readme.md) |
| Conta Digital Pública | http://localhost:5002/ | v1 | [DigitalBank.Api.Pub.DigitalAccount](DigitalBank.Api.Pub/DigitalBank.Api.Pub.DigitalAccount/readme.md) |
| Transação Pública | http://localhost:5003/ | v1 | [DigitalBank.Api.Pub.Transaction](DigitalBank.Api.Pub/DigitalBank.Api.Pub.Transaction/readme.md) |
| Autenticação Administrativa | http://localhost:7001/ | v1 | [DigitalBank.Api.Adm.Authenticate](DigitalBank.Api.Adm/DigitalBank.Api.Adm.Authenticate/readme.md) |
| Conta Digital Administrativa | http://localhost:7002/ | v1 | [DigitalBank.Api.Adm.DigitalAccount](DigitalBank.Api.Adm/DigitalBank.Api.Adm.DigitalAccount/readme.md) |
| Transação Administrativa | http://localhost:7003/ | v1 | [DigitalBank.Api.Adm.Transaction](DigitalBank.Api.Adm/DigitalBank.Api.Adm.Transaction/readme.md) |



