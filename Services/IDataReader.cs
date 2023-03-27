using System.Text.Json.Nodes;

namespace RazorPagesApp.Services
{
    public interface IDataReader
    {
        public JsonNode GetData(string key);
    }
}