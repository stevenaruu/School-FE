using Bootcamp_CKres_Minor.Input;
using Bootcamp_CKres_Minor.Output;
using Bootcamp_CKres_Minor_FE.Service;
using Newtonsoft.Json;

namespace Bootcamp_CKres_Minor_FE.Handler
{
    public class ScoreHandler : IScore
    {

        private readonly IConfiguration _configuration;
        private readonly string baseUrl = "";
        private HttpClient HttpClient = new HttpClient();

        public ScoreHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            baseUrl = _configuration["apiEndPoint"];
        }

        public async Task<StatusOutput> createStudent(StudentInput? data)
        {
            if(data == null)
            {
                return new StatusOutput()
                {
                    statusCode = 400,
                    message = "bad request."
                };
            }

            string endpoint = $"{baseUrl}/Student";
            var apiResponse = await HttpClient.PostAsJsonAsync(endpoint, data);
            var output = await apiResponse.Content.ReadFromJsonAsync<StatusOutput>();

            return output;
        }

        public async Task<GenderOutput> getGenderList()
        {
            string endpoint = $"{baseUrl}/Gender";
            GenderOutput genders = null;

            var response = await HttpClient.GetAsync(endpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(apiResponse))
            {
                genders = JsonConvert.DeserializeObject<GenderOutput>(apiResponse);
            }

            return genders;
        }

        public Task<GradeOutput> getGradeList()
        {
            throw new NotImplementedException();
        }

        public async Task<ReligionOutput> getReligionList()
        {
            string endpoint = $"{baseUrl}/Religion";
            ReligionOutput religions = null;

            var response = await HttpClient.GetAsync(endpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(apiResponse))
            {
                religions = JsonConvert.DeserializeObject<ReligionOutput>(apiResponse);
            }

            return religions;
        }

        public async Task<StudentOutput> getStudentDetail(string id)
        {
            {
                string endpoint = $"{baseUrl}/Student/{id}";
                StudentOutput studentDetail = null;

                var response = await HttpClient.GetAsync(endpoint);
                string apiResponse = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(apiResponse))
                {
                    studentDetail = JsonConvert.DeserializeObject<StudentOutput>(apiResponse);
                }

                return studentDetail;
            }
        }

        public Task<SubjectOutput> getSubjectOutputList()
        {
            throw new NotImplementedException();
        }
    }
}
