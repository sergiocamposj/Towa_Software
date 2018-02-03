using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace EvaluacionFinalXF
{
    public class Connect
    {
        public static string tokenVacios { get; set; }
        public Connect()
        {
        }

        public static UserModel Login(UserModel obj)
        {
            string postString = "{\"username\":\"" + obj.username + "\",\"password\":\"" + obj.password + "\"}";
            byte[] dataS = UTF8Encoding.UTF8.GetBytes(postString);

            HttpWebRequest request = WebRequest.Create("https://baas.kinvey.com/user/kid_SyXkBdMVM/login") as HttpWebRequest;

            request.ProtocolVersion = HttpVersion.Version11;
            request.Timeout = 10 * 1000;
            request.Method = "POST";
            request.ContentLength = dataS.Length;
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==";
            request.Headers["X-Kinvey-API-Version"] = "3";

            Stream postStream = request.GetRequestStream();
            postStream.Write(dataS, 0, dataS.Length);

            try
            {
                HttpWebResponse responseS = request.GetResponse() as HttpWebResponse;
                StreamReader readerS = new StreamReader(responseS.GetResponseStream());
                string body = readerS.ReadToEnd();
                UserModel objeto = JsonConvert.DeserializeObject<UserModel>(body);

                return objeto;
            }
            catch
            {
                return new UserModel();
            }
        }

        public static string Register(string username_IO, string password_IO, string name_IO, int phone_IO, string email_IO)
        {
            string strPost = "{\"username\": \"" + username_IO + "\",\"password\":\"" +
                password_IO + "\",\"name\":\"" + name_IO + "\",\"phone\":\"" + phone_IO + "\",\"mail\":\"" + email_IO + "\"}";


            byte[] data = UTF8Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest requestReg = WebRequest.Create("https://baas.kinvey.com/user/kid_SyXkBdMVM") as HttpWebRequest;

            requestReg.ProtocolVersion = HttpVersion.Version11;
            requestReg.Timeout = 10 * 1000;
            requestReg.Method = "POST";
            requestReg.ContentLength = data.Length;
            requestReg.ContentType = "application/json; charset=utf-8";
            requestReg.Headers["Authorization"] = "Basic a2lkX1N5WGtCZE1WTToyOGQwOThmOTQ0N2Q0OWNmYmI0MTUwN2FjOWU3MDZiOA==";
            requestReg.Headers["X-Kinvey-API-Version"] = "3";

            Stream pstStream = requestReg.GetRequestStream();
            pstStream.Write(data, 0, data.Length);

            try
            {
                HttpWebResponse reply = requestReg.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(reply.GetResponseStream());
                string bodyJson = reader.ReadToEnd();

                UserModel objeto = JsonConvert.DeserializeObject<UserModel>(bodyJson);

                if (objeto.username != null)
                {
                    return "OK";
                }
                else
                {
                    return "";
                }

            }
            catch
            {
                return "Hubo un problema en la comunicacion con el servidor";
            }
        }

        public static async void GetMovies(Action<MovieModel[]> success,
                                     Action error)
        {
            String url = "https://baas.kinvey.com/appdata/kid_SyXkBdMVM/movies";

            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(new Uri(url));

            // request.Headers["Authorization"] = "Basic a2lkX1N5WGtCZE1WTTowMmIxM2Y1MzYzOGU0NjZkYTI2YTI3Y2IxYzNkNTNkNg==";
            request.Headers["Authorization"] = "Kinvey " + tokenVacios;
            request.Headers["X-Kinvey-API-Version"] = "3";

            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(stream);
                    String json = reader.ReadToEnd();

                    MovieModel[] movies = JsonConvert.DeserializeObject<MovieModel[]>(json);

                    success(movies);

                }
            }

        }

    }

}
