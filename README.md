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