### Example of the Builder Design Pattern (Fluent Builder Inheritance With Recursive Generics)

This example of the functional builder design pattern was develop using C#.

When using the Fluent Builder technique, sometimes we need to add a new field to a class or a new behavior, and when following the SOLID Open-Closed principle, we should change the original builder class. The answer to this would immediately be Inheritance.

The only problem is that, when using Fluent Builder, the method will always return its own instance, meaning that the minute you call a method in the first builder, you lose access to the method in the second, because it’ll be always return the original instance, not the inherited one.

To make this work we need to use Recursive Generics, meaning the original builder method will always return an instance that inherits the more recent class, and each class in the chain inherits from the class that came before it, always using generics to maintain access to all methods.

On the method Create(), we’ll return the first interface (on which all the other depends on). This forces the program into calling the next logical method, which will return an implementation of the next interface and so on, eventually coming to the method Build(), returning the main object.

If you're interested in the udemy course by [Dmitri Nesteruk](https://www.udemy.com/user/dmitrinesteruk/) [link](https://www.udemy.com/course/design-patterns-csharp-dotnet).
