# Entity Framework Core

Entity Framework Core (EF Core) is a lightweight, extensible, open-source, and cross-platform version of the popular Entity Framework data access technology. Here are some key aspects and features of EF Core:

### Key Features

1. **Cross-Platform**: EF Core supports multiple platforms, including .NET Core, .NET Framework, Xamarin, and more.
2. **Code-First Approach**: Allows developers to define their database schema using C# classes. This approach makes it easy to create and maintain databases using migrations.
3. **Database-First Approach**: Supports scaffolding a model from an existing database, enabling reverse engineering of database schemas.

4. **Querying**: Utilizes LINQ (Language Integrated Query) to query the database using strongly-typed C# code.

5. **Change Tracking**: Keeps track of changes made to entities so that they can be persisted to the database.

6. **Concurrency Handling**: Built-in support for optimistic concurrency to handle conflicts when multiple users are editing the same data.

7. **Eager, Lazy, and Explicit Loading**: Provides flexibility in loading related data as per the requirements to optimize performance and memory usage.

8. **Migration**: Helps manage schema changes over time with migrations that can be applied to the database.

9. **Support for Multiple Databases**: Works with various relational databases, including SQL Server, SQLite, PostgreSQL, MySQL, and more, with providers available for different databases.

### Getting Started

Here’s a brief guide to get started with EF Core:

#### Installation

First, you need to install EF Core packages via NuGet. For example, to use EF Core with a SQL Server database, you can use the following command:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

#### Defining a Model

You define the data model using C# classes. For instance, if you are modeling a blogging context, you might have the following classes:

```csharp
public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public List<Post> Posts { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
```

#### Creating a DbContext

The `DbContext` class is the primary class responsible for interacting with the database. Here’s how you can define a `DbContext` for the blogging model:

```csharp
public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;");
    }
}
```

#### Applying Migrations

After defining the model and context, you can create and apply migrations to set up the database schema. Use the following commands in the Package Manager Console or the terminal:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Querying Data

You can use LINQ to query the database. Here’s an example of querying for blogs and their related posts:

```csharp
using (var context = new BloggingContext())
{
    var blogs = context.Blogs
        .Include(b => b.Posts)
        .ToList();
}
```

### Conclusion

EF Core is a powerful ORM that simplifies data access and manipulation in .NET applications. Whether you prefer code-first or database-first workflows, EF Core provides the tools necessary to work with relational data in an object-oriented way. Its support for multiple database providers and advanced features like LINQ querying, change tracking, and migrations make it a versatile choice for many projects.
