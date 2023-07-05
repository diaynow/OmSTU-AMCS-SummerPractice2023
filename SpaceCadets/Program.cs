using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

string pathInput = args[0];
string pathOutput = args[1];

string input = File.ReadAllText(pathInput);
dynamic inputJson = JsonConvert.DeserializeObject(input) ?? new JObject();
List<SpaceCadet> spaceCadets = inputJson.data.ToObject<List<SpaceCadet>>();

string taskName = inputJson.taskName;
List<dynamic> result;
switch (taskName)
{
    case "GetStudentsWithHighestGPA":
        result = GetStudentsWithHighestGPA(spaceCadets);
        break;
    case "CalculateGPAByDiscipline":
        result = CalculateGPAByDiscipline(spaceCadets);
        break;
    case "GetBestGroupsByDiscipline":
        result = GetBestGroupsByDiscipline(spaceCadets);
        break;
    default:
        throw new Exception();
}
string outputJson = JsonConvert.SerializeObject(new { Response = result }, Formatting.Indented);
File.WriteAllText(pathOutput, outputJson);


static List<dynamic> GetStudentsWithHighestGPA(List<SpaceCadet> cadets)
{
    var cadetMarks = cadets.GroupBy(x => x.Name).Select(y => new
    {
        Name = y.Key,
        Mark = y.Select(y => y.Mark).ToArray()
    });
    double highestGPA = cadetMarks.Max(x => x.Mark.Average());
    var cadetHighestGPA = cadetMarks.Where(x => x.Mark.Average() == highestGPA)
    .Select(x => new
    {
        Name = x.Name,
        Mark = Math.Round(x.Mark.Average(), 2)
    });
    List<dynamic> reply = cadetHighestGPA.ToList<dynamic>();
    return reply;
}
static List<dynamic> CalculateGPAByDiscipline(List<SpaceCadet> cadets)
{
    var disciplineGPA = cadets.GroupBy(x => x.Discipline)
    .Select(y => new Dictionary<string, double> { [y.Key] = y.Average(y => y.Mark) });
    List<dynamic> reply = disciplineGPA.ToList<dynamic>();
    return reply;
}
static List<dynamic> GetBestGroupsByDiscipline(List<SpaceCadet> cadets)
{
    var groupDisciplineMark = cadets.GroupBy(x => new { x.Discipline, x.Group })
    .Select(y => new
    {
        Discipline = y.Key.Discipline,
        Group = y.Key.Group,
        GPA = y.Average(m => m.Mark)
    }).GroupBy(d => d.Discipline)
    .Select(d => new
    {
        Discipline = d.Key,
        Group = d.OrderByDescending(dd => dd.GPA).FirstOrDefault()?.Group,
        GPA = d.Max(d => d.GPA)
    });
    List<dynamic> reply = groupDisciplineMark.ToList<dynamic>();
    return reply;
}


class SpaceCadet
{
    public string Name;
    public string Group;
    public string Discipline;
    public int Mark;
}


