# UntitledBankApp

This project was built using the design pattern Model-View-Presenter (MVP). The decision to use MVP was made in order to make it easier for team members to work in parallel due to the abstraction that this design pattern provides. 
The abstraction seen in MVP, and similar design patterns, promotes the design principle Separation of concerns.

![OOAD](https://raw.githubusercontent.com/ByteBears-NET23/UntitledBankApp/1e36628edee2787c5a23d12205c4eceb7fd785e3/.github/images/MVP.drawio.png)

## A simple demonstration of the design philosophy

Please consider the following example:
```
public static void PrintString(string value)
{
   Console.WriteLine(value);
}
```

This method has one purpose: To print a string sent to it as an argument. The method doesn't know how the string was created, it is not a concern for the method. It does however know what to do with it. This method in and of itself also demonstrates a design principle called Single Responsibility Principle. Even though there is only one instruction inside the methods code block, the principle of Single Responsibility allows for an infinite amount of instructions, as long as they are in line with the purpose of the method.

The before mentioned design principles are applied upon the entire project. The abstraction comes from that a component *does something* and not how it *does something*, in relation to other components in the project.

## M - Models 

A model represents a typical object: A template. Examples of models seen in UntitledBankApp can be found in the UML class diagram below.

![UML](https://raw.githubusercontent.com/ByteBears-NET23/UntitledBankApp/1e36628edee2787c5a23d12205c4eceb7fd785e3/.github/images/UntitledBankApp.drawio.png)

## V - View

A view represents an object that the user interacts with, either directly through input, or indirectly through output.

## P - Presenter
A presenter can be described as a middleman. The presenter coordinates methods from different objects in terms of "when" and "what" something will be performed. The "How" something is performed is left up to the individual components it calls upon.

## Services
A service represents the link between a presenter and PseudoDb (read more about it below). The services in UntitledBankApp uses "CRUD" - Create, Remove, Update and Delete to manipulate the generic collections found in PseudoDb.

## PseudoDb
PseudoDb is **not** a database. It is an object consisting of generic collections. These generic collections contain data concerning the entire application.

The name "PseudoDb" comes from the fact that it serves the same purpose one would expect from a typical database. It contains "tables" in the form of generic collections where the object's properties acts as the table's "columns". Each object within the collection represents a "row" within the table.

## Other design patterns seen in UntitledBankApp

### Dependency injection
Objects that rely upon the usage of other objects use constructor dependency injection to clearly convey their dependencies.

### Factory Method
In the case where a User object must be created, the project makes use of the Factory Method Design Pattern. This is done to further promote separation of concerns.
