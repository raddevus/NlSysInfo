## Use With DiscoProcs
This DLL contains functionality used by my other project / repo at: [https://github.com/raddevus/DiscoProcs](https://github.com/raddevus/DiscoProcs)

## C# .NET Core (net8.x)
This is written in C# & is built & runs on .net core 8.x

## Fully Cross-Platform
Runs on macOS, Linux, Windows
Just build and run on any platform

## Tests Included
This project includes tests which will create & write to a sqlite db.
It will create the sqlite db in your user share using the SpecialFolder LocalApplicationData<br/>
Ex. (linux) `/home/<user-name>/.local/share` <br/>
The sqlite filename is: `nlsysinfo.db`

To run the tests, just use : `$ dotnet test`<br/>
If you want to run a specific test use : `$ dotnet test --filter DbTest.<name-of-test>`

## Using NlSysInfo With DiscoProcs
If you're using this DLL with DiscoProcs then you will need to :
1) get the DiscoProcs source (repo link above)
2) create a directory named `external` in the DiscoProcs project folder
3) Copy this DLL (NlSysInfo.dll) to the `DiscoProcs/external` folder
4) Build & run DiscoProcs (`$ dotnet run`)

