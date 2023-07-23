using System.Text.Json.Serialization;

namespace AsmtAPI.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GradeLevel
{
    Year_1 = 1, Year_2 = 2, Year_3 = 3,
    Year_4 = 4, Year_5 = 5, Year_6 = 6
}