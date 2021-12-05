using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourManager : MonoBehaviour
{
    //List of sites
    public GameObject[] objSites;
    //main menu
    public GameObject canvasMainMenu;
    //Should camera move
    public bool isCameraMove = false;
    public bool open = true; public bool firstload = false;

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
}
