


// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;

var cert = new X509Certificate2("testcert.crt");
var handler = new HttpClientHandler();
//handler.ClientCertificates.Add(cert);
var client = new HttpClient(handler);

var request = new HttpRequestMessage()
{
    //RequestUri = new Uri("https://localhost:5001/api/vouchers"),
    RequestUri = new Uri("https://certtestwebapi.azurewebsites.net/api/vouchers"),
    Method = HttpMethod.Get,
};
request.Headers.Add("X-ARR-ClientCert", cert.GetRawCertDataString());
var response = await client.SendAsync(request);
if (response.IsSuccessStatusCode)
{
    var responseContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent);
}
