using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ex : MonoBehaviour {
    public GameObject obj; string infoname; bool onscreen; string currdata; string[] dataname; int maxlogsize = 10; Queue<string> logQ = new Queue<string>();
    public GameObject player; System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace();

    void Awake() {
        player = new GameObject("Player"); 
        infoname = "Player Position : ";
    }
    void Start() {
        //onscreen = false;
        player.tag = "Player";
        player.SetActive(true);
        //logQ.Enqueue(" > " + infoname);
        //add if input º onscreen true
        //todo
    }
    void Update() {
        float px = player.transform.position.x; float py = player.transform.position.y;
        string thisdata = infoname + "X : " + px.ToString() + ", " + "Y : " + py.ToString();
        Log(thisdata,t.ToString(),LogType.Log);
    }
    void OnEnable() {
        Application.logMessageReceivedThreaded += Log;
    }

    void OnDisable() {
        Application.logMessageReceivedThreaded -= Log;
    }

    void Log(string currdata, string stackTrace, LogType type) {
        logQ.Enqueue("[" + type + "] : " + currdata);
        if(type == LogType.Exception)logQ.Enqueue(stackTrace);
        while(logQ.Count > maxlogsize)logQ.Dequeue();
        //log info on console ind. if onscreen
        Debug.Log(currdata);
    }
    void OnGUI() {
        GUI.Label(
           new Rect(
               0,                   //x
               0,                   //y
               Screen.width,        //width
               Screen.height/4      //height
           ),      
           currdata,                //text
           GUI.skin.textArea
        );
        GUILayout.Label(string.Join("\n", logQ.ToArray()));
    }
    //todo unfinished make push function to add elements to an array
    string[] Push(string[] source,float[] cvalues) {
        var index = Array.IndexOf(source, cvalues);
        for(int i = 0; i < cvalues.Length; i++){
            if(index != -1) {
                source[index] = cvalues[i].ToString();
            }
        }
        return source;
    }
}
