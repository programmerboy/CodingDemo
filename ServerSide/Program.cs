// See https://aka.ms/new-console-template for more information

using ServerSide.Services;

/***********************************************/
/******** ASSIGN MATRIX DIMENSIONS HERE ********/
/***********************************************/

var MATRIX_DIMENSIONS = 3;

Console.WriteLine("Starting API Request for Initialization....");

var service = new DataService();

var respInitialize = await service.Initialize(MATRIX_DIMENSIONS);
Console.WriteLine($"Response success - {respInitialize.Success} | Matrix Size - {respInitialize.Value}");

/*List<Task> TaskList = new List<Task>();
for (int i = 0; i < 10; i++)
    TaskList.Add(service.Foo(i));

Task.WaitAll(TaskList.ToArray());
//await Task.WhenAll(TaskList.ToArray());*/

Console.WriteLine("Time to load the matrix....");

var arrayA = await service.LoadMatrix("A", MATRIX_DIMENSIONS);
var arrayB = await service.LoadMatrix("B", MATRIX_DIMENSIONS);

var resultMatrix = service.Concatenate(arrayA, arrayB);

Console.WriteLine("Validating the Result....");

var validationResult = await service.Validate(resultMatrix);

Console.WriteLine("Validation Result - {0}", validationResult.Value);

Console.WriteLine("Press Enter to exit...");