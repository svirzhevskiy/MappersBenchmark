# MappersBenchmark

### Benchmark results:
|        Method |      Mean |    Error |   StdDev |
|-------------- |----------:|---------:|---------:|
|   MapperlyMap |  92.12 ns | 0.208 ns | 0.184 ns |
|    MapsterMap |  97.06 ns | 1.871 ns | 1.563 ns |
| TinyMapperMap | 312.55 ns | 1.086 ns | 1.015 ns |
| AutoMapperMap | 480.87 ns | 2.986 ns | 2.647 ns |


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
### TinyMapper
Internally, TinyMapper generates mapping code through ILGenerator. The mapping code looks almost the same as handwritten code.
