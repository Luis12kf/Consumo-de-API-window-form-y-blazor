using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient _client = new()
        {
            BaseAddress = new Uri("https://pruebaestudiantes-fsa8h8hjhpcdhygm.westus-01.azurewebsites.net/")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarDatosGridAsync();
        }


        private async Task CargarDatosGridAsync()
        {
            try
            {
                // 1. Petición GET a la ruta del endpoint de la API
                HttpResponseMessage response = await _client.GetAsync("api/estudiantes");

                if (response.IsSuccessStatusCode)
                {
                    // 2. Leer la respuesta como String

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    // 3. Deserializar el JSON a una Lista de C#
                    JsonSerializerOptions serializerOptions = new()
                    {
                        PropertyNameCaseInsensitive = true // Permite mapear JSON 'nombre' a C# 'Nombre'
                    };
                    JsonSerializerOptions options = serializerOptions;

                    List<Root>? listaEstudiantes = JsonSerializer.Deserialize<List<Root>>(jsonResponse, options);

                    // 4. Asignar la lista al DataGridView
                    dataGridView1.DataSource = listaEstudiantes;
                }
                else
                {
                    MessageBox.Show($"Error en la API: {response.StatusCode}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private async Task Button1_ClickAsync(object sender, EventArgs e)
        {
            await CargarDatosGridAsync();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
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



   


