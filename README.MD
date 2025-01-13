# Spreadex coding challenge

## Design

### Dependency Injection

I used Dependency Injection (DI) in this application to keep the code flexible and easy to change. By depending on abstractions like interfaces instead of specific widget classes, the main application doesn’t need to know the details of how each widget works. This makes it easy to add new widget types or update existing ones without changing the core logic, following principles like keeping the system open to new features but closed to major rewrites.
The Dependency Inversion Principle (the D in SOLID) says that high-level modules should not depend on low-level modules. Instead, both should depend on abstractions
DI also makes the code easier to test by allowing mock versions of widgets to be used in unit tests, so you can test the logic without relying on the real implementations. It helps organize the code better by managing dependencies in one place, making the structure clearer and easier to maintain.

### FluentValidation

I used the FluentValidation NuGet package to validate that widget details (such as dimensions) meet the requirement of being positive numbers. This decision ensures that validation logic is centralized, reusable, and easy to maintain. FluentValidation allows for clear rules to be defined for each widget making the code more readable.

By using FluentValidation, I separated validation from the core business logic, adhering to the Single Responsibility Principle. This makes the system easier to test and extend—if validation requirements change or new widgets are added, the changes can be made within the validators without affecting other parts of the application.

## Improvements

I think If I were to have more time. I would make improvements to the WidgetFactory to make it less tied to individual widget implementations and make more use of abstractions. For example, I could introduce a more generic creation mechanism that relies on a dictionary or registry of widget types and their corresponding validators, allowing the factory to dynamically resolve and create widgets based on input parameters. This would reduce the need for hardcoding each widget type in the factory and make it easier to add new widget types without modifying the factory class. Additionally, I could explore using a configuration-based approach or a more robust dependency injection strategy to further decouple widget creation from specific implementations, improving scalability and maintainability.
