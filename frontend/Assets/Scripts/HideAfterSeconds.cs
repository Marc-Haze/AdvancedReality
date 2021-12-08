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
        videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().url = System.IO.Path.Combine (Application.streamingAssetsPath,"Lanzarote1.mp4");
        videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().isLooping = true;
        videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>().frame = 0;
        
        background.SetActive(true);
        Invoke("hideUI3", 1.5f);
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
        UnityEngine.Video.VideoPlayer video = videoPlayer.GetComponent<UnityEngine.Video.VideoPlayer>();
        if(!video.isPlaying){
            video.Play();
        }
    }
}
