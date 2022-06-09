using System.Text.Json;

namespace SpectacoleWeb.Export
{
    public class JsonExporter<T> : Exporter<T> where T : class 
    {
        public string Export(List<T> objects) 
        {
            return JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
