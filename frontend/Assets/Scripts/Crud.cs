using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class Crud : MonoBehaviour
{

    public class ImageModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fileName { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public static string content;
    public static List<ImageModel> contentArray;
    public static string idUpdate;
    public static string idDelete;

    public static Boolean Dark = false;

    public static Boolean getDark() { return Dark; }
    public static void setDark(Boolean valueDark) { Dark = valueDark; }

    public GameObject itemParent, item, form_create, form_update, background, bkg_create, bkg_update, bkg_delete, txt_delete, txt_username;

    void Start()
    {
        txt_username.GetComponent<Text>().text = LoginUsers.getUsername();
        read();
    }

    public void read()
    {
        StartCoroutine(readI());
    }

    IEnumerator readI()
    {
        if (Dark)
        {
            background.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            bkg_create.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            bkg_update.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            bkg_delete.GetComponent<Image>().color = new Color32(52, 52, 55, 255);
            txt_delete.GetComponent<Text>().color = Color.white;

            for (int i = 0; i < itemParent.transform.childCount; i++)
            {
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            //using var client = new HttpClient();
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/images", "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            //content = await client.GetStringAsync("http://localhost:4000/api/images");
            contentArray = JsonConvert.DeserializeObject<List<ImageModel>>(request.downloadHandler.text);
            foreach (ImageModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.name;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.fileName;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.description;
            }
        }
        else
        {
            background.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            bkg_create.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            bkg_update.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            bkg_delete.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            txt_delete.GetComponent<Text>().color = Color.black;

            for (int i = 0; i < itemParent.transform.childCount; i++)
            {
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            //using var client = new HttpClient();
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/images", "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            //content = await client.GetStringAsync("http://localhost:4000/api/images");
            contentArray = JsonConvert.DeserializeObject<List<ImageModel>>(request.downloadHandler.text);
            foreach (ImageModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.name;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.fileName;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.description;
            }
        }
    }

    public void changeDarkness()
    {
        if (Dark)
        {
            Dark = false;
            read();
        }
        else
        {
            Dark = true;
            read();
        }
    }

    public void create()
    {
        StartCoroutine(createI());
    }

    IEnumerator createI()
    {
        var image = new ImageModel();
        image.name = form_create.transform.GetChild(1).GetComponent<InputField>().text;
        image.fileName = form_create.transform.GetChild(2).GetComponent<InputField>().text;
        image.description = form_create.transform.GetChild(3).GetComponent<InputField>().text;
        WWWForm form = new WWWForm();
        form.AddField("name", image.name);
        form.AddField("fileName", image.fileName);
        form.AddField("description", image.description);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:4000/api/images",form);
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        //Debug.Log(request.downloadHandler.text);
        /*var json = JsonConvert.SerializeObject(image);
        var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/images", data);*/
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(3).GetComponent<InputField>().text = "";
        read();
    }

    public void get_id_delete(GameObject obj_delete)
    {
        idDelete = obj_delete.transform.GetChild(0).GetComponent<Text>().text;
    }

    public void delete()
    {
        StartCoroutine(deleteI());
    }
    IEnumerator deleteI(){
        /*using var client = new HttpClient();
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:4000/api/images/" + idDelete);*/
        UnityWebRequest request=UnityWebRequest.Delete("http://localhost:4000/api/images/" + idDelete);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        read();
    }

    string id_update;

    public void open_form_update(GameObject obj_update)
    {
        form_update.SetActive(true);
        form_update.transform.GetChild(1).GetComponent<InputField>().text = obj_update.transform.GetChild(1).GetComponent<Text>().text;
        form_update.transform.GetChild(2).GetComponent<InputField>().text = obj_update.transform.GetChild(2).GetComponent<Text>().text;
        form_update.transform.GetChild(3).GetComponent<InputField>().text = obj_update.transform.GetChild(3).GetComponent<Text>().text;
        idUpdate = obj_update.transform.GetChild(0).GetComponent<Text>().text;
    }

    public void update()
    {
        StartCoroutine(updateI());
    }

    IEnumerator updateI(){
        var imageUpdate = new ImageModel();
        imageUpdate.id = int.Parse(idUpdate);
        imageUpdate.name = form_update.transform.GetChild(1).GetComponent<InputField>().text;
        imageUpdate.fileName = form_update.transform.GetChild(2).GetComponent<InputField>().text;
        imageUpdate.description = form_update.transform.GetChild(3).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(imageUpdate);
        //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/images/"+idUpdate,byteArray);
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        /*using var client = new HttpClient();
        HttpResponseMessage response = await client.PutAsync("http://localhost:4000/api/images/" + idUpdate, updateData);*/
        read();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
