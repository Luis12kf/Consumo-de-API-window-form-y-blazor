using System.Text.Json.Serialization;

namespace BlazorApp1.modelos
{
    public class Root
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("matricula")]
        public string? Matricula { get; set; }

        [JsonPropertyName("cedula")]
        public string? Cedula { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("apellido")]
        public string? Apellido { get; set; }

        [JsonPropertyName("fecha_Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [JsonPropertyName("fecha_Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [JsonPropertyName("ocupacion")]
        public string? Ocupacion { get; set; }

        [JsonPropertyName("nacionalidad")]
        public string? Nacionalidad { get; set; }

        [JsonPropertyName("telefono")]
        public string? Telefono { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("direccion")]
        public string? Direccion { get; set; }

        [JsonPropertyName("carrera")]
        public string? Carrera { get; set; }
    }
}
