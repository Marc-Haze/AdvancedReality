// Start is called before the first frame update
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems;
public class ChangeScene : MonoBehaviour{
    public void changeScene(string scenename){
        if(scenename=="MainPage"){
            SceneManager.LoadScene(scenename);
            HideAfterSeconds.setViewing(true);
        }else{
            SceneManager.LoadScene(scenename);
            HideAfterSeconds.setViewing(false);
        }
        
    }
    public void lightFont(PointerEventData eventData) {
          GetComponent<Text>().color = Color.white; 
    }
 
    public void darkFont(PointerEventData eventData) {
          GetComponent<Text>().color = Color.black; 
    }
    public void wait(){
        Invoke("notihng", 3);
    }
}
