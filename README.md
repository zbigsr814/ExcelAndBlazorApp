NOTES

For the application to work, it is necessary to create a local database. To do this, go to the Tools tab in VisualStudio and select Nuget Package Console. In the console, type "update-database". The local database will be created. Then we can start the project normally.

DESCRIPTION

The application is used to manage the company's budget. The application contains tabs: employees, orders, contracts and summary. 
- For employees, we can add employees, add his working time, calculate employee costs. 
- For orders, we create order lists, and in them the products purchased with gross and net price. 
- For contracts, we set the start and scheduled completion time of the project, net and gross revenue of the project
- For the summary, the application automatically calculates the company's profits and losses. The data is grouped for each month.
- We can download the summary in xlsx Excel format. Excel tables contain the calculated summary data and a graph with a presentation of the profit and loss balance.

TECHNOLOGIES USED

The application collects data in a database. The tables are linked. LINQ and SQL scripts were used to search the database and modify it. The Summary table and Excel file are automatically generated based on the data entered. EPPlus package was used to create the Excel file.

- For client logic, Blazor WASM was used, including adding and deleting records to a table.
- The server logic is based on the REST API. It's mainly controllers that issue endpoints depending on the action. 

TECHNOLOGIES

- Blazor WASM
- REST API server
- Entity Framework + LINQ
- MS SQL + SQL scripts
- EPPlus package, for Excel development
- HTML, CSS, Bootstrap