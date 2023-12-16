using Microsoft.Extensions.DependencyInjection;
using Swiper.Simulator;
using Swiper.Simulator.API;



# region Service Registration
var serviceCollection = new ServiceCollection();
serviceCollection.AddSimulator();
var serviceProvider = serviceCollection.BuildServiceProvider();
var simulatorService = serviceProvider.GetRequiredService<ISimulatorService>();
# endregion



# region Data Input
Console.WriteLine("==========");
Console.WriteLine("==SWIPER==");
Console.WriteLine("==========");
Console.WriteLine();
Console.WriteLine("Type matrix size:");
Console.Write("> ");

var input = Console.ReadLine();

if (string.IsNullOrEmpty(input) || !int.TryParse(input, out var size))
{
    Console.WriteLine("Input error");
    return;
}

var startingMatrix = new int[size][];

Console.WriteLine("Type matrix values:");
for (int i = 0; i < size; i++)
{
    startingMatrix[i] = new int[size];
    input = Console.ReadLine();
    
    if (string.IsNullOrEmpty(input) || input.Split(' ').Length != size)
    {
        Console.WriteLine("Input error");
        return;
    }

    var inputValues = input.Split(' ').Select(x => 
        {
            if (int.TryParse(x, out var val))
                return val;
            return 0;
        }
    ).ToArray();

    for (int j = 0; j < size; j++)
        startingMatrix[i][j] = inputValues[j];
}
# endregion



# region Simulation
simulatorService.StartSimulation(size, startingMatrix);
WriteHelp();
var commandHistory = new List<string>();

for (;;)
{
    Console.Write("> ");
    input = Console.ReadLine();
    
    if (input is null) continue;

    if (input == "q") return;

    if (input == "h")
    {
        WriteHelp();
        continue;
    }

    if (input == "m")
    {
        WriteMatrix(size, simulatorService.GetMatrix());
        continue;
    }

    if (input == "r")
    {
        simulatorService.StartSimulation(size, startingMatrix);
        commandHistory = [];
        continue;
    }

    if (input == "c")
    {
        WriteCommandHistory(commandHistory);
        continue;
    }

    var command = input.Split(' ');

    if (!(
        command.Length == 4
        && int.TryParse(command[1], out var newValue)
        && (newValue == 2 || newValue == 4)
        && int.TryParse(command[2], out var newValueX)
        && newValueX <= size
        && int.TryParse(command[3], out var newValueY)
        && newValueY <= size
    ))
    {
        Console.WriteLine("Input error");
        continue;
    }

    simulatorService.AddValueInMatrix(newValue, newValueX - 1, newValueY - 1);

    switch(command[0])
    {
        case ">":
            simulatorService.SwipeRight();
            break;
        case "<":
            simulatorService.SwipeLeft();
            break;
        case "^":
            simulatorService.SwipeUp();
            break;
        case "v":
            simulatorService.SwipeDown();
            break;
        default:
            Console.WriteLine("Swipe command error");
            continue;
    }
    commandHistory.Add(input);
}
# endregion

static void WriteCommandHistory(ICollection<string> commandHistory)
{
    Console.WriteLine("Command history:");
    foreach(var command in commandHistory)
    {
        Console.WriteLine($"{command}");
    }
}

static void WriteMatrix(int size, int[][] matrix)
{
    Console.WriteLine("Matrix:");
    Console.WriteLine();

    for(int i = 0;i < size; i++)
    {        
        for (int j = 0; j < size; j++)
            Console.Write($"{matrix[i][j]}\t");
        Console.WriteLine();
    }
}

static void WriteHelp()
{
    Console.WriteLine("==================");
    Console.WriteLine("=======Help=======");
    Console.WriteLine("==================");
    Console.WriteLine("Type action with 4 parameters splitted by using Spacebar:");
    Console.WriteLine("1 - direction of swipe, values - 'v', '^', '<', '>'");
    Console.WriteLine("2 - new value, values - '2', '4'");
    Console.WriteLine("3 - X coordinate of new value (horizontal), started from 1, direction of increment: from left to right");
    Console.WriteLine("4 - Y coordinate of new value (vertical), started from 1, direction of increment: from top to bottom");
    Console.WriteLine("Type 'h' to view this instruction.");
    Console.WriteLine("Type 'q' to stop application.");
    Console.WriteLine("Type 'm' to view current matrix.");
    Console.WriteLine("Type 'r' to restart simulation.");
    Console.WriteLine("Type 'c' to view command history.");
    Console.WriteLine("==================");
    Console.WriteLine();
}