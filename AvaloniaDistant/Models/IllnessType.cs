namespace AvaloniaDistant.Models;

public class IllnessType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IsInfectious { get; set; }
    public int QuarantineDays { get; set; }
}