using System;

namespace AvaloniaDistant.Models;

public class IllnessRecord
{
    
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiagnosisNote { get; set; }

        public Employee Employee { get; set; }
        public IllnessType IllnessType { get; set; }
        
}