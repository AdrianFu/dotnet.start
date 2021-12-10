# Intro

Create a web API with ASP.NET Core and MongoDB
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio

# Prelude

## In MongoSH

1. use BookStore
1. db.createCollection('Books')
1. db.Books.insertMany([{ "Name": "Design Patterns", "Price": 54.93, "Category": "Computers", "Author": "Ralph Johnson" }, { "Name": "Clean Code", "Price": 43.15, "Category": "Computers","Author": "Robert C. Martin" }])
1. db.Books.find().pretty()

## In command shell

1. dotnet new webapi -o BookStoreApi
1. dotnet add package MongoDB.Driver