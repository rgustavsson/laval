# Text Statistics

Solution consists of:
- Console app
- Web Api Server
- Shared Project

Console app & Web Api Server utilise the same services from the Shared project to fetch, format och analyze texts from an external source.

## Run console app
Takes urls as first argument. These are set in profile if you run app in Visual Studio (debug mode). Else you need to pass a comma separated list, e.g. `consoleapp.exe url1,url2`

## Run Web APIs
Start the server in debug mode and Swagger will open up.
There's a single HTTP POST API available, try it our by posting the following JSON:
```
{
    "Urls" : [
        "https://www.gutenberg.org/cache/epub/69463/pg69463.txt",
        "https://www.gutenberg.org/files/45839/45839.txt"
    ],
    "IncludeTexts" : false
}
```
