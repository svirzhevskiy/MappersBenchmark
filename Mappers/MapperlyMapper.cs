using Riok.Mapperly.Abstractions;

namespace Mappers;

[Mapper]
public partial class MapperlyMapper
{
    public partial CarDto Map(CarModel carModel);
}