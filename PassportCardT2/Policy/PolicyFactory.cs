using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PassportCardT2.Enums;
using PassportCardT2.IO;
using PassportCardT2.Policy.Models;

namespace PassportCardT2.Policy
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
                Logger.WriteError(ex.Message);
                return null;
            }
            catch (JsonReaderException ex)
            {
                Logger.WriteError(ex.Message);
                return null;
            }
            catch (ArgumentException ex)
            {
                Logger.WriteError(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex.Message);
                return null;
            }
        }
    }
}
