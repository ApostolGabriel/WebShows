namespace SpectacoleWeb.Export
{
    public interface Exporter<T> where T : class
    {
        public string Export(List<T> objects);
    }
}
