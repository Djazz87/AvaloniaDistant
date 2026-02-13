using System;

namespace AvaloniaDistant.Models;

public class Employees
{
    public int e_Id {get; set;}
    public string FullName {get; set;}
    public string Position {get; set;}
    public DateTime HireDate {get; set;}
    public departments departments {get; set;}
}