using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Mapster;
using Nelibur.ObjectMapper;

namespace Mappers;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class MappersBenchmark
{
    private readonly CarModel _carModel = Data.Car;
    private readonly IMapper _autoMapper;
    private readonly MapperlyMapper _mapperlyMapper;

    public MappersBenchmark()
    {
        //automapper
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CarModel, CarDto>();
            cfg.CreateMap<WheelModel, WheelDto>();
            cfg.CreateMap<ManufacturerModel, ManufacturerDto>();
            cfg.CreateMap<BodyType, BodyTypeDto>();
        });
        _autoMapper = autoMapperConfig.CreateMapper();
        
        //tinymapper
        TinyMapper.Bind<CarModel, CarDto>();
        TinyMapper.Bind<WheelModel, WheelDto>();
        TinyMapper.Bind<ManufacturerModel, ManufacturerDto>();
        TinyMapper.Bind<BodyType, BodyTypeDto>();
        
        //mapperly maper
        _mapperlyMapper = new MapperlyMapper();
    }

    [Benchmark]
    public CarDto AutoMapperMap()
    {
        return _autoMapper.Map<CarDto>(_carModel);
    }
    
    [Benchmark]
    public CarDto TinyMapperMap()
    {
        return TinyMapper.Map<CarDto>(_carModel);
    }
    
    [Benchmark]
    public CarDto MapperlyMap()
    {
        return _mapperlyMapper.Map(_carModel);
    }
    
    [Benchmark]
    public CarDto MapsterMap()
    {
        return _carModel.Adapt<CarDto>();
    }
}