# Lambda Expressions, Delegates, LINQ and Comparison in C#

#### This exercise is based on the <a href="https://www.udemy.com/course/programacao-orientada-a-objetos-csharp/?couponCode=MT260714G2">"C# COMPLETO Programação Orientada a Objetos + Projetos"</a> course.


#### This repository covers the concepts and use of Lambda Expressions, Delegates, LINQ and Comparison in C#.

### <ins>Using Comparison<'T'> </ins>

#### Suppose we have a `Product` class with the attributes `name` and `price`. Assume we need to sort a list of `Product` objects.

<img src="Imagens\Using ComparisonT - UML.png" alt="Using ComparisonT - UML">

#### We can implement product comparison by implementing the `IComparable<Product>` interface.

#### However this approach means that our `Product` class is not closed for modification: if the comparison criteria change, we will need to modify the `Product` class.

#### We can instead use another overload of the `Sort` method from the `List` class:

```CSharp
public void Sort(Comparison<T> comparison)
```

### <ins>Delegates</ins>

#### A reference (with type-safe) to one or more methods.
- Is a reference type.

#### Common use cases:
- Flexible and extensible communication between objects (events/callbacks).

#### Parameterizing operations with methods (functional programming).

#### Predefined Delegates:

- Action
- Func
- Predicate

### <ins>Multicast Delegates</ins>

- Delegates that hold references to more than one method.
- The `+=` operator can be used to add a method reference.
- Calling `Invoke` (or using the shorthand syntax) executes all methods in the order they were added.
- They are best suited for methods that return `void`.

### <ins>Predicate (System)</ins>

#### Represents a method that takes an object of type `T` and returns a boolean value.

```CSharp
public delegate bool Predicate<in T>(T obj);
```

### <ins>Predicate - Example Problem</ins>

#### Write a program that removes from a list of products only those whose minimum price is 100.

### <ins>Action (System)</ins>

#### Action (System)
 - Represents a void method that accepts zero or more arguments.

### <ins>Action - List.ForEach - Example Problem</ins>

#### Create a program that increases the price of each product in a list by 10%.

### <ins>Func (System)</ins>

#### Func (System)
- Represents a method that accepts zero or more arguments and returns a value

### <ins>Func with Select (LINQ) - Example Problem</ins>

#### Write a program that takes a list of products and generates a new list containing the product names in uppercase.

#### <strong>Note on the `Select` Method</strong>
- The `Select` method (part of LINQ) applies a function to every element in a collection, thereby generating a new collection of type `IEnumerable`.

#### Example:
```CSharp
List<int> numbers = new List<int> { 2, 3, 4 };
IEnumerable<int> newList = numbers.Select(x => 2 * x);
Console.WriteLine(string.Join(" ", newList));

Result: 4 6 8
```

### <ins>Func - Example Problem</ins>

#### Write a program that, given a list of products, calculates the sum of the prices of only those products whose names start with "T".

### <ins>LINQ - Language Integrated Query</ins>

#### LINQ

#### A set of technologies based on integrating query capabilities directly into the C# language.

- Operations invoked directly on collections.
- Queries are first-class objects.
- Compiler support and IDE IntelliSense.

#### Namespace: System.Linq

#### Provides several query operations, whose parameters are typically lambda expressions or SQL-like query syntax expressions.

#### You need to do three things to use LINQ collections:

- Create a data source (collection, array, I/O resource).
- Define the query.
- Execute the query (foreach or a terminal operation).