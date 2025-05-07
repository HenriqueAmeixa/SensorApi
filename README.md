# SensorAPI 📡

API REST em ASP.NET Core 8 para coleta e registro de dados de sensores embarcados (ex: ESP32), como aceleração e temperatura.

---

## 📖 Visão Geral

Esta API permite registrar leituras de sensores de dispositivos conectados, armazenar em banco de dados SQL Server na Azure e expor endpoints REST para integração.

---

## ⚙️ Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- SQL Server (Azure)
- Swagger (Swashbuckle)
- Docker
- Azure App Service + ACR

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

## 🐳 Rodar com Docker
docker build -t sensorapi .
docker run -d -p 80:80 sensorapi

## 🔌 Endpoints
| Método | Rota                                    | Descrição                                 |
| ------ | --------------------------------------- | ----------------------------------------- |
| POST   | `/api/devices`                          | Cadastra um novo dispositivo              |
| GET    | `/api/devices`                          | Lista todos os dispositivos               |
| GET    | `/api/devices/{id}`                     | Retorna um dispositivo pelo ID            |
| POST   | `/api/sensorreadings`                   | Envia uma nova leitura de sensor          |
| GET    | `/api/sensorreadings/device/{deviceId}` | Lista todas as leituras de um dispositivo |

## 🧪 Exemplo de Requisição (Postman)
```bash
POST /api/sensorreadings
{
  "deviceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "accelX": 0.12,
  "accelY": 0.01,
  "accelZ": 9.81,
  "temperature": 28.3,
  "timestamp": "2025-05-06T20:00:00Z"
}
```

## ☁️ Publicação na Azure
Este projeto está hospedado como contêiner no Azure App Service, com imagens geradas no Azure Container Registry (ACR) e deploy automatizado via GitHub.


