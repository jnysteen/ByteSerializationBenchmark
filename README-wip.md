# `T`-to-bytes in C#

While trying to improve the speed of [Maybe.NET](https://github.com/rmc00/Maybe), I discovered that 80-90% of the CPU time was spent on serializing objects into byte arrays before feeding them into a hashing function, that only works on byte arrays.

`Maybe.NET` uses `BinaryFormatter` for serializing objects into byte arrays - does a better method exist? Let's investigate!

## Why is `BinaryFormatter` so slow?

@TODO

## Alternatives to `BinaryFormatter`

A quick search on Google and StackOverflow reveals many interesting alternatives to `BinaryFormatter`:

* _Serializing the objects into JSON_: @TODO
* _Using ProtoBuf_: @TODO
* _Using MessagePack_: https://github.com/neuecc/MessagePack-CSharp


## Benchmarking implementations

Before we can benchmark anything, we have to create whatever we're going to benchmark first (duh).

We want to benchmark different ways of converting an object to a byte array - therefore, we define an interface for the required functionality first.

@TODO - insert byteconverterinterface

Using the identified alternatives to the `BinaryFormatter`, and the `BinaryFormatter` itself, we create implementations of the interface like this:

@TODO - insert example of interface implementation with the binary formatter

All that's left now is to write the benchmarking code itself:

@TODO insert benchmarking code

## Benchmark results

