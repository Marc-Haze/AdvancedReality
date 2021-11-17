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

public class CrudMessages : MonoBehaviour
{

    public class TextModel{
        public int id { get; set; }
        public string content { get; set; }
        public string mail { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int? userId { get; set; }
    }

    public static string content;
    public static List<TextModel> contentArray;
    public static string idUpdate;
    public static string idDelete;

    public static Boolean Dark = false;

    public GameObject itemParent, item, form_create, form_update, background, bkg_create, bkg_update, bkg_delete, txt_delete, txt_username;

    void Start(){
        txt_username.GetComponent<Text>().text = LoginUsers.getUsername();
        Dark=Crud.getDark();
        read();
    }

    public async void read(){
        if (Dark){
            background.GetComponent<Image>().color = new Color32(52,52,55,255);
            bkg_create.GetComponent<Image>().color = new Color32(52,52,55,255);
            bkg_update.GetComponent<Image>().color = new Color32(52,52,55,255);
            bkg_delete.GetComponent<Image>().color = new Color32(52,52,55,255);
            txt_delete.GetComponent<Text>().color = Color.white;

            for (int i = 0; i < itemParent.transform.childCount; i++){
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            using var client = new HttpClient();
            content = await client.GetStringAsync("http://localhost:4000/api/texts");
            contentArray = JsonConvert.DeserializeObject<List<TextModel>>(content);
            foreach (TextModel model in contentArray){
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.content;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.mail;
            }
        }else{
            background.GetComponent<Image>().color = new Color32(255,255,255,255);
            bkg_create.GetComponent<Image>().color = new Color32(255,255,255,255);
            bkg_update.GetComponent<Image>().color = new Color32(255,255,255,255);
            bkg_delete.GetComponent<Image>().color = new Color32(255,255,255,255);
            txt_delete.GetComponent<Text>().color = Color.black;

            for (int i = 0; i < itemParent.transform.childCount; i++){
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            using var client = new HttpClient();
            content = await client.GetStringAsync("http://localhost:4000/api/texts");
            contentArray = JsonConvert.DeserializeObject<List<TextModel>>(content);
            foreach (TextModel model in contentArray){
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.content;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.mail;
            }
        }
    }

    public void changeDarkness(){
        if(Dark){
            Dark=false;
            Crud.setDark(Dark);
            read();
        }else{
            Dark=true;
            Crud.setDark(Dark);
            read();
        }
    }

    public async void create(){
        var text = new TextModel();
        text.content = form_create.transform.GetChild(1).GetComponent<InputField>().text;
        text.mail = form_create.transform.GetChild(2).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(text);
        var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/texts", data);
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
        read();
        Debug.Log("done");
    }

    public void get_id_delete(GameObject obj_delete){
        idDelete = obj_delete.transform.GetChild(0).GetComponent<Text>().text;
    }

    public async void delete(GameObject item){
        using var client = new HttpClient();
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:4000/api/texts/" + idDelete);
        read();
    }

    string id_update;

    public void open_form_update(GameObject obj_update){
        form_update.SetActive(true);
        form_update.transform.GetChild(1).GetComponent<InputField>().text = obj_update.transform.GetChild(1).GetComponent<Text>().text;
        form_update.transform.GetChild(2).GetComponent<InputField>().text = obj_update.transform.GetChild(2).GetComponent<Text>().text;
        idUpdate = obj_update.transform.GetChild(0).GetComponent<Text>().text;
    }

    public async void update(){
        var textUpdate = new TextModel();
        textUpdate.id = int.Parse(idUpdate);
        textUpdate.content = form_update.transform.GetChild(1).GetComponent<InputField>().text;
        textUpdate.mail = form_update.transform.GetChild(2).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(textUpdate);
        var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        using var client = new HttpClient();
        HttpResponseMessage response = await client.PutAsync("http://localhost:4000/api/texts/" + idUpdate, updateData);
        read();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
