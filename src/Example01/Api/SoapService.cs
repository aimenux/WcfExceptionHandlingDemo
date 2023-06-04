namespace Api;

[ServiceContract]
public interface ISoapService
{
    [OperationContract]
    SoapContracts.Response Randomize(SoapContracts.Request request);
}
 
[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
public class SoapService : ISoapService
{
    public SoapContracts.Response Randomize(SoapContracts.Request request)
    {
        var input = request.Input;
        
        if (IsValid(input))
        {
            return new SoapContracts.Response
            {
                Output = Random.Shared.Next(input)
            };
        }

        return input switch
        {
            > 0 and < 200 => throw new ArithmeticException($"[ArithmeticException] You entered an invalid number {input}"),
            > 200 and < 400 => throw new ArgumentException($"[ArgumentException] You entered an invalid number {input}"),
            > 400 and < 600 => throw new ApplicationException($"[ApplicationException] You entered an invalid number {input}"),
            _ => throw new Exception($"[Exception] You entered an invalid number {input}")
        };
    }
    
    private static bool IsValid(int input) => input is > 800 and < 1000;
}