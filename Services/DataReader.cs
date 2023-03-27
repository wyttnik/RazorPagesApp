using System.IO;
using System.Text.Json.Nodes;

namespace RazorPagesApp.Services
{
    public class DataReader: IDataReader
    {
        public readonly string fileName = "data.json";

        public JsonNode GetData(string key)
        {
            StreamReader sr = new StreamReader(fileName); 
            var input = sr.ReadToEnd();
            var jsonObject = JsonNode.Parse(input)!.AsObject();
            return jsonObject["pages"][key];
        }

    }
}
