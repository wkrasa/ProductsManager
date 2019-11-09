# ProductsManager
A small application written in .Net Core 3.0 and Web API with  Visual Studio 2019. Some of the mechanisms used in this application are overkill, but the purpose of writing this application is to be able to present own skills.

- Application has one controller: Products controller. This controller implements CRUD operations for Products management.
- In order to manage products, products controller uses ProductService.
- Data is stored in SqLite database (Data.db file) with help of EntityFramework (Model first approach).
- DbContext and ProductService are injected via IOC mechanism.
- In order to map database models to DTO models, Automapper is being used.
- ProductCreateModel and ProductUpdateModel classes for create/update scenarios are being used
- In order to validate product creation/update fluent validation is being used.

NOTES:
- Default/start application address is 'Products/'. 
- On the application start, when there is no database file, new file is created with several examlpe products.
- ProductController's actions are named according to the instructions, but are accessible under following addresses
	List=> Products[GET]
	GetProductById=> Products/{Id}[GET]
	AddProduct=> Products[POST]
	UpdateProduct=> Products[PUT]
	RemoveProduct=> Products/{Id}[DELETE]
	
