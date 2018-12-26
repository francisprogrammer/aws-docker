namespace api.Controllers
{
    public class MailServerConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        
        public MailServerConfig()
        {
            Host = "mailserver";
            Port = 1025;
        }
    }
}