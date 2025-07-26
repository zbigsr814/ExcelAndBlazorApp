using ExcelAndBlazorApp.Entities;
using System.Diagnostics.Contracts;
using Contract = ExcelAndBlazorApp.Entities.Contract;

namespace ExcelAndBlazorApp.Services
{
    public class CompanySeeder
    {
        private readonly CompanyDbContext _dbContext;
        public CompanySeeder(CompanyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            // Contracts
            if (!_dbContext.contracts.Any())
            {
                var contracts = GetContracts();
                _dbContext.contracts.AddRange(contracts);
                _dbContext.SaveChanges();
            }

            // Employees
            if (!_dbContext.employees.Any())
            {
                var employees = GetEmployees();
                _dbContext.employees.AddRange(employees);
                _dbContext.SaveChanges();
            }

            // Orders
            if (!_dbContext.orders.Any())
            {
                var orders = GetOrders();
                _dbContext.orders.AddRange(orders);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.orderItems.Any())
            {
                var items = GetOrderItems();
                _dbContext.orderItems.AddRange(items);
                _dbContext.SaveChanges();
            }

            // WorkLogs
            if (!_dbContext.workLogs.Any())
            {
                var workLogs = GetWorkLogs();
                _dbContext.workLogs.AddRange(workLogs);
                _dbContext.SaveChanges();
            }

        }

        private IEnumerable<Contract> GetContracts()
        {
            List<Contract> contracts = new List<Contract>()
            {
                new Contract { ClientName = "Tech Solutions Ltd.", RevenueGross = 120000, StartDate = new DateTime(2023, 3, 1), EndDate = new DateTime(2026, 3, 1) },
                new Contract { ClientName = "Green Energy Corp.", RevenueGross = 150000, StartDate = new DateTime(2023, 5, 15), EndDate = new DateTime(2026, 5, 15) },
                new Contract { ClientName = "Innovative Designs", RevenueGross = 95000, StartDate = new DateTime(2023, 7, 20), EndDate = new DateTime(2026, 7, 20) },
                new Contract { ClientName = "Global Logistics", RevenueGross = 200000, StartDate = new DateTime(2023, 9, 5), EndDate = new DateTime(2026, 9, 5) },
                new Contract { ClientName = "SmartTech Enterprises", RevenueGross = 180000, StartDate = new DateTime(2023, 11, 10), EndDate = new DateTime(2026, 11, 10) },
                new Contract { ClientName = "Urban Developers", RevenueGross = 130000, StartDate = new DateTime(2024, 1, 12), EndDate = new DateTime(2027, 1, 12) },
                new Contract { ClientName = "Aqua Solutions", RevenueGross = 110000, StartDate = new DateTime(2024, 2, 25), EndDate = new DateTime(2027, 2, 25) },
                new Contract { ClientName = "NextGen Electronics", RevenueGross = 160000, StartDate = new DateTime(2024, 4, 8), EndDate = new DateTime(2027, 4, 8) },
                new Contract { ClientName = "Prime Construction", RevenueGross = 140000, StartDate = new DateTime(2024, 6, 18), EndDate = new DateTime(2027, 6, 18) },
                new Contract { ClientName = "Eco Innovations", RevenueGross = 125000, StartDate = new DateTime(2024, 8, 2), EndDate = new DateTime(2027, 8, 2) },
                new Contract { ClientName = "Digital Marketing Hub", RevenueGross = 105000, StartDate = new DateTime(2024, 10, 20), EndDate = new DateTime(2027, 10, 20) },
                new Contract { ClientName = "SolarTech Systems", RevenueGross = 170000, StartDate = new DateTime(2025, 1, 5), EndDate = new DateTime(2028, 1, 5) },
                new Contract { ClientName = "LogiTech Solutions", RevenueGross = 190000, StartDate = new DateTime(2025, 3, 22), EndDate = new DateTime(2028, 3, 22) },
                new Contract { ClientName = "Creative Studios", RevenueGross = 115000, StartDate = new DateTime(2025, 6, 12), EndDate = new DateTime(2028, 6, 12) },
                new Contract { ClientName = "Global Ventures", RevenueGross = 155000, StartDate = new DateTime(2025, 9, 28), EndDate = new DateTime(2028, 9, 28) }
            };

            return contracts;
        }

        private IEnumerable<Employee> GetEmployees()
        {
            // Pracownicy - 7 osób
            var employees = new List<Employee>
            {
                new Employee { Name = "Anna Kowalska", PESEL = "85012345678", Position = "Technik", HourlyRateGross = 50m },
                new Employee { Name = "Marek Nowak", PESEL = "79045612345", Position = "Inżynier", HourlyRateGross = 65m },
                new Employee { Name = "Katarzyna Wiśniewska", PESEL = "88098765432", Position = "Kierownik", HourlyRateGross = 80m },
                new Employee { Name = "Paweł Zieliński", PESEL = "90032145678", Position = "Specjalista", HourlyRateGross = 55m },
                new Employee { Name = "Ewa Szymańska", PESEL = "87065432109", Position = "Technik", HourlyRateGross = 52m },
                new Employee { Name = "Tomasz Lewandowski", PESEL = "86012378945", Position = "Inżynier", HourlyRateGross = 68m },
                new Employee { Name = "Magdalena Kaczmarek", PESEL = "89078912345", Position = "Specjalista", HourlyRateGross = 60m }
            };
            return employees;
        }

        private IEnumerable<Order> GetOrders()
        {
            // Zamówienia - 10 sztuk
            var orders = new List<Order>
            {
                new Order { OrderNumber = "ORD001", Date = new DateTime(2023, 1, 12), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD002", Date = new DateTime(2023, 3, 22), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD003", Date = new DateTime(2023, 5, 5), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD004", Date = new DateTime(2023, 7, 18), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD005", Date = new DateTime(2023, 9, 10), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD006", Date = new DateTime(2023, 11, 25), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD007", Date = new DateTime(2024, 2, 8), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD008", Date = new DateTime(2024, 4, 15), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD009", Date = new DateTime(2024, 6, 30), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD010", Date = new DateTime(2024, 8, 19), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD011", Date = new DateTime(2024, 10, 5), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD012", Date = new DateTime(2024, 12, 12), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD013", Date = new DateTime(2025, 1, 7), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD014", Date = new DateTime(2025, 3, 16), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD015", Date = new DateTime(2025, 5, 21), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD016", Date = new DateTime(2025, 7, 2), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD017", Date = new DateTime(2025, 9, 11), Items = new List<OrderItem>() },
                new Order { OrderNumber = "ORD018", Date = new DateTime(2025, 11, 23), Items = new List<OrderItem>() }
            };
            return orders;
        }

        private IEnumerable<OrderItem> GetOrderItems()
        {
            var orderItems = new List<OrderItem>
            {
                new OrderItem { OrderId = 1, ItemName = "Laptop", PriceGross = 5500m, Quantity = 2 },
                new OrderItem { OrderId = 1, ItemName = "Monitor", PriceGross = 1500m, Quantity = 1 },
                new OrderItem { OrderId = 2, ItemName = "Smartphone", PriceGross = 2500m, Quantity = 3 },
                new OrderItem { OrderId = 2, ItemName = "Tablet", PriceGross = 1200m, Quantity = 2 },
                new OrderItem { OrderId = 3, ItemName = "Printer", PriceGross = 900m, Quantity = 1 },
                new OrderItem { OrderId = 3, ItemName = "Scanner", PriceGross = 700m, Quantity = 1 },
                new OrderItem { OrderId = 3, ItemName = "Keyboard", PriceGross = 200m, Quantity = 5 },
                new OrderItem { OrderId = 4, ItemName = "Mouse", PriceGross = 150m, Quantity = 5 },
                new OrderItem { OrderId = 4, ItemName = "Webcam", PriceGross = 350m, Quantity = 2 },
                new OrderItem { OrderId = 5, ItemName = "Microphone", PriceGross = 400m, Quantity = 2 },
                new OrderItem { OrderId = 5, ItemName = "Docking Station", PriceGross = 1000m, Quantity = 1 },
                new OrderItem { OrderId = 6, ItemName = "External Hard Drive", PriceGross = 600m, Quantity = 2 },
                new OrderItem { OrderId = 6, ItemName = "USB Hub", PriceGross = 100m, Quantity = 10 },
                new OrderItem { OrderId = 6, ItemName = "Cable Organizer", PriceGross = 50m, Quantity = 10 },
                new OrderItem { OrderId = 7, ItemName = "Surge Protector", PriceGross = 150m, Quantity = 3 },
                new OrderItem { OrderId = 7, ItemName = "Graphics Tablet", PriceGross = 800m, Quantity = 1 },
                new OrderItem { OrderId = 8, ItemName = "Desk Lamp", PriceGross = 200m, Quantity = 4 },
                new OrderItem { OrderId = 8, ItemName = "Office Chair", PriceGross = 1200m, Quantity = 1 },
                new OrderItem { OrderId = 9, ItemName = "Projector", PriceGross = 1800m, Quantity = 1 },
                new OrderItem { OrderId = 9, ItemName = "Whiteboard", PriceGross = 600m, Quantity = 1 },
                new OrderItem { OrderId = 10, ItemName = "Conference Phone", PriceGross = 500m, Quantity = 1 },
                new OrderItem { OrderId = 10, ItemName = "Router", PriceGross = 700m, Quantity = 1 },
                new OrderItem { OrderId = 10, ItemName = "Switch", PriceGross = 900m, Quantity = 1 }
            };
            return orderItems;
        }

        private IEnumerable<WorkLog> GetWorkLogs()
        {
            var workLogs = new List<WorkLog>
            {
                new WorkLog { EmployeeId = 1, Date = new DateTime(2023, 5, 15), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2023, 6, 3), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2023, 9, 10), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2023, 10, 5), HoursWorked = 7.0m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2023, 12, 12), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2024, 1, 8), HoursWorked = 6.0m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2024, 3, 22), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2024, 5, 30), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2025, 2, 14), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 1, Date = new DateTime(2025, 4, 10), HoursWorked = 7.0m },

                new WorkLog { EmployeeId = 2, Date = new DateTime(2023, 5, 20), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2023, 7, 18), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2023, 9, 25), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2023, 11, 7), HoursWorked = 7.0m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2024, 1, 5), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2024, 3, 1), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2024, 6, 12), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2025, 1, 19), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2025, 3, 8), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 2, Date = new DateTime(2025, 5, 25), HoursWorked = 7.0m },

                new WorkLog { EmployeeId = 3, Date = new DateTime(2023, 6, 11), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2023, 8, 2), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2023, 10, 14), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2023, 12, 6), HoursWorked = 7.0m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2024, 2, 20), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2024, 4, 17), HoursWorked = 6.0m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2024, 7, 23), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2025, 1, 15), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2025, 3, 30), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 3, Date = new DateTime(2025, 6, 4), HoursWorked = 7.0m },

                new WorkLog { EmployeeId = 4, Date = new DateTime(2023, 7, 9), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2023, 9, 4), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2023, 11, 16), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2023, 12, 28), HoursWorked = 7.0m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2024, 3, 5), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2024, 5, 1), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2024, 8, 8), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2025, 2, 10), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2025, 4, 22), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 4, Date = new DateTime(2025, 7, 1), HoursWorked = 7.0m },

                new WorkLog { EmployeeId = 5, Date = new DateTime(2023, 5, 25), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2023, 7, 12), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2023, 9, 18), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2023, 11, 3), HoursWorked = 7.0m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2024, 1, 22), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2024, 4, 9), HoursWorked = 6.0m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2024, 6, 26), HoursWorked = 7.5m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2025, 1, 5), HoursWorked = 8.0m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2025, 3, 20), HoursWorked = 6.5m },
                new WorkLog { EmployeeId = 5, Date = new DateTime(2025, 5, 28), HoursWorked = 7.0m }

            };
            return workLogs;
        }
    }
}
