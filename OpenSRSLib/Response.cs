using System;
using System.Text.Json;

namespace OpenSRSLib
{
    public class Response
    {
        public string JsonResponse { get; set; }
        public string IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseText { get; set; }

        public JsonElement Attributes { get; set; }

        public bool Success { 
            get 
            {
                if (Int32.Parse(IsSuccess) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                };
            } 
            set {} 
        }

        /// <summary>
        /// Process request specific response properties
        /// Override in derived classes
        /// </summary>
        public virtual void Process(string json){
            this.JsonResponse = json;
            if(!Success){ return; }

            return;
        }

        /// <summary>
        /// Checks if value for property exists. Assigns value if true
        /// </summary>
        /// <param name="key"></param>
        /// <param name="Callback">Action should look like: value => this.Property = value
        /// or similar</param>
        protected void CheckAttributePropValue(string key, Action<string> Callback)
        {
            JsonElement temp;
            Attributes.TryGetProperty(key, out temp);
            if (temp.ValueKind != JsonValueKind.Undefined)
            {
                Callback(temp.ToString());
            }
            
        }
    }
}