# ProductsManager
A small application written in .Net Core 3.0 and Web API. Some of the mechanisms used in this application are overkill, but the purpose of writing this application is to be able to present own skills.

- Application has one controller: Products controller. This controller implements CRUD operations for Products management.
- In order to manage products, products controller uses ProductService.
- Data is stored in SqLite database with help of EntityFramework (Model first approach).
- DbContext and ProductService are injected via IOC mechanism.
- In order to map database models to DTO models, Automapper is being used.

TODO:
- validation mechanism with fluent validation
- ProductCreateModel and ProductUpdateModel classes for create/update scenarios
- Rename ProductController's actions accordingly to requirements.
