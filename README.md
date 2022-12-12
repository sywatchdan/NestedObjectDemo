# NestedObjectDemo

This is an app demonstrating how to retrieve a value from a set of nested Json objects. 

The user can input any object in Json format, for example:
```
{"a":{"b":{"c":"d"}}}
```
...and specify a key to retrieve, with nested keys separated by a forward slash - for example:
```
a/b/c
```

...to retrieve the value at that key, for example:
```
d
```

## Pre-requisites
.NET 7 Runtime (dotnet-runtime-7.0)
