using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ex : MonoBehaviour
{
    public GameObject obj; string infoname; bool onscreen; float[] data; string currdata; string[] currarrdata; int maxlogsize = 10; Queue<string> logQ = new Queue<string>();
    public GameObject player; System.Diagnostics.StackTrace t = new System.Diagnostics.StackTrace(); 
    

    void Awake() {
        player = new GameObject();
    }
    void Start()
    {
        onscreen = false;
        player.name = "Player";
        player.SetActive(true);
        player.tag = "Player";
        //add if input º onscreen true
        //todo

        currdata = "Log started";
    }
    void Update()
    {
        /*float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        currarrdata[0] = player.name;
        currarrdata[1] = "X : " + playerX.ToString();
        currarrdata[2] = "Y : " + playerY.ToString();
        for(int e = 0; e < currarrdata.Length; e++){
            currdata += " " + currarrdata[e];
        }
        //string h = "hello world";
        //Log(currdata,h,LogType.Log);
        /*if(data.Length > 0)Array.Clear(data,0,data.Length);
        else {
            Log(objname,obj,onscreen,data);
        }*/
        float px = player.transform.position.x;
        currdata = "player X : " + px.ToString();
    }
    void OnEnable()
    {
        Application.logMessageReceivedThreaded += Log;
    }

    void OnDisable()
    {
        Application.logMessageReceivedThreaded -= Log;
    }

    void Log(string currdata, string stackTrace, LogType type) {
        if (logQ.Count >= maxlogsize)logQ.Dequeue();
        logQ.Enqueue(currdata);
        //if(onscreen == true)currdata = (infoname + obj + data[i]).ToString();
        //log info on console ind. if onscreen
        Debug.Log(currdata);
    }
    void OnGUI() {
        GUI.Label(
           new Rect(
               5,                   //x
               5,                   //y
               Screen.width - 5,    //width
               Screen.height/4      //height
           ),      
           currdata                //text
        );
    }

    public float Valor(float x,float y) {
        
        return 0;
    }
}
