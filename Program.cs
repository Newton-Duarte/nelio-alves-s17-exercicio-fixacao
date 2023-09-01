string fileName = "in.csv";
List<Employee> employees = new();

try
{
  using (StreamReader sr = File.OpenText(fileName))
  {
    while (!sr.EndOfStream)
    {
      string[] fields = sr.ReadLine().Split(",");
      string employeeName = fields[0];
      string employeeEmail = fields[1];
      double employeeSalary = double.Parse(fields[2]);

      employees.Add(new Employee(employeeName, employeeEmail, employeeSalary));
    }
  }

  System.Console.Write("Enter salary: ");
  double salary = double.Parse(Console.ReadLine());

  var result = employees.Where(e => e.Salary > salary);
  var totalSalaryOfPeopleStartingWithM = employees.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);

  System.Console.WriteLine($"Email of people whose salary is more than {salary:F2}");

  foreach(var item in result)
  {
    System.Console.WriteLine(item.Email);
  }
  System.Console.Write($"Sum of salary of people whose name starts with 'M': ");
  System.Console.WriteLine($"{totalSalaryOfPeopleStartingWithM:F2}");
}
catch (Exception e)
{
  System.Console.WriteLine(e.Message);
}