using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiGateway.Config {

    public class AlterUpstream {

        public static string AlterUpstreamSwaggerJson(HttpContext context, string swaggerJson) {
            JObject? swagger = JObject.Parse(swaggerJson);
            return swagger.ToString(Formatting.Indented);
        }
    }
}