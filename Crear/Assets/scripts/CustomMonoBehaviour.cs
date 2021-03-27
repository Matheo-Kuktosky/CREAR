using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomMonoBehaviour : MonoBehaviour
{
    protected string logPrefix = "Unknown Script >> ";
    protected void consoleLog(string name, string toLog)
    {
        Debug.Log(logPrefix + name + ": " + toLog);
    }
}

