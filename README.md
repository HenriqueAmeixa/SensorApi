# SensorAPI 📡

API REST em ASP.NET Core 8 para coleta e registro de dados de sensores embarcados (ex: ESP32), como aceleração e temperatura.

---

## 📖 Visão Geral

Esta API permite registrar leituras de sensores de dispositivos conectados, armazenar em banco de dados SQL Server na Azure e expor endpoints REST para integração.

Agora também suporta envio de dados em **lote** com autenticação via **API Key**.

---

## ⚙️ Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- SQL Server (Azure)
- Swagger (Swashbuckle)
- Docker
- Azure App Service + ACR

---

## 🔐 Autenticação com API Key

O endpoint de envio em lote (`/api/SensorReadings/lote`) exige um header de autenticação:

```
Authorization: ApiKey SUA_CHAVE_AQUI
```

A chave deve estar cadastrada no banco na tabela `DeviceAuths` e estar ativa (`IsActive = 1`).

---

## 🚀 Executar localmente

```bash
# 1. Clone o repositório
git clone https://github.com/HenriqueAmeixa/SensorApi.git
cd SensorApi

# 2. Configure o appsettings.json com sua connection string

# 3. Execute a aplicação
dotnet run

# 4. Acesse no navegador
http://localhost:5000/swagger
```

---

## 🐳 Rodar com Docker

```bash
docker build -t sensorapi .
docker run -d -p 80:80 sensorapi
```

---

## 🔌 Endpoints

| Método | Rota                                      | Descrição                                        |
|--------|-------------------------------------------|--------------------------------------------------|
| POST   | `/api/devices`                            | Cadastra um novo dispositivo                     |
| GET    | `/api/devices`                            | Lista todos os dispositivos                      |
| GET    | `/api/devices/{id}`                       | Retorna um dispositivo pelo ID                   |
| POST   | `/api/sensorreadings`                     | Envia uma nova leitura de sensor                 |
| GET    | `/api/sensorreadings/device/{deviceId}`   | Lista todas as leituras de um dispositivo        |
| POST   | `/api/sensorreadings/lote`                | Envia várias leituras em lote (com API Key)      |

---

## 🧪 Exemplo de Requisição (Postman ou ESP32)

```http
POST /api/sensorreadings/lote
Authorization: ApiKey abc123secretapikeyxyz
Content-Type: application/json

{
  "deviceId": "f68fb3dd-65b9-47c3-b638-1bad36be5e37",
  "timestamp": "2025-05-07T19:00:00Z",
  "readings": [
    {
      "accelX": -0.004,
      "accelY": 0.002,
      "accelZ": 1.009,
      "ms": 123
    }
  ]
}
```

---

## ☁️ Publicação na Azure

Este projeto está hospedado como contêiner no Azure App Service, com imagens geradas no Azure Container Registry (ACR) e deploy automatizado via GitHub.
