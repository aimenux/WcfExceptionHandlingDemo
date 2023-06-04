namespace Api;

public class SoapContracts
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public int Input { get; set; }
    }
    
    [DataContract]
    public class Response
    {
        [DataMember]
        public int Output { get; set; }
    }
}