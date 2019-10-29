DIR="${PWD}"

echo "Iniciando Stack Deploy"

echo "Executando MYSQL"
docker-compose -f $DIR/DigitalBank.MySQL/docker-compose.yml up -d
echo "Finalizado MYSQL"
sleep 5s

echo "Executando RabbitMQ"
docker-compose -f $DIR/DigitalBank.RabbitMq/docker-compose.yml up -d
echo "Finalizado RabbitMQ"
sleep 5s

echo "Executando DigitalBank.Migrations"
docker-compose -f $DIR/DigitalBank.Migrations/DigitalBank.Migrations/docker-compose.yml up -d
echo "Finalizado DigitalBank.Migrations"
sleep 5s

echo "Executando Worker-Transaction"
docker-compose -f $DIR/DigitalBank.Worker.Transaction/docker-compose.yml up -d
echo "Finalizado Worker-Transaction"
sleep 5s

echo "Executando DigitalBank.Api.Pub.Authenticate"
docker-compose -f $DIR/DigitalBank.Api.Pub.Authenticate/docker-compose.yml up -d
echo "Finalizado DigitalBank.Api.Pub.Authenticate"
sleep 5s

echo "Executando DigitalBank.Api.Pub.DigitalAccount"
docker-compose -f $DIR/DigitalBank.Api.Pub.DigitalAccount/docker-compose.yml up -d
echo "Finalizado DigitalBank.Api.Pub.DigitalAccount"
sleep 5s

echo "Executando DigitalBank.Api.Pub.Transaction"
docker-compose -f $DIR/DigitalBank.Api.Pub.Transaction/docker-compose.yml up -d
echo "Finalizado DigitalBank.Api.Pub.Transaction"
sleep 5s

echo "Executando DigitalBank.Api.Adm.Authenticate"
docker-compose -f $DIR/DigitalBank.Api.Adm.Authenticate/docker-compose.yml up -d
echo "Finalizado DigitalBank.Api.Adm.Authenticate"
sleep 5s

echo "Executando DigitalBank.Api.Adm.DigitalAccount"
docker-compose -f $DIR/DigitalBank.Api.Adm.DigitalAccount/docker-compose.yml up -d
echo "Finalizado DigitalBank.Api.Adm.DigitalAccount"
sleep 5s


echo "Executando DigitalBank.Api.Adm.Transaction"
docker-compose -f $DIR/DigitalBank.Api.Adm.Transaction/docker-compose.yml up -d
echo "Finalizado DigitalBank.Api.Adm.Transaction"
sleep 5s


echo "Stack Finalizada"
sleep 5s
