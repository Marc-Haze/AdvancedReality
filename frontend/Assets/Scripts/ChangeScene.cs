// Start is called before the first frame update
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;
public class ChangeScene : MonoBehaviour
{
    public void changeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void lightFont(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.white;
    }
    public void darkFont(PointerEventData eventData)
    {
        GetComponent<Text>().color = Color.black;
    }

    //private int lastWidth= 0;
    //private int lastHeight= 0;
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        var width = Screen.width;
        var height = Screen.height;

        if (lastWidth != width) // if the user is changing the width
        {
            // update the height
            double heightAccordingToWidth = width / 16.0 * 9.0;
            Screen.SetResolution(width, (int)Math.Ceiling(heightAccordingToWidth), false, 0);
        }
        else if (lastHeight != height) // if the user is changing the height
        {
            // update the width
            double widthAccordingToHeight = height / 9.0 * 16.0;
            Screen.SetResolution((int)Math.Ceiling(widthAccordingToHeight), height, false, 0);
        }

        lastWidth = width;
        lastHeight = height;
        */
    }
}
