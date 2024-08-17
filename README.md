# Proyecto de Lista de Tareas 📓

[![image.png](https://i.postimg.cc/LXkPpTtn/image.png)](https://postimg.cc/zbBvwTPr)

Este proyecto es una aplicación de consola escrita en C# .NET Framework 4.8 que permite a los usuarios gestionar una lista de tareas. Los usuarios pueden agregar, mostrar, completar y eliminar tareas.

## Requisitos

- [Visual Studio](https://visualstudio.microsoft.com/) 2019 o posterior con soporte para .NET Framework. 
- .NET Framework 4.8.

## Instrucciones para Compilar y Ejecutar

1. **Clona el repositorio en tu máquina local:**
   git clone https://github.com/AlejoB0T/To-Do_List.git
   cd To-Do_List

2. **Abre el proyecto con Visual Studio:**
   - Abre Visual Studio
   - Selecciona File (archivo) -> Open (abrir) -> Project or Solution (Proyecto o solución)
   - Navega a donde clonaste el repositorio o descargarte (En caso que hayas descargado en .zip y luego extraido)
   - Selecciona el archivo To-Do_List.sln

3. **Compila el proyecto:**
   - Ya en Visual Studio, ve a Build(Compilar) -> Build Solution(Compilar solución)

4. **Ejecuta la aplicación:**
   - Ve a Debug (Depurar) -> Start without debugging(Iniciar sin depurar) o solo presiona la tecla "F5"

## Tecnologías Utilizadas

- C# .NET Framework 4.8
- Visual Studio 2022

## Caracteristicas

**Agregar Tarea:**
 - Permite al usuario agregar todas sus tareas a la lista
 - Especifica titulo, descripción y fecha limite (solo si asi lo desea)
 - La fecha limite en caso de querer ponerla debe estar en formaro DD-MM-YYYY

**Mostarar Tareas:**
- Muestra todas las tareas en la lista
- La tarea se muestra con su índice, título, descripción, fecha límite (en caso de tenerla) y si esta pendiente o completada

**Completar Tareas:**
- Permite marcar como completada la tarea que el usuario desee por medio del índice

**Eliminar Tarea:**
- Permite eliminar la tarea que el usuario desee por medio del índice

**Manejo de Errores:**
Por medio de Try Catch;
- Implementa manejo de excepciones para entradas inválidas, como introducir texto en lugar de números
- Valida que los números de tarea seleccionados sean válidos y estén dentro del rango de la lista de tareas

**Interfaz de usuario tipo menú:**
- Menú simple para que el usuario seleccione y haga las diferentes acciones

## Autores
- **Alejandro Ruiz Benítez** - *Desarrollador principal* - [GitHub](https://github.com/AlejoB0T)
