# UnityIoCBenchmark
a Benchmark in Unity for benchmarking IoC container

Based in parts on https://github.com/danielpalme/IocPerformance

Enable Container via defines

- ENABLE_ADIC;
- ENABLE_ZENJECT;
- ENABLE_MINIOC;
- ENABLE_STRANGEIOC;
- ENABLE_TINYIOC;
- ENABLE_DRYIOC;
- ENABLE_NINJECT

Fore some container you need to supply dependencys yourself check the README.md under /Container/\<containerName\>/README.ME

## Performance

| Container | Singleton | Transient | Combined | Complex | Factory |
| --- | --- | --- | --- | --- | --- |
| Adic | 23 | 38 | 103 | 303 | 59 |
| Zenject | 150 | 280 | 803 | 2505 | 292 |
| MinIOC | 11 | 40 | 141 | 426 | 16 |
| StrangeIoC | 68 | 153 | 403 | 1088 |  |
| TinyIoC | 23 | 105 | 431 | 1719 | 47 |
| DryIoc | 17 | 4 | 11 | 10 | 25 |
| Ninject | 600 | 1776 | 9455 | 15460 | 2534 |
