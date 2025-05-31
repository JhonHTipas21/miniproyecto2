# 💰 MiniProyecto II - Gestor de Gastos Personales

*MiniProyecto II* es una aplicación web desarrollada en *C# con el patrón MVC de .NET, diseñada para ayudar a los usuarios a gestionar sus **gastos mensuales de manera eficiente*.

> Esta aplicación permite registrar, editar, visualizar y eliminar gastos categorizados, utilizando una base de datos SQL integrada con Entity Framework (ORM).

---

## 🧠 Funcionalidades principales

✅ Registro y visualización de *gastos mensuales*  
✅ Gestión de *categorías* como alimentación, salud, transporte, etc.  
✅ *Edición y eliminación* de gastos  
✅ *Autenticación de usuarios* con control de acceso (opcional)  
✅ *Gráficas y estadísticas* (en construcción)

---

## 🛠️ Tecnologías utilizadas

| Tecnología       | Descripción                          |
|------------------|--------------------------------------|
| C#               | Lenguaje de programación principal   |
| ASP.NET MVC      | Framework web con patrón MVC         |
| Entity Framework | ORM para acceso a base de datos SQL |
| SQL Server       | Base de datos relacional             |
| Bootstrap        | Framework CSS para UI responsiva     |
| Razor            | Motor de plantillas para vistas      |

---

## 📂 Estructura del Proyecto


📦 miniproyecto2
 ┣ 📁 Controllers
 ┃ ┗ 📄 GastoController.cs
 ┣ 📁 Models
 ┃ ┗ 📄 Gasto.cs
 ┣ 📁 Views
 ┃ ┗ 📁 Gasto
 ┃   ┣ 📄 Index.cshtml
 ┃   ┣ 📄 Create.cshtml
 ┃   ┣ 📄 Edit.cshtml
 ┣ 📄 _Layout.cshtml
 ┣ 📄 Startup.cs / Program.cs


---

## 📸 Vista previa (UI)

![Interfaz principal](../afb33c50-02c6-4301-ba0b-9e217f8855c1.png)

Pantalla principal donde se visualizan los gastos registrados con sus respectivas categorías.

---

## 🧪 Pruebas y calidad

Este proyecto incluye un script de pruebas automatizadas con Selenium:

bash
✔ Crear gasto con categoría
✔ Validación de formulario sin categoría
✔ Mostrar categorías en listado


Además, se ha probado manualmente cada componente utilizando un plan de pruebas documentado en Excel.

---

## 🚀 ¿Cómo ejecutar el proyecto?

1. Clona el repositorio:
bash
git clone https://github.com/JhonHTipas21/miniproyecto2.git

2. Abre el proyecto en *Visual Studio*
3. Restaura los paquetes NuGet
4. Ejecuta la base de datos con migraciones:
bash
Update-Database

5. Presiona *F5* y empieza a usar el gestor 💸

---

## ✨ Autores

- 👨‍💻 *Jhon H. Tipas*  
- 👨‍💻 [Tu nombre y equipo si aplica]

---

## 📄 Licencia

Este proyecto es académico y de libre distribución con fines educativos.

---

¡Gracias por revisar este proyecto! ⭐ Si te gustó, no olvides dejar una estrellita en el repo 😉
