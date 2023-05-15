using System.Runtime.InteropServices.JavaScript;

namespace dotnet_7.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = "Frodo";
    public int HitPoints { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public RpgClass Class { get; set; } = RpgClass.Cleric;
    public bool IsDeleted { get; set; } = false;
    public JSType.Date? DateCreated { get; set; }
}