

using ConverterForTorqe;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

var values = new DescriptorCollection();


var reader = System.IO.File.ReadAllText("input.json");
values.descriptors = JsonConvert.DeserializeObject<List<Descriptor>>(reader);

var sample = System.IO.File.ReadAllText("sample.txt");
string result = "";

foreach (var v in values.descriptors)
{
    var temp = sample;

    temp = temp.Replace("%FRIENDLY_NAME%", v.name);
    temp = temp.Replace("%FULL_NAME%", v.attribute);
    temp = temp.Replace("%ENDING%", Regex.Replace(v.name, @"[\d-]", String.Empty)

        .ToLower()
        .Replace(" ", "")
        .Replace("(", "")
        .Replace(")", "")
        .Replace("%", "")
        .Replace("/", "p")
        .Replace(":", "")
        .Replace("°", "deg")
        .Replace("λ", "")
        .Replace("&", "and")
        );


    string generateUnit = "";
    int indexOfBracket = v.name.LastIndexOf('(');
    if (indexOfBracket > 0)
    {
        generateUnit = v.name.Substring(indexOfBracket);
    }
    generateUnit = generateUnit.Replace("(", "").Replace(")", "");

    temp = temp.Replace("%UNIT%", generateUnit);



    result += temp;

}


if (System.IO.File.Exists("output.yaml"))
{
    System.IO.File.Delete("output.yaml");
}

System.IO.File.WriteAllText("output.yaml", result);


