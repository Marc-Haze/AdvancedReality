using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class HideAfterSeconds : MonoBehaviour{
    public GameObject loading1,loading2,bckg1,bckg2,bckg3;

    public static Boolean firstView=false;
    public static Boolean Viewing=true;

    public static Boolean getViewing(){
        return Viewing;
    }
    public static void setViewing(Boolean view){
        Viewing=view;
    }
    void hideUI1(){
        loading1.SetActive(false);
    }
    void hideUI2(){
        loading2.SetActive(false);
    }
    void hideBckg1(){
        bckg1.SetActive(true);
    }
    void hideBckg2(){
        bckg2.SetActive(false);
    }
    void hideBckg3(){
        bckg3.SetActive(false);
    }

    // Start is called before the first frame update
    async void Start(){
        /* */
        if(!firstView){
            loading1.SetActive(true);
            Invoke("hideUI1", 3.5f);
            loading2.SetActive(true);
            Invoke("hideUI2", 5.5f);
            firstView=true;
        }
        while(Viewing){
            bckg1.SetActive(true);
            Invoke("hideBckg1", 10f);
            bckg2.SetActive(true);
            Invoke("hideBckg2", 20f);
            bckg3.SetActive(true);
            Invoke("hideBckg3", 30f);
            await Task.Delay(25000);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
