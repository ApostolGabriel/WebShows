using System.Text;

namespace SpectacoleWeb.Export
{
    public class CsvExporter<T> : Exporter<T> where T : class
    {
        public string Export(List<T> objects)
        {
            StringBuilder sb = new();
            if (objects.Count > 0) {
                int i = 0;
                foreach (var property in objects.FirstOrDefault().GetType().GetProperties())
                {
                    sb.Append(property.Name);
                    if (i < objects.FirstOrDefault().GetType().GetProperties().Length - 1)
                    {
                        sb.Append(',');
                    }
                    i++;
                }
                sb.AppendLine();

                foreach (var obj in objects)
                {
                    for(int j = 0; j < obj.GetType().GetProperties().Length; j++)
                    {
                        sb.Append(obj.GetType().GetProperties()[j].GetValue(obj).ToString());
                        if(j < obj.GetType().GetProperties().Length - 1)
                        {
                            sb.Append(',');
                        }
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            else
            {
                throw new Exception("No objects");
            }
        }
    }
}
