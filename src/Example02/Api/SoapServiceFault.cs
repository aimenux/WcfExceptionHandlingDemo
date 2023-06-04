namespace Api;

[DataContract]
public class SoapServiceFault
{
    public SoapServiceFault(string errorCode, string errorMessage)
    {
        ErrorCode = errorCode;
        ErrorMessage = errorMessage;
    }

    [DataMember]
    public string ErrorCode { get; set; }
    
    [DataMember]
    public string ErrorMessage { get; set; }
}