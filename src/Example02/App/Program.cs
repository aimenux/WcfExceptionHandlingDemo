using System.ServiceModel;
using App.SoapService;
using static App.SoapServiceConstants;

await using var client = new SoapServiceClient(Https.Configuration, Https.Address);

for (var index = 0; index < 10; index++)
{
    Console.WriteLine($"Iteration {index}");
    await RandomizeAsync(client);
    Console.WriteLine();
}

Console.WriteLine("Press any key to exit program !");
Console.ReadKey();

static async Task RandomizeAsync(ISoapService client)
{
    try
    {
        var request = new SoapContractsRequest
        {
            Input = Random.Shared.Next(0, 1000)
        };
        
        var response = await client.RandomizeAsync(request);
        
        Console.WriteLine($"Response = {response.Output}");
    }
    catch (TimeoutException ex)
    {
        Console.WriteLine($"A timeout exception occurred : {ex.Message}");
    }
    catch (FaultException<SoapServiceFault> ex)
    {
        Console.WriteLine($"A custom fault exception occurred : ({ex.Detail.ErrorCode}) {ex.Detail.ErrorMessage}");
    }
    catch (FaultException ex)
    {
        Console.WriteLine($"An unknown fault exception occurred : {ex.Message}");
    }
    catch (CommunicationException ex)
    {
        Console.WriteLine($"A communication exception occurred : {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unknown exception occurred : {ex.Message}");
    }
}
