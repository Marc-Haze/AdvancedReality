using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourManager : MonoBehaviour
{
    //List of sites
    public GameObject[] objSites;
    //main menu
    public GameObject canvasMainMenu, Camera;
    //Should camera move
    public bool isCameraMove = false;
    public bool open = true; public bool firstload = false;
    //Place where we are
    public static string place="Playa Blanca";
    public static string getPlace(){
        return place;
    }

    // Start is called before the first frame update
    void Start()
    {
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isCameraMove){
            if(Input.GetKeyDown(KeyCode.Escape)){
                ReturnToMenu();
            }
        }*/
        if (firstload)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                ReturnToMenu();
                
            }
            if(open){
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.transform.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out hit, 100.0f)){
                    if(hit.transform.gameObject.tag == "Image"){
                        hit.transform.gameObject.GetComponent<MediaImage>().ShowImage();
                    }else if(hit.transform.gameObject.tag == "Timanfaya"){
                        LoadSite(3);
                    }else if(hit.transform.gameObject.tag == "Arrecife"){
                        LoadSite(1);
                    }else if(hit.transform.gameObject.tag == "LaGraciosa"){
                        LoadSite(2);
                    }else if(hit.transform.gameObject.tag == "PlayaBlanca"){
                        LoadSite(0);
                    }
                }
            }
            }
        }else{
            LoadSite(0);
            ReturnToMenu();
        }
    }

    public void LoadSite(int siteNumber)
    {
        //show site
        for (int i = 0; i < objSites.Length; i++)
        {
            objSites[i].SetActive(false);
        }
        objSites[siteNumber].SetActive(true);
        if(siteNumber == 0){
            place = "Playa Blanca";
        }else if(siteNumber == 1){
            place = "Arrecife";
        }else if(siteNumber == 2){
            place = "La Graciosa";
        }else if(siteNumber == 3){
            place = "National Park Timanfaya";
        }
        //hide menu
        canvasMainMenu.SetActive(false);
        //enable the camera
        isCameraMove = true;
        firstload = true;
        open = true;
        GetComponent<CameraController>().ResetCamera();
    }

    public void ReturnToMenu()
    {
        //reset
        //GetComponent<CameraController>().ResetCamera();

        //show menu
        if (open)
        {
            canvasMainMenu.SetActive(true);
            //disable the camera
            isCameraMove = false;
            GetComponent<CameraController>().ResetZoom();
            open = false;
        }
        else
        {
            canvasMainMenu.SetActive(false);
            //disable the camera
            isCameraMove = true;
            open = true;
        }
        //hide sites
        /*for(int i = 0; i < objSites.Length; i++){
            objSites[i].SetActive(false);
        }*/
    }

    public void ReturnToSite(){
        isCameraMove = true;
    }

    public void OpenMedia(){
        isCameraMove = false;
        GetComponent<CameraController>().ResetZoom();
    }
}
