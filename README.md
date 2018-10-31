# Examen3. EntityFramework.

He creado las carpetas:

## Context
Con la clase de contexto PizzasIngredientsContext.

## Domine
Con las clases del dominio: Pizza, Ingredients y PizzaIngredients.
Con las interfaces IRepository (interfaz genérica) y las interfaces específicas IIngredientsRepository e IPizzasRepository.

## ExtraClasses
Con la clase que implementa un método para validar que la cantidad de un ingrediente ha de ser mayor que uno.

## Infrastructure
Se implementan las interfaces del dominio, IngredientsRepository y PizzasRepository.

## Migrations
Se crean las clases de migración para la actualización de la base de datos.

## App.config

En este archivo he añadido los valores:
  - Profit que es el beneficio que la pizzeria quiere tener, con valor 1,20.
  - CapacityOfView que es la capacidad de la vista que tenemos para enlistar las pizzas cuando queremos recuperarlas.
