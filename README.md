# Objects-to-bytes in C#

While trying to improve the speed of [Maybe.NET](https://github.com/rmc00/Maybe), I discovered that 80-90% of the CPU time was spent on serializing objects into byte arrays before feeding them into a hashing function, that only works on byte arrays.

`Maybe.NET` uses `BinaryFormatter` for serializing objects into byte arrays - does a better method exist? Let's investigate!



