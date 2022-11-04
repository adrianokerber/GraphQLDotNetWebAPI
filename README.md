# GraphQLDotNetWebAPI
A WebAPI based on the post https://dev.to/berviantoleo/getting-started-graphql-in-net-6-part-1-4ic2

To build and run the API just run
```bash
dotnet run --project .\GraphQLDotNet.WebAPI\GraphQLDotNet.WebAPI.csproj
```

## Usage

To debug the WebAPI you can use the Altair UI through the following URL:
```
https://localhost:7107/ui/altair
```
.. And run the following queries:
```
{
  notes {
    id,
    message
  }
  
  notesFromRepository
  {
    message
  }
}


######################
### Mutation example:
# mutation
# {
#   createNote(message: "Hello World! - I'm a mutation!")
#   {
#       id
#       message
#   }
# }

#### Query option 2:
query {
  notes {
    id,
    message
  }
}
```

Or acess via any RestClient or direcly via cURL
```cURL
curl --location --request POST 'https://localhost:7107/graphql' \
--header 'Content-Type: application/json' \
--data-raw '{"query":"{\r\n    notes {\r\n        id,\r\n        message\r\n    }\r\n}","variables":{}}'
```

> Note: the port of the URL examples might change

## Roadmap

We will continue on step 3 of the tutorial and after finishing all we will go back on implementing it on https://github.com/adrianokerber/JiuJitsuRecordsWebAPI