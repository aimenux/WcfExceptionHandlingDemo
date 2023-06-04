namespace Api;

[ServiceContract]
public interface ISoapService
{
    [OperationContract]
    [FaultContract(typeof(SoapServiceFault))]
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
            > 0 and < 200 => throw new SoapServiceFaultException("ErrorCode-1", $"[ArithmeticException] You entered an invalid number {input}"),
            > 200 and < 400 => throw new SoapServiceFaultException("ErrorCode-2", $"[ArgumentException] You entered an invalid number {input}"),
            > 400 and < 600 => throw new SoapServiceFaultException("ErrorCode-3", $"[ApplicationException] You entered an invalid number {input}"),
            _ => throw new SoapServiceFaultException("ErrorCode-4", $"[SoapServiceFaultException] You entered an invalid number {input}")
        };
    }
    
    private static bool IsValid(int input) => input is > 800 and < 1000;
}