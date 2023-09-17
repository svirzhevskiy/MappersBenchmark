# MappersBenchmark

### Benchmark results:
|        Method |      N |             Mean |          Error |         StdDev |
|-------------- |------- |-----------------:|---------------:|---------------:|
|    MapsterMap |      1 |         85.92 ns |       1.123 ns |       0.877 ns |
|   MapperlyMap |      1 |         86.37 ns |       1.752 ns |       3.696 ns |
| TinyMapperMap |      1 |        279.12 ns |       5.532 ns |       9.543 ns |
| AutoMapperMap |      1 |        481.19 ns |       8.593 ns |       8.038 ns |
|    MapsterMap |    100 |      8,147.24 ns |      43.719 ns |      36.507 ns |
|   MapperlyMap |    100 |      8,341.73 ns |      60.789 ns |      50.761 ns |
| TinyMapperMap |    100 |     27,505.13 ns |     507.651 ns |     604.322 ns |
| AutoMapperMap |    100 |     43,988.06 ns |     401.206 ns |     335.025 ns |
|    MapsterMap | 100000 |  8,052,286.72 ns |  49,613.198 ns |  38,734.721 ns |
|   MapperlyMap | 100000 |  8,094,055.83 ns |  68,997.214 ns |  64,540.037 ns |
| TinyMapperMap | 100000 | 28,988,858.96 ns | 146,016.006 ns | 136,583.462 ns |
| AutoMapperMap | 100000 | 43,895,552.78 ns | 340,027.317 ns | 318,061.763 ns |



#### Legends
  Mean   : Arithmetic mean of all measurements    
  Error  : Half of 99.9% confidence interval    
  StdDev : Standard deviation of all measurements    
  1 ns   : 1 Nanosecond (0.000000001 sec)    

## Configuration
### AutoMapper
```
var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<CarModel, CarDto>();
    cfg.CreateMap<WheelModel, WheelDto>();
    cfg.CreateMap<ManufacturerModel, ManufacturerDto>();
    cfg.CreateMap<BodyType, BodyTypeDto>();
});
_autoMapper = autoMapperConfig.CreateMapper();
```
Also AutoMapper has a whole set of attributes for different scenarios: AutoMap, Ignore, ReverseMap, SourceMember and others.
### Mapster
For types with matching properties, where implicit conversion of property types is possible, no configuration is needed.    
For more complex cases:   
```
TypeAdapterConfig<CarModel, CarDto>
    .NewConfig()
    .Map(dest => dest.Name, src => $"{src.Brand} {src.Model}");
```
Mapster provides its own set of attributes: AdaptTo, AdaptFrom, AdaptTwoWays, AdaptMember and others.
### Tiny mapper
```
TinyMapper.Bind<CarModel, CarDto>();
TinyMapper.Bind<WheelModel, WheelDto>();
TinyMapper.Bind<ManufacturerModel, ManufacturerDto>();
TinyMapper.Bind<BodyType, BodyTypeDto>();
```

### Mapperly mapper
```
[Mapper]
public partial class MapperlyMapper
{
    public partial CarDto Map(CarModel carModel);
}
```
Also has attributes for mapping. `[MapProperty(nameof(Car.ModelName), nameof(CarDto.Model))]`

## Under the hood
|        Mapper |      Runtime (Based on reflections and expressions) |    Source generation on compile time |
|-------------- |----------:|---------:|
|   AutoMapper | X |  |
|    TinyMapper |  X |  |
| Mapperly |  | X |
| Mapster | | X |
