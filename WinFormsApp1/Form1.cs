using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Singleton.modelos;

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

        // Reemplaza el método Button1_ClickAsync para corregir el error CS0119
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false; // Deshabilitar el botón mientras se realiza la operación
            try
            {
                await CargarDatosGridAsync();
            }
            finally
            {
                button1.Enabled = true; // Habilitar el botón después de la operación
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 FormularioEstudiantes = new Form2();

            FormularioEstudiantes.Show();
        }
    }
  
}



   


