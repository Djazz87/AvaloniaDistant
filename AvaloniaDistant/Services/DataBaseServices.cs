using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaDistant.Models;
using CommunityToolkit.Mvvm.Input;
using MySqlConnector;
namespace AvaloniaDistant.Services;

public class DataBaseServices
{
    private static MySqlConnection _connection;

    static DataBaseServices()
    {
        _connection = new MySqlConnection(
            "database=1125_distant_solop;user id=root;password=;port=3306;server=127.0.0.1;characterset=utf8");
    }

    public static List<IllnessRecord> GetIllnessRecords()
    {
    string sql = @"SELECT
    r.Id,r.StartDate,r.EndDate,r.DiagnosisNote,
    e.Id AS EmployeeId,e.FullName,e.Position,e.HireDate,
    d.Id AS DepartmentId,d.Name AS DepartmentName,d.Floor,
    t.Id AS IllnessTypeId,t.Name AS IllnessName,t.IsInfectious,t.QuarantineDays
FROM illnessrecords r  JOIN employees e ON r.EmployeeId = e.Id JOIN departments d ON e.DepartmentId = d.Id
JOIN illnesstypes t ON r.IllnessTypeId = t.Id;";

    List<IllnessRecord> list = new();

    if (OpenConnection())
    {
        using var cmd = new MySqlCommand(sql, _connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Department dep = new Department
            {
                Id = reader.GetInt32("DepartmentId"),
                Name = reader.GetString("DepartmentName"),
                Floor = reader.GetInt32("Floor")
            };

            Employee emp = new Employee
            {
                Id = reader.GetInt32("EmployeeId"),
                FullName = reader.GetString("FullName"),
                Position = reader.GetString("Position"),
                HireDate = reader.GetDateTime("HireDate"),
                Department = dep
            };

            IllnessType type = new IllnessType
            {
                Id = reader.GetInt32("IllnessTypeId"),
                Name = reader.GetString("IllnessName"),
                IsInfectious = reader.GetBoolean("IsInfectious"),
                QuarantineDays = reader.GetInt32("QuarantineDays")
            };

            IllnessRecord rec = new IllnessRecord
            {
                Id = reader.GetInt32("Id"),
                StartDate = reader.GetDateTime("StartDate"),
                EndDate = reader.GetDateTime("EndDate"),
                DiagnosisNote = reader.GetString("DiagnosisNote"),
                Employee = emp,
                IllnessType = type
            };

            list.Add(rec);
        }
        CloseConnection();
    }

    return list;
}


        
        
    static bool OpenConnection()
    {
        try
        {
            _connection.Open();
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
    
    static void CloseConnection()
    {
        try
        {
            _connection.Close();
        }
        catch (Exception e)
        {
        }
    }
    
    
    
}