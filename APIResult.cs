using System;

namespace CheezeIT.JiveAPI.Wrapper
{

    /// <summary>
    /// Result of an API Call
    /// </summary>
    public class APIResult
    {
        public String ressourceUrl { get; set; }
        public int httpCode { get; set; }
        public APIResult() { }
        public APIResult(String _ressourceUrl, int _httpCode)
        {
            ressourceUrl = _ressourceUrl;
            httpCode = _httpCode;
        }

    }
}
