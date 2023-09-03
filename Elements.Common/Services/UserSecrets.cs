using System;
using System.IO;

using Newtonsoft.Json.Linq;

using Elements.Common.Extensions;

using static System.String;
using static System.Diagnostics.Debug;

namespace Elements.Common.Services
{
    public class UserSecrets
    {
        public static UserSecrets Secrets(Type type, string @namespace) 
            => Instance ??= new UserSecrets(type, @namespace);

        private static UserSecrets Instance;
        private readonly JObject Nodes;

        private UserSecrets(Type type, string @namespace)
        {
            try
            {
                var assembly = type.Assembly;
                var stream = assembly.GetStream($"{@namespace}.{@"secrets.json"}");
                using var reader = new StreamReader(stream!);
                var json = reader.ReadToEnd();
                Nodes = JObject.Parse(json);
            }
            catch (Exception ex)
            {
                WriteLine($"Unable to load secrets file: {ex.Message}");
            }
        }

        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(':');
                    var node = Nodes[path[0]];
                    for (var index = 1; index < path.Length; index++)
                    {
                        node = node?[path[index]];
                    }
                    return node?.ToString();
                }
                catch (Exception)
                {
                    WriteLine($"Unable to retrieve secret '{name}'");
                    return Empty;
                }
            }
        }
    }
}