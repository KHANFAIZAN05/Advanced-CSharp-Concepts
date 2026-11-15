using Inheritence;

Employee fullTimeEmployee = new FullTimeEmployee(1, "John Doe", 5000m, 1000m);
Console.WriteLine(fullTimeEmployee.GetPaySlipSummary());   // Output: Employee Type: Full-Time Employee, Employee ID: 1, Name: John Doe, Monthly Pay: $5,083.33


Employee partTimeEmployee = new ContractEmployee(2, "Jane Smith", 2000m, 50m, 160);
Console.WriteLine(partTimeEmployee.GetPaySlipSummary());  // Output: Employee Type: Contract Employee, Employee ID: 2, Name: Jane Smith, Monthly Pay: $8,000.00


Employee executiveEmployee = new ExecutiveEmployee(3, "Alice Johnson", 10000m, 2000m);
Console.WriteLine(executiveEmployee.GetPaySlipSummary());  // Output: Employee Type: Executive Employee, Employee ID: 3, Name: Alice Johnson, Monthly Pay: $12,000.00
