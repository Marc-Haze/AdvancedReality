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
    public GameObject loading1,loading2,videoPlayer,background;

    public static Boolean firstView=false;
    void hideUI1(){
        loading1.SetActive(false);
    }
    void hideUI2(){
        loading2.SetActive(false);
    }
    void hideUI3(){
        background.SetActive(false);
    }

    // Start is called before the first frame update
    void Start(){
        videoPlayer.transform.GetChild(0).GetComponent<UnityEngine.Video.VideoPlayer>().url = System.IO.Path.Combine (Application.streamingAssetsPath,"lanzarote.mp4");
        //videoPlayer.transform.GetChild(0).GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        /* */
        if(!firstView){
            loading1.SetActive(true);
            Invoke("hideUI1", 3.5f);
            loading2.SetActive(true);
            Invoke("hideUI2", 5.5f);
            firstView=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!videoPlayer.transform.GetChild(0).GetComponent<UnityEngine.Video.VideoPlayer>().isPlaying){
            background.SetActive(true);
            Invoke("hideUI3", 1.5f);
            videoPlayer.transform.GetChild(0).GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        }
    }
}
