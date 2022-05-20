using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace TeamTailorWebhooks.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Company
    {
        public string name { get; set; }

        [JsonProperty("company-info-about")]
        public string CompanyInfoAbout { get; set; }
        public string url { get; set; }
        public string uuid { get; set; }
        public string subdomain { get; set; }
        public string logotype { get; set; }
        public Headquarters headquarters { get; set; }
    }

    public class Department
    {
        public string name { get; set; }
    }

    public class Headquarters
    {
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        [JsonProperty("country-code")]
        public string CountryCode { get; set; }
        public string zip { get; set; }
    }

    public class Job
    {
        public string title { get; set; }
        public string body { get; set; }

        [JsonProperty("remote-status")]
        public string RemoteStatus { get; set; }

        [JsonProperty("employment-type")]
        public string EmploymentType { get; set; }

        [JsonProperty("employment-level")]
        public string EmploymentLevel { get; set; }
        public string url { get; set; }

        [JsonProperty("apply-url")]
        public string ApplyUrl { get; set; }

        [JsonProperty("cover-image-url")]
        public string CoverImageUrl { get; set; }
        public string pitch { get; set; }

        [JsonProperty("start-date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end-date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("created-date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("apply-button-text")]
        public string ApplyButtonText { get; set; }
        public Department department { get; set; }
        public Role role { get; set; }
        public Recruiter recruiter { get; set; }
        public List<Location> locations { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        [JsonProperty("country-code")]
        public string CountryCode { get; set; }
        public string zip { get; set; }
    }

    public class Location2
    {
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        [JsonProperty("country-code")]
        public string CountryCode { get; set; }
        public string zip { get; set; }
    }

    public class Recruiter
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Role
    {
        public string name { get; set; }
    }

    public class Root
    {
        public string id { get; set; }

        [JsonProperty("reference-id")]
        public string ReferenceId { get; set; }

        [JsonProperty("created-at")]
        public DateTime CreatedAt { get; set; }
        public int duration { get; set; }

        [JsonProperty("job-board-id")]
        public string JobBoardId { get; set; }

        [JsonProperty("webhook-data")]
        public WebhookData WebhookData { get; set; }
        public Location location { get; set; }
        public Company company { get; set; }
        public Job job { get; set; }
    }

    public class WebhookData
    {
        [JsonProperty("experience-level")]
        public string ExperienceLevel { get; set; }

        [JsonProperty("degree-level")]
        public string DegreeLevel { get; set; }
    }


}
