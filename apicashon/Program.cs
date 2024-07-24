using System.Net;
using apicashon.Classes.models;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.Json;
using apicashon.Classes;
using Org.BouncyCastle.Asn1.Ocsp;

HttpListener listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8080/");
listener.Start();
Console.WriteLine("service web demarré sur localhost 8080");

while (true)
{
    ThreadPool.QueueUserWorkItem(o => RequestHandler(listener));
}
static void RequestHandler(HttpListener listener)
{
    HttpListenerContext context = listener.GetContext();
    HttpListenerRequest request = context.Request;
    Console.WriteLine($"Requete reçue: {request.Url}");


    //var data = new
    //{
    //    message = "qqch",
    //    date = DateTime.Now,
    //};

    //string jsonResponse = JsonSerializer.Serialize(data);

    //byte[] responseBytes = Encoding.UTF8.GetBytes(jsonResponse);
    //context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);

    switch (request.Url.AbsolutePath)
    {
        case "/allProd":
            try
            {
                byte[] responseBytes = AppQueries.GetAll("SELECT * FROM Production");
                context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                context.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                DB.Close();
            }
            break;
            break;

        case "/prod2":
            try
            {
                byte[] responseBytes = AppQueries.GetByID("SELECT * FROM Production WHERE id_production = @id_production", 2);
                context.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                context.Response.OutputStream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                DB.Close();
            }
            break;
    }

}

