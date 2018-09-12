using JsonApiDotNetCore.Models;

namespace chatApi.Models
{
    public class Participant : Identifiable
    {
        [Attr("name")]
        public string Name { get; set; }

        [Attr("is-patient")]
        public bool IsPatient { get; set; }
    }
}