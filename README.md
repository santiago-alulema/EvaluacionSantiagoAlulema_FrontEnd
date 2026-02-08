# Frontend Blazor Server

Aplicación frontend desarrollada en **Blazor Server (.NET 8)** para la visualización y consumo de datos desde una API REST.

---

## Tecnologías utilizadas

- .NET 8
- Blazor Server
- ASP.NET Core
- Razor Components
- HttpClient

---

## Requisitos previos

- .NET SDK 8.0 o superior  
  https://dotnet.microsoft.com/download
- Visual Studio 2022 (con ASP.NET and web development)
- API Backend en ejecución

---

## Configuración

### appsettings.json

Antes de ejecutar el proyecto, configurar la URL base del backend en el archivo `appsettings.json`:

```json
{
  "ApiSettings": {
    "BaseUrl": "http://localhost:8092/api/",
    "Timeout": 30
  }
}
