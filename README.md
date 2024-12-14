# AzureFunctionApp

## Project Purpose
This Azure Function app was developed to demonstrate the ability to convert flat JSON data (nested JSON is not supported) into an Excel file. The function accepts JSON input, converts it into a DataTable, and then exports it to an Excel file using the NPOI library. This project showcases data transformation and file generation in an Azure Functions environment.

## Contributors
- Darshana Wijesinghe

## App Features
- Convert JSON data to an Excel file.

## Requirements
- Azure Functions
- .NET 6.0
- NPOI library for Excel file handling

## Example JSON

Here's an example JSON that can be sent to the function:

```json
[
  {
    "Id": 1,
    "Name": "John Doe",
    "Age": 30,
    "Country": "USA"
  },
  {
    "Id": 2,
    "Name": "Jane Smith",
    "Age": 25,
    "Country": "Canada"
  },
  {
    "Id": 3,
    "Name": "Samuel Green",
    "Age": 35,
    "Country": "UK"
  }
]
```
## Support

Darshana Wijesinghe  
Email address - [dar.mail.work@gmail.com](mailto:dar.mail.work@gmail.com)  
Linkedin - [darwijesinghe](https://www.linkedin.com/in/darwijesinghe/)  
GitHub - [darwijesinghe](https://github.com/darwijesinghe)

## License

This project is licensed under the terms of the **MIT** license.