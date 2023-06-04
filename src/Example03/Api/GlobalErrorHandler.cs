using CoreWCF.Dispatcher;

namespace Api;

public class GlobalErrorHandler : IErrorHandler
{
    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
    {
        var (errorCode, errorMessage) = GetError(error);
        var faultException = new SoapServiceFaultException(errorCode, errorMessage);
        var messageFault = faultException.CreateMessageFault();
        fault = Message.CreateMessage(version, messageFault, faultException.Action);
    }

    public bool HandleError(Exception error) => true;

    private static (string errorCode, string errorMessage) GetError(Exception error)
    {
        return error switch
        {
            ArithmeticException _ => ("ErrorCode-1", error.Message),
            ArgumentException _ => ("ErrorCode-2", error.Message),
            ApplicationException _ => ("ErrorCode-3", error.Message),
            _ => ("ErrorCode-4", error.Message),
        };
    }
}