namespace KeyedInjections.Assets
{
    public class ServiceOne : IService
    {
        public string Notice(string text)
        {
            return $"[ServiceOne] {text}";
        }
    }
}
