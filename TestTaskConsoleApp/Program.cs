using System.Text;
using System.Text.Json;
using TestTaskConsoleApp;

List<Patient> patientList = new ();

using (StreamReader streamReader = new StreamReader("patients.json"))
{
    string json = streamReader.ReadToEnd();
    patientList = JsonSerializer.Deserialize<List<Patient>>(json, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    });
}

using HttpClient client = new HttpClient();

client.BaseAddress = new Uri("http://test-task-api:80");

foreach (var patient in patientList)
{
    Console.WriteLine(patient);
    await client.PostAsync("Patient", new StringContent(JsonSerializer.Serialize(patient), Encoding.UTF8, "application/json"));
}