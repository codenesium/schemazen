# Schema Zen - Script and create SQL Server objects quickly

## This fork is intended to support MSSQL on Azure and also provide a nuget package

The original source can be found at https://github.com/sethreno/schemazen

Instructions on how to use the console app can also be found at https://github.com/sethreno/schemazen.


## Create a schema snapshot
```
Func<ExecutionResponse> createSchemaAction = () =>
{
	SchemaZenRunner runner = new SchemaZenRunner();
	return runner.CreateSnapshot(textBoxConnectionString.Text, textBoxDestinationDirectory.Text, true);
};
var response = await Task.Run(createSchemaAction);
```

## Deploy a schema snapshot
```
Func<ExecutionResponse> deploySchemaAction = () =>
{
	SchemaZenRunner runner = new SchemaZenRunner();
	return runner.DeploySnapshot(textBoxConnectionString.Text, textBoxDestinationDirectory.Text, true, true);
};
var response = await Task.Run(deploySchemaAction);
appendExecutionResponse(response);
```
Note that deploying a snapshot has an added parameter 'azureMode'

Azure mpde causes the deploy to behave slightly differently. 
# We don't apply any alter database statements because Azure does not support them
# When creating a database we do not specify the file names because Azure doesn't support that


## Download
This library is on nuget.

Install-Package Codenesium.SchemaZen.Library

## Contributing
I am not accepting pull requests at this time. The original code base does accept pull requests and I encourage you to contribute there. 

