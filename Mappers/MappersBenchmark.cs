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
    
    [Params(1, 100, 100_000)]
    public int N;

    [Benchmark]
    public void AutoMapperMap()
    {
        for (int i = 0; i < N; i++)
        {
            _autoMapper.Map<CarDto>(_carModel);
        }
    }
    
    [Benchmark]
    public void TinyMapperMap()
    {
        for (int i = 0; i < N; i++)
        {
            TinyMapper.Map<CarDto>(_carModel);
        }
    }
    
    [Benchmark]
    public void MapperlyMap()
    {
        for (int i = 0; i < N; i++)
        {
            _mapperlyMapper.Map(_carModel);
        }
    }
    
    [Benchmark]
    public void MapsterMap()
    {
        for (int i = 0; i < N; i++)
        {
            _carModel.Adapt<CarDto>();
        }
    }
}