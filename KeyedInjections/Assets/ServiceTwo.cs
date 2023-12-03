namespace KeyedInjections.Assets
{
    public class ServiceTwo : IService
    {
        public string Notice(string text)
        {
            return $"[ServiceTwo] {text}";
        }
    }
}
