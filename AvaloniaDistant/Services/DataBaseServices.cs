using System;
using System.Collections.Generic;
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

    public static List<departments> GetDepartments
    {
        
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