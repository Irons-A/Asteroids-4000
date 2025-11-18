using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Configuration
{
    public interface IConfigProvider
    {
        T LoadConfig<T>(string configPath) where T : class;
    }
}
