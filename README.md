# Dev Tools and Environment
This solution is built in .Net 8 using JetBrains Rider and Visual Studio.
It uses in Memory database (EF Core)

# Running the solution
- Simply clone the repository, build, and Run the API.
- Operations should be presented via Swagger.
- There are customers with ID 1 to 10 preloaded into In-Memory DB to ease up the API Tests.

# Assumptions
- The solution acts on the assumption that customers exist, therefore it preloads data and validates it accordingly
- All the IDs are DB-generated

# Extra mile
- Using Fluent Assertion
- Using Fluent Validation
- EFCore In-Memory database
- Separation of concerns using MediatR and CQRS

# Potential improvements
Where time wasn't a limit
- Providing EF Core, Code first with propoer relationships and configurations.
- Using FakeDbContext for behaviour tests instead of relying on the In-Memory database data.
- Providing Level 3 Maturity on the Rest APIs following HATEOAS standards and documentations.
- Proper logging of each individual operations where necessary.

# Code coverage on Local
![img](https://github.com/benizadi/FunBooksAndVideos/assets/12119278/a8f99960-4fbd-4fa1-8298-2f539ccf8b29)

# Api Responses
![image](https://github.com/benizadi/FunBooksAndVideos/assets/12119278/1916e929-c710-4784-aff4-3a6499514d16)

![image](https://github.com/benizadi/FunBooksAndVideos/assets/12119278/a6d70557-061b-4544-b532-955a42bf0e55)

![image](https://github.com/benizadi/FunBooksAndVideos/assets/12119278/b0823dad-de56-4265-97e9-726a62f27252)
