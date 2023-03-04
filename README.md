# TfL RoadStatus
Developed by Leon Byford

## How to build
The `Tfl.RoadStatus.sln` solution can be built using Visual Studio.
You may need to restore Nuget packages.

Alternatively, you can use the command line:

```
> cd path\to\Tfl.RoadStatus\
> dotnet restore
> msbuild .\Tfl.RoadStatus.sln
```

## How to run the output
After building, you must update the `appsettings.json` file with your Unified API app key.
This can be found in the `Tfl.RoadStatus\Tfl.RoadStatus\bin\Debug\net6.0` directory.

Then, in the same directory, you can run the program like so:

```
> .\RoadStatus.exe A2
The status of the A2 is as follows
    Road Status is Closure
    Road Status Description is Closure

> echo $LASTEXITCODE
0

> .\RoadStatus.exe A233
A233 is not a valid road

> echo $LASTEXITCODE
1
```

## How to run the tests

You can run the tests in the `Tfl.RoadStatus.Test` project using Visual Studio.
Alternatively, use the command line:

```
> cd path\to\Tfl.RoadStatus\Tfl.RoadStatus.Test\bin\Debug\net6.0\
> vstest.console.exe .\Tfl.RoadStatus.Test.dll
```

## Assumptions I've made

* In the past few years, a change was made to the Unified API so that now only an `app_key`
is used; an `app_id` is no longer provided. This software is implemented with this in mind,
so only the `app_key` is configurable.

* The Unified API allows you to make requests anonymously (without providing an `app_key`).
However, I have made an assumption that there is no need to accommodate such requests.
Therefore, my software is designed to require an `app_key`.

* I assume there will be no issues connecting to the Unified API. There is therefore no
error handling in cases where there are network issues.
