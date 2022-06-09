namespace SpectacoleWeb.Export
{
    public class ExporterFactory<T> where T : class
    {
    
        public static Exporter<T> Create(string type)
        {
            if(type.Equals("csv"))
            {
                return new CsvExporter<T>();
            }
            else
            {
                return new JsonExporter<T>();
            }
        }
    }
}
