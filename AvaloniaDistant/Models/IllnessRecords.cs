using System;

namespace AvaloniaDistant.Models;

public class IllnessRecords
{
    public int r_Id {get; set;}
    public Employees EmployeeId  {get; set;}
    public IllnessTypes IllnessTypeId  {get; set;}
    public DateTime StartDate {get; set;}
    public DateTime EndDate {get; set;}
    public string DiagnosisNote {get; set;}
}