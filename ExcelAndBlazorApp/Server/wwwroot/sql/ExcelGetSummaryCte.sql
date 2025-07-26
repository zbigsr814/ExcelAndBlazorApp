WITH MonthlyOrdersGross AS (
	SELECT 
		DATEFROMPARTS(YEAR(o.Date), MONTH(o.Date), 1) AS YearMonth, 
		SUM(oi.PriceGross * oi.Quantity) AS MonthlyOrdersExpenses
	FROM orders o
	INNER JOIN orderItems oi ON o.Id = oi.OrderId
	GROUP BY YEAR(o.Date), MONTH(o.Date)
),
MonthlyEmployeesGross AS (
	SELECT 
		DATEFROMPARTS(YEAR(wl.Date), MONTH(wl.Date), 1) AS YearMonth, 
		SUM(e.HourlyRateGross * wl.HoursWorked) AS MonthlySalarysExpenses 
	FROM employees e
	INNER JOIN workLogs wl ON e.Id = wl.EmployeeId
	GROUP BY YEAR(wl.Date), MONTH(wl.Date)
),
MonthlyContractsGross AS (
	SELECT
		DATEFROMPARTS(YEAR(c.StartDate), MONTH(c.StartDate), 1) AS YearMonth,
		SUM(c.RevenueGross) AS MonthlyIncomes
	FROM contracts c
	GROUP BY YEAR(c.StartDate), MONTH(c.StartDate)
)
SELECT 
	FORMAT(COALESCE(me.YearMonth, mo.YearMonth, mc.YearMonth), 'MM-yyyy') AS 'YearMonth',
	CAST(ISNULL(me.MonthlySalarysExpenses, 0) AS decimal(18, 2)) AS 'EmployeesExpenses',
	CAST(ISNULL(mo.MonthlyOrdersExpenses, 0) AS decimal(18, 2)) AS 'OrdersExpenses',
	CAST(ISNULL(mc.MonthlyIncomes, 0) AS decimal(18, 2)) AS 'CompanyIncomes',
	CAST((ISNULL(mc.MonthlyIncomes, 0) - ISNULL(me.MonthlySalarysExpenses, 0) - ISNULL(mo.MonthlyOrdersExpenses, 0)) AS decimal(18, 2)) AS 'ProfitBrutto',
	CAST(((ISNULL(mc.MonthlyIncomes, 0) - ISNULL(me.MonthlySalarysExpenses, 0) - ISNULL(mo.MonthlyOrdersExpenses, 0)) / 1.23) AS decimal(18, 2)) AS 'ProfitNetto'

FROM MonthlyEmployeesGross me
FULL JOIN MonthlyOrdersGross mo ON me.YearMonth = mo.YearMonth
FULL JOIN MonthlyContractsGross mc ON me.YearMonth = mc.YearMonth
ORDER BY YearMonth;