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

1. Clone o repositório:

```bash
git clone https://github.com/HenriqueAmeixa/SensorApi.git
cd SensorApi

2.Configure o appsettings.json com sua connection string.

3.Rode o projeto:
  dotnet run


| Método | Rota                                    | Descrição                        |
| ------ | --------------------------------------- | -------------------------------- |
| POST   | `/api/devices`                          | novo dispositivo                 |
| GET    | `/api/devices`                          | Lista dispositivos               |
| GET    | `/api/devices/{id}`                     | Consulta um dispositivo por ID   |
| POST   | `/api/sensorreadings`                   | Envia uma leitura de sensor      |
| GET    | `/api/sensorreadings/device/{deviceId}` | Lista leituras de um dispositivo |


POST /api/sensorreadings
{
  "deviceId": "GUID",
  "accelX": 0.12,
  "accelY": 0.01,
  "accelZ": 9.81,
  "temperature":28.3,
  "timestamp": "2025-05-06T20:00:00Z"
}

