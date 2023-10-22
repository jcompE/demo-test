namespace TestWebService.Helpers
{
    public class DaemonConfig
    {
        public string DaemonName { get { return "Test Web API Service"; } }
        public string HTTP_Port { get { return "4000"; } }
        public string HTTPS_Port { get { return "4001"; } }
        public string Secret { get; set; }
    }
}