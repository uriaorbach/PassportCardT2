using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardT2
{
    public class PolicyFactory
    {
        public IPolicy? CreatePolicy(string json)
        {
            try
            {
                var jsonObject = JObject.Parse(json);
                if (jsonObject == null) return null;

                var policyTypeString = jsonObject["type"]?.ToString();
                if (string.IsNullOrEmpty(policyTypeString)) return null;

                var policyType = Enum.Parse<PolicyType>(policyTypeString.ToString());

                switch (policyType)
                {
                    case PolicyType.Health:
                        var healthPolicy = JsonConvert.DeserializeObject<HealthPolicy>(json);
                        return healthPolicy;
                    case PolicyType.Travel:
                        var travelPolicy = JsonConvert.DeserializeObject<TravelPolicy>(json);
                        return travelPolicy;
                    case PolicyType.Life:
                        var lifePolicy = JsonConvert.DeserializeObject<LifePolicy>(json);
                        return lifePolicy;
                    default:
                        throw new NotSupportedException($"Policy type '{policyTypeString}' is not supported.");
                }
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
