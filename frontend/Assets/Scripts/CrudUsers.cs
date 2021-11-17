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

public class CrudUsers : MonoBehaviour
{

    public class UserModel
    {
        public int id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public byte isAdmin { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public static string content;
    public static List<UserModel> contentArray;
    public static string idUpdate;
    public static string idDelete;

    public static Boolean Dark=false;

    public static Boolean getDark(){ return Dark; }
    public static void setDark(Boolean valueDark){ Dark=valueDark; }

    public GameObject itemParent, item, form_create, form_update, background, bkg_create, bkg_update, bkg_delete, txt_delete;

    void Start()
    {
        read();
    }

    public async void read(){
        if (Dark){
            /*background.GetComponent<Image>().color = new Color32(52,52,55,255);
            bkg_create.GetComponent<Image>().color = new Color32(52,52,55,255);
            bkg_update.GetComponent<Image>().color = new Color32(52,52,55,255);
            bkg_delete.GetComponent<Image>().color = new Color32(52,52,55,255);
            txt_delete.GetComponent<Text>().color = Color.white;

            for (int i = 0; i < itemParent.transform.childCount; i++){
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            using var client = new HttpClient();
            content = await client.GetStringAsync("http://localhost:4000/api/users");
            contentArray = JsonConvert.DeserializeObject<List<UserModel>>(content);
            foreach (UserModel model in contentArray){
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.name;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.fileName;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.description;
            }*/
        }else{
            /*
            background.GetComponent<Image>().color = new Color32(255,255,255,255);
            bkg_create.GetComponent<Image>().color = new Color32(255,255,255,255);
            bkg_update.GetComponent<Image>().color = new Color32(255,255,255,255);
            bkg_delete.GetComponent<Image>().color = new Color32(255,255,255,255);
            txt_delete.GetComponent<Text>().color = Color.black;*/
       
            for (int i = 0; i < itemParent.transform.childCount; i++){
                Destroy(itemParent.transform.GetChild(i).gameObject);
            }
            using var client = new HttpClient();
            content = await client.GetStringAsync("http://localhost:4000/api/users");
            contentArray = JsonConvert.DeserializeObject<List<UserModel>>(content);
            foreach (UserModel model in contentArray){
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.password;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.name;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.username;
            }
        }
    }

    public void changeDarkness(){
        if(Dark){
            Dark=false;
            read();
        }else{
            Dark=true;
            read();
        }
    }
/*
    public async void create(){
        var image = new ImageModel();
        image.name = form_create.transform.GetChild(1).GetComponent<InputField>().text;
        image.fileName = form_create.transform.GetChild(2).GetComponent<InputField>().text;
        image.description = form_create.transform.GetChild(3).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(image);
        var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/images", data);
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(3).GetComponent<InputField>().text = "";
        read();
    }

    public void get_id_delete(GameObject obj_delete){
        idDelete = obj_delete.transform.GetChild(0).GetComponent<Text>().text;
    }

    public async void delete(GameObject item){
        using var client = new HttpClient();
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:4000/api/images/" + idDelete);
        read();
    }

    string id_update;

    public void open_form_update(GameObject obj_update){
        form_update.SetActive(true);
        form_update.transform.GetChild(1).GetComponent<InputField>().text = obj_update.transform.GetChild(1).GetComponent<Text>().text;
        form_update.transform.GetChild(2).GetComponent<InputField>().text = obj_update.transform.GetChild(2).GetComponent<Text>().text;
        form_update.transform.GetChild(3).GetComponent<InputField>().text = obj_update.transform.GetChild(3).GetComponent<Text>().text;
        idUpdate = obj_update.transform.GetChild(0).GetComponent<Text>().text;
    }

    public async void update(){
        var imageUpdate = new ImageModel();
        imageUpdate.id = int.Parse(idUpdate);
        imageUpdate.name = form_update.transform.GetChild(1).GetComponent<InputField>().text;
        imageUpdate.fileName = form_update.transform.GetChild(2).GetComponent<InputField>().text;
        imageUpdate.description = form_update.transform.GetChild(3).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(imageUpdate);
        var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        using var client = new HttpClient();
        HttpResponseMessage response = await client.PutAsync("http://localhost:4000/api/images/" + idUpdate, updateData);
        read();
    }*/

    // Update is called once per frame
    void Update(){

    }
}
