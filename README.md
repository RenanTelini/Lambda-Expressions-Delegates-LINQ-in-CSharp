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

### <ins>LINQ with Lambda, a syntax similar to SQL</ins>

#### When you use LINQ with Lambda expressions, you noticed that they has a syntax similar to SQL, and one can be substituted for the other.

#### Example:

#### LINQ with Lambda expression:

```CSharp
var r2 = 
    products.Where(p => p.Category.Name == "Tools")
    .Select(p => p.Name);

var r3 = products.Where(p => p.Name[0] == 'C')
    .Select(
    p => new 
        { 
            p.Name, 
            p.Price, 
            CategoryName = p.Category.Name 
        }
    );
```

#### Syntax similar to SQL:
```CSharp
var r2 =
    from p in products
    where p.Category.Name == "Tools"
    select p;

var r3 =
    from p in products
    where p.Name[0] == 'C'
    select new
    {
        p.Name,
        p.Price,
        CategoryName = p.Category.Name
    };
```

### <ins>LINQ - Example Problem</ins>

#### Write a program to read a set of products from a .csv file (assume that there is at least one product). Then, display the average price of the products. Finally, display the names of the products whose prices are below the average, in descending order.

#### Example:

#### <strong>Input file:</strong>

Tv,900.00<br>
Mouse,50.00<br>
Tablet,350.50<br>
HD Case,80.90<br>
Computer,850.00<br>
Monitor,290.00

#### <strong>Execution:</strong>

Enter full file path: c:\temp\in.txt<br>
Average price: 420.23<br>
Tablet<br>
Mouse<br>
Monitor<br>
HD Case

### <ins>LINQ - Programming Challenge</ins>

#### Write a program to read employee data (name, email, and salary) from a .csv file.

#### Then, display the email addresses of employees whose salaries are higher than a given amount provided by the user, sorted in alphabetical order.

#### Also, display the total salaries of employees whose names start with the letter 'M'.

#### LINQProgrammingChallenge - UML:

<img src="Imagens\LINQProgrammingChallenge - UML.png"  alt="LINQProgrammingChallenge - UML">

#### Example:

#### <strong>Input file:</strong>
Maria,maria@gmail.com,3200.00<br>
Alex,alex@gmail.com,1900.00<br>
Marco,marco@gmail.com,1700.00<br>
Bob,bob@gmail.com,3500.00<br>
Anna,anna@gmail.com,2800.00<br>

#### <strong>Execution:</strong>
Enter full file path: <strong>c:\temp\in.csv</strong><br>
Enter salary: <strong>2000.00</strong><br>
Email of people whose salary is more than 2000.00:<br>
anna@gmail.com<br>
bob@gmail.com<br>
maria@gmail.com<br>
Sum of salary of people whose name starts with 'M': 4900.00<br>