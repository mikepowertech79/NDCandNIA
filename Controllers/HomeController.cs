using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NDCandNIA.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Web.Helpers;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace NDCandNIA.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {





            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }













        //NIA API Create
        public IActionResult niaApiCreate()
        {
            return View();
        }


        //NIA API Create
        public IActionResult niaApiDetails()
        {


            //var record = await _context.Record.FirstOrDefaultAsync(m => m.Id == id);

            //return View(record);

            return View();
        }










        public async Task<ActionResult> ValidationAPI()
        {

            //InitializeComponent();
            ApiHelper.InitializeClient();

            int numberOK = 9;


            object whatIsTheResulta = await ComicProcessor1.LoadComic(numberOK);

            WeatherForecast WeatherForecastOne = new WeatherForecast();

            try
            {
                WeatherForecastOne = await ComicProcessor1.LoadComic(numberOK);
            }
            catch
            {

            }


            //niaApiDetails

            //object whatIsTheResult = await ComicProcessor.LoadComic(numberOK);
            //ViewBag.NumberZ = whatIsTheResult;

            //return View();


            return View("niaApiDetails", WeatherForecastOne);
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }















    public class ComicProcessor1
    {
        public static async Task<WeatherForecast> LoadComic(int comicNumber = 0)
        {
            string url = "";

            if (comicNumber > 0)
            {
                url = $"https://xkcd.com/{ comicNumber }/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }


            url = "https://localhost:44383/weatherforecast";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                    string jsonData = "{\"DeptId\": 101, \"DepartmentName\": \"IT\"}";
                    string jsonDataA = "{\"DeptId\": 101, \"DepartmentName\": \"IT\"},{\"DeptId\": 102, \"DepartmentName\": \"ITa\"}";
                    string Jstr = "{\"date\":\"2021-12-21T14:06:11.4884423+08:00\",\"temperatureC\":21,\"temperatureF\":69,\"summary\":\"Chilly\"}";

                    //Department myDeserializedClass = JsonConvert.DeserializeObject(jsonDataA);
                    Department deptObj1 = JsonSerializer.Deserialize<Department>(jsonData);
                    Department deptObj12 = JsonSerializer.Deserialize<Department>(jsonData);
                    WeatherForecast deptObj2 = JsonSerializer.Deserialize<WeatherForecast>(Jstr);
                    //Console.WriteLine("Department Id: {0}", deptObj.DeptId);
                    //Console.WriteLine("Department Name: {0}", deptObj.DepartmentName);

                    //WeatherForecast comic = await response.Content.ReadAsAsync<WeatherForecast>();

                    string JsonStringVar = await response.Content.ReadAsStringAsync();
                    var objResponse1A = JsonConvert.DeserializeObject<List<WeatherForecast>>(JsonStringVar);
                    List<WeatherForecast> WeatherForecastparts = new List<WeatherForecast>();

                    WeatherForecastparts.Add(new WeatherForecast() 
                    { 
                        Date = objResponse1A[0].Date , 
                        Summary = objResponse1A[0].Summary ,
                        TemperatureC = objResponse1A[0].TemperatureC
                        
                    });

                    WeatherForecast retrunWeatherForecast = new WeatherForecast();

                    retrunWeatherForecast = WeatherForecastparts[0];

                    return retrunWeatherForecast;






                    //List<WeatherForecast> WeatherForecastparts = JsonConvert.DeserializeObject<List<WeatherForecast>>(JsonStringVar);

                    string JsonStringVarTrim = JsonStringVar.Trim('[');
                    JsonStringVarTrim = JsonStringVarTrim.Trim(']');
                    WeatherForecast deptObj = JsonSerializer.Deserialize<WeatherForecast>(JsonStringVarTrim);
                    WeatherForecast comicA = JsonConvert.DeserializeObject<WeatherForecast>(JsonStringVar);
                    var objResponse1 =  JsonConvert.DeserializeObject<List<WeatherForecast>>(JsonStringVar);
                    object someObj = await response.Content.ReadAsStringAsync();

                    //var des = (WeatherForecast)Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof(WeatherForecast));
                    ////return des.data.Count.ToString();

                    WeatherForecast comic = JsonConvert.DeserializeObject<WeatherForecast>(JsonStringVar);

                    //return await response.Content.ReadAsAsync<WeatherForecast>();




                    WeatherForecast oMycustomclassname = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherForecast>(await response.Content.ReadAsStringAsync());


                    //WeatherForecast comic2 = Json.DeserializeObject<WeatherForecast>(someObj);


                    WeatherForecast comic1 = JsonConvert.DeserializeObject<WeatherForecast>(await response.Content.ReadAsStringAsync());

                    return JsonConvert.DeserializeObject<WeatherForecast>(await response.Content.ReadAsStringAsync());

                    //WeatherForecast comic1 = await System.Text.Json.JsonSerializer.DeserializeAsync<WeatherForecast>(await response.Content.ReadAsStreamAsync());


                    //return comic1;






                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }



            }
        }
    }








    public class ComicProcessor
    {
        public static async Task<string> LoadComic(int comicNumber = 0, string shopBackTrStr = "10245644cfe147b06e24cc9db52bd9")
        {
            string url = "";

            string shopBackTransatcitoID = shopBackTrStr;

            string dateTimeNowStr = DateTime.Now.ToString();  // 2021-10-07+15:40:00

            //if (comicNumber > 0)
            //{
            //    url = $"https://xkcd.com/{ comicNumber }/info.0.json";
            //}
            //else
            //{
            //    url = "https://xkcd.com/info.0.json";
            //}



            if (comicNumber == 9)
            {

                url = "";

            }

            url = "https://localhost:44383/weatherforecast";


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                    WeatherForecast comic1 = await System.Text.Json.JsonSerializer.DeserializeAsync<WeatherForecast>(await response.Content.ReadAsStreamAsync());

                    //WeatherForecast result = await response.Content.ReadAsAsync<WeatherForecast>();

                    //return result.Results;



                    string meString = await response.Content.ReadAsStringAsync();

                    //string? messagemeStringA = await response.ReasonPhrase;

                    bool meStringB = response.IsSuccessStatusCode;

                    string meStringC = response.ReasonPhrase;

                    //ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();

                    //string comic = "success";
                    //return comic;


                    return meString;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

                //return "some";
            }
        }
    }






    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }



    public class Department
    {
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
    }

}
