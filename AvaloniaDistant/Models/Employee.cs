using System;

namespace AvaloniaDistant.Models;

public class Employee
{
    
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        
        public Department Department { get; set; }   
    
}