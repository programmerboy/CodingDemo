using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace ServerSide.Services
{
    public class DataService : IDataService
    {
        private const string API_URL = "REPLACE_WITH_API_URL/";
        private const string URL_INIT = API_URL + "api/numbers/init/{0}";
        private const string URL_GET_NUMBERS = API_URL + "api/numbers/{0}/{1}/{2}";
        private const string URL_VALIDATE = API_URL + "api/numbers/validate";

        private HttpClient _client;
        public HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }

                return _client;
            }
        }

        public async Task Foo(int num)
        {
            Console.WriteLine("Thread {0} - Start {1}", Thread.CurrentThread.ManagedThreadId, num);
            await Task.Delay(1000);
            //Thread.Sleep(1000);
            Console.WriteLine("Thread {0} - End {1}", Thread.CurrentThread.ManagedThreadId, num);
        }

        public async Task<InitializeModel> Initialize(int size)
        {
            var uri = string.Format(URL_INIT, size);
            var resp = await Client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<InitializeModel>(resp);
            return result;
        }

        public async Task<RowModel> GetNumbers(string dataset, string type, int idx)
        {
            var uri = string.Format(URL_GET_NUMBERS, dataset, "row", idx);
            var resp = await Client.GetStringAsync(uri);
            var result = JsonConvert.DeserializeObject<RowModel>(resp);
            return result;
        }


        public async Task<int[,]> LoadMatrix(string dataset, int size)
        {
            int[,] matrix = new int[size, size];
            var listOfArrays = new List<List<int>>();

            for (int i = 0; i < size; i++)
            {
                var resp = await GetNumbers(dataset, "row", i);
                listOfArrays.Add(resp.Value.ToList());
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = listOfArrays[i][j];
                }
            }

            return matrix;
        }

        public int[,] Concatenate(int[,] arrayA, int[,] arrayB)
        {
            var size = arrayA.GetLength(0);

            int[,] matrixResult = new int[size, size];

            for (int a = 0; a < size; a++)
            {
                for (int b = 0; b < size; b++)
                {
                    int sum = 0;

                    for (int c = 0; c < size; c++)
                    {
                        sum += arrayA[a, c] * arrayB[c, b];
                    }

                    matrixResult[a, b] = sum;
                }
            }

            return matrixResult;
        }
        public async Task<ValidateModel> Validate(int[,] matrix)
        {
            var sb = new StringBuilder();

            for (int a = 0; a < matrix.GetLength(0); a++)
            {
                for (int b = 0; b < matrix.GetLength(1); b++)
                {
                    sb.Append(matrix[a, b]);
                }
            }

            string payload;

            using (var md5 = MD5.Create())
            {
                var matrixBytes = Encoding.UTF8.GetBytes(sb.ToString());
                var hash = md5.ComputeHash(matrixBytes);
                payload = string.Join("", hash.Select(b => b.ToString()).ToList());
            }

            StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await Client.PostAsync(URL_VALIDATE, content);

            Console.WriteLine("Response Success - {0}", resp.IsSuccessStatusCode);

            var body = await resp.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ValidateModel>(body);

            return result;
        }
    }
}
