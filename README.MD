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

**Asp .Net Core:**

* [.NET Core SDK](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md)

**RabbitMQ**

* [RabbitMQ](https://www.rabbitmq.com/download.html)

**Mysql:**

* [MySQL](https://www.mysql.com/downloads/)


**Visual Studio:**

* [Visual Studio](https://visualstudio.microsoft.com/pt-br/)


**Docker Compose:**

* [Visual Studio](https://www.docker.com/products/docker-desktop)


## Configuração para Execução do projeto

**Acessar a pasta raiz do projeto:**

**Executar Docker:**

```sh
docker-compose up -d
```

## Autenticação

**Administrador Padrão:**

```sh
Email:
Senha:
```

**Cliente:**

```sh
Efetuar cadastro da conta digital para geração do acesso.
```

## WEB APIs

**Recursos disponiveis:**

| Recurso | Url |Versão | Documentação |
| -- | -- | -- | -- |
| Autenticação Pública | http://localhost:5001/ | v1 | * [DigitalBank.Api.Pub.Authenticate](DigitalBank.Api.Pub/DigitalBank.Api.Pub.Authenticate/readme.md) |



