namespace Mappers;

public class CarDto
{
    public ManufacturerDto Brand { get; set; }
    
    public string Model { get; set; }
    
    public int BuildYear { get; set; }
    
    public BodyTypeDto BodyType { get; set; }
    
    public WheelDto[] Wheels { get; set; }
    
    public object SpareWheel { get; set; }
    
    public string[] Markets { get; set; }
    
    public string Color { get; set; }
}

public enum BodyTypeDto
{
    Sedan,
    Hatchback,
    Van
}

public class WheelDto
{
    public double Radius { get; set; }
    
    public ManufacturerDto Manufacturer { get; set; }
    
    public decimal Price { get; set; }
}

public class ManufacturerDto
{
    public string Title { get; set; }
    
    public int FoundationYear { get; set; }
}