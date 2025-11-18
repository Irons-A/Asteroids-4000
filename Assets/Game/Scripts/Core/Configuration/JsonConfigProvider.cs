using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Configuration
{
    public class JsonConfigProvider : IConfigProvider
    {
        public T LoadConfig<T>(string configPath) where T : class
        {
            TextAsset configFile = Resources.Load<TextAsset>(configPath);
            if (configFile == null)
            {
                Debug.LogError($"Config file not found at path: {configPath}");
                return null;
            }

            return JsonConvert.DeserializeObject<T>(configFile.text);
        }
    }
}
