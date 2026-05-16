using HybridCLR;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class LoadDLL : MonoBehaviour
{
   void Start()
   {
#if !UNITY_EDITOR
      Assembly hotUpdateAss = Assembly.Load(File.ReadAllBytes($"{Application.streamingAssetsPath}/HotUpdate.dll.bytes"));
#else 
      Assembly hotUpdateAss = System.AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == "HotUpdate");
#endif
      Type type = hotUpdateAss.GetType("Hello");
      type.GetMethod("Run").Invoke(null, null);
   }
   
}
