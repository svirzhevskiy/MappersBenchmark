# MappersBenchmark

##Benchmark results:
|        Method |      Mean |    Error |   StdDev |
|-------------- |----------:|---------:|---------:|
|   MapperlyMap |  92.12 ns | 0.208 ns | 0.184 ns |
|    MapsterMap |  97.06 ns | 1.871 ns | 1.563 ns |
| TinyMapperMap | 312.55 ns | 1.086 ns | 1.015 ns |
| AutoMapperMap | 480.87 ns | 2.986 ns | 2.647 ns |

// * Hints *
Outliers
  MappersBenchmark.MapperlyMap: Default   -> 1 outlier  was  removed (95.76 ns)
  MappersBenchmark.MapsterMap: Default    -> 2 outliers were removed (104.38 ns, 108.04 ns)
  MappersBenchmark.AutoMapperMap: Default -> 1 outlier  was  removed (494.23 ns)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  1 ns   : 1 Nanosecond (0.000000001 sec)
