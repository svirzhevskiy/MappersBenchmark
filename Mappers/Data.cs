namespace Mappers;

public static class Data
{
    public static readonly CarModel Car =
        new CarModel(
            new ManufacturerModel("Deawoo", 1950),
            "Matiz", 2004, BodyType.Hatchback,
            new List<WheelModel>()
            {
                new(17, new ManufacturerModel("Michelin", 1800), 150),
                new(17, new ManufacturerModel("Michelin", 1800), 150),
                new(17, new ManufacturerModel("Michelin", 1800), 150),
                new(17, new ManufacturerModel("Michelin", 1800), 150)
            },
            new WheelModel(15, new ManufacturerModel("Michelin", 1800), 150),
            new[] { "China", "USA" },
            "Yellow");
}