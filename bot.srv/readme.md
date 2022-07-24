# How to build swagger json file

* Assumption: we have the following sdks installed

the version 6.* is required to run the swagger tool

```sh
dotnet --list-sdks
6.0.302 [/usr/local/bin/sdk]
7.0.100-preview.6.22352.1 [/usr/local/bin/sdk]
```

* Don't forget to call: `dotnet tool restore`
* [A nice example of min api & swagger docs](https://github.com/dotnet/aspnet-api-versioning/blob/main/examples/AspNetCore/WebApi/MinimalOpenApiExample/Program.cs)