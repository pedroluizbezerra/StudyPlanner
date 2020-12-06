
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace StudyPlanner.Business.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TipoConhecimento
    {
        [EnumMember(Value = "LinguagemFrontEnd")]
        LinguagemFrontEnd,
        [EnumMember(Value = "LinguagemBackEnd")]
        LinguagemBackEnd,
        [EnumMember(Value = "Cloud")]
        Cloud,
        [EnumMember(Value = "Processo")]
        Processo,
        [EnumMember(Value = "Ferramenta")]
        Ferramenta,
        [EnumMember(Value = "Padrão")]
        Padrão,
        [EnumMember(Value = "Lingua")]
        Lingua       
    }
}