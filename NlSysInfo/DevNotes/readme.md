## Db Creation
Data base is created at special folder LocalApplicationData
which is at:<br>
 `/home/user-name/.local/share` on Ubuntu / Linux

## Run Tests On Only One Class
- `dotnet test --filer <test-class-name>`
- `dotnet test --filter DbTest`<br>
More details at: [learn.microsft.com/unit tests](https://learn.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=xunit)