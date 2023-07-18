using Mapster;

namespace Mappers;

[AdaptTo("CarDto"), GenerateMapper]
public class CarModel
{
    public CarModel(ManufacturerModel brand, string model, int buildYear, BodyType bodyType, List<WheelModel> wheels, WheelModel spareWheel, string[] markets, string color)
    {
        Brand = brand;
        Model = model;
        BuildYear = buildYear;
        BodyType = bodyType;
        Wheels = wheels;
        SpareWheel = spareWheel;
        Markets = markets;
        Color = color;
    }

    public ManufacturerModel Brand { get; set; }
    
    public string Model { get; set; }
    
    public int BuildYear { get; set; }
    
    public BodyType BodyType { get; set; }
    
    public List<WheelModel> Wheels { get; set; }
    
    public WheelModel SpareWheel { get; set; }
    
    public string[] Markets { get; set; }
    
    public string Color { get; set; }
}

public enum BodyType
{
    Sedan,
    Hatchback,
    Van
}

public class WheelModel
{
    public WheelModel(double radius, ManufacturerModel manufacturer, decimal price)
    {
        Radius = radius;
        Manufacturer = manufacturer;
        Price = price;
    }

    public double Radius { get; set; }
    
    public ManufacturerModel Manufacturer { get; set; }
    
    public decimal Price { get; set; }
}

public class ManufacturerModel
{
    public ManufacturerModel(string title, int foundationYear)
    {
        Title = title;
        FoundationYear = foundationYear;
    }

    public string Title { get; set; }
    
    public int FoundationYear { get; set; }
}