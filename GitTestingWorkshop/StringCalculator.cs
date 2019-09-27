using Newtonsoft.Json;
using System.Linq;

namespace GitTestingWorkshop
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
            return numbers.Split(',').Select(int.Parse).Sum();
        }

        public string GetJson<T>(T myObject)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.None };
            var myObjectSerialized = JsonConvert.SerializeObject(myObject, settings);

            return myObjectSerialized;
        }
    }
}