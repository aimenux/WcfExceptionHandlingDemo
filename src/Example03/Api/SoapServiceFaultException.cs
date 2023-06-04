namespace Api;

public class SoapServiceFaultException : FaultException<SoapServiceFault>
{
    public SoapServiceFaultException(string errorCode, string errorMessage) : base(new SoapServiceFault(errorCode, errorMessage), new FaultReason(errorCode))
    {
    }
    
    public SoapServiceFaultException(SoapServiceFault detail) : base(detail)
    {
    }

    public SoapServiceFaultException(SoapServiceFault detail, string reason) : base(detail, reason)
    {
    }

    public SoapServiceFaultException(SoapServiceFault detail, FaultReason reason) : base(detail, reason)
    {
    }

    public SoapServiceFaultException(SoapServiceFault detail, string reason, FaultCode code) : base(detail, reason, code)
    {
    }

    public SoapServiceFaultException(SoapServiceFault detail, FaultReason reason, FaultCode code) : base(detail, reason, code)
    {
    }

    public SoapServiceFaultException(SoapServiceFault detail, string reason, FaultCode code, string action) : base(detail, reason, code, action)
    {
    }

    public SoapServiceFaultException(SoapServiceFault detail, FaultReason reason, FaultCode code, string action) : base(detail, reason, code, action)
    {
    }

    protected SoapServiceFaultException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}