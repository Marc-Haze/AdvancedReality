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

public class LoginUsers : MonoBehaviour
{

    public class OverUserModel
    {
        public UserModel user { get; set; }
        public string access_token { get; set; }
    }

    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public bool darkmode { get; set; }
        public bool isAdmin { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public static string content;
    public static OverUserModel contentUser;
    public static string access_token = "";
    public static string username = "";
    public static Boolean Dark = false;
    public static string getUsername() { return username; }
    public static void setUsername(string usern) { username = usern; }
    public static Boolean getDark() { return Dark; }
    public static void setDark(Boolean valueDark) { Dark = valueDark; }

    public GameObject form_login, txt_username, btn_login, btn_logout, btn_admin, login_error, form_register, register_error;

    void Start()
    {
        isLoggedin();
    }

    public async void login()
    {
        if (form_login.transform.GetChild(1).GetComponent<InputField>().text == "")
        {
            login_error.SetActive(true);
            login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="You didn't enter the username";
        }
        else if (form_login.transform.GetChild(2).GetComponent<InputField>().text == "")
        {
            login_error.SetActive(true);
            login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="You didn't enter the password";
        }
        else
        {
            var user = new UserModel();
            user.username = form_login.transform.GetChild(1).GetComponent<InputField>().text;
            user.password = form_login.transform.GetChild(2).GetComponent<InputField>().text;
            var byteArray = System.Text.Encoding.UTF8.GetBytes($"{user.username}:{user.password}");
            string encodedText = Convert.ToBase64String(byteArray);
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedText);
            client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/users/signin", null);
            var responseString = await response.Content.ReadAsStringAsync();
            //Debug.Log(responseString);
            if (responseString.StartsWith("{\"user\":{\"id\"")){
                login_error.SetActive(false);
                contentUser = JsonConvert.DeserializeObject<OverUserModel>(responseString);
                Debug.Log(contentUser.access_token);
                form_login.transform.GetChild(1).GetComponent<InputField>().text = "";
                form_login.transform.GetChild(2).GetComponent<InputField>().text = "";
                form_login.SetActive(false);
                access_token = contentUser.access_token;
                isLoggedin();
            }
            else
            {
                login_error.SetActive(true);
                login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="Wrong username or password";
                Debug.Log("Wrong username or password");
            }
        }
    }

    public void isLoggedin()
    {
        if (access_token != "")
        {
            username=contentUser.user.username;
            txt_username.GetComponent<Text>().text = username;
            btn_logout.SetActive(true);
            btn_login.SetActive(false);
            if(contentUser.user.isAdmin){
                btn_admin.SetActive(true);
            }
        }
        
    }
    public void logout()
    {
        username="";
        txt_username.GetComponent<Text>().text = username;
        contentUser = null;
        access_token = "";
        btn_logout.SetActive(false);
        btn_admin.SetActive(false);
        btn_login.SetActive(true);
    }

    public async void register()
    {
        if (form_register.transform.GetChild(1).GetComponent<InputField>().text == "")
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="You didn't enter the username";
        }
        else if (form_register.transform.GetChild(2).GetComponent<InputField>().text == "" || 
        form_register.transform.GetChild(3).GetComponent<InputField>().text == "")
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="You didn't enter the password";
        }else if(form_register.transform.GetChild(2).GetComponent<InputField>().text != 
        form_register.transform.GetChild(3).GetComponent<InputField>().text){
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="Passwords don't match";
        }else if(form_register.transform.GetChild(4).GetComponent<InputField>().text == ""){
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="You didn't enter the email";
        }else if(!form_register.transform.GetChild(4).GetComponent<InputField>().text.Contains("@")||
        !form_register.transform.GetChild(4).GetComponent<InputField>().text.Contains(".") ||
        form_register.transform.GetChild(4).GetComponent<InputField>().text.Length<5){
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="Enter a valid email";
        }else{
            var user = new UserModel();
            user.username = form_register.transform.GetChild(1).GetComponent<InputField>().text;
            user.password = form_register.transform.GetChild(2).GetComponent<InputField>().text;
            user.mail = form_register.transform.GetChild(4).GetComponent<InputField>().text;
            var byteArray = System.Text.Encoding.UTF8.GetBytes($"{user.username}:{user.password}");
            string encodedText = Convert.ToBase64String(byteArray);
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedText);
            client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/users", data);
            var responseString = await response.Content.ReadAsStringAsync();
            Debug.Log(responseString);
            if (responseString.StartsWith("{\"user\":{\"id\"")){
                register_error.SetActive(false);
                contentUser = JsonConvert.DeserializeObject<OverUserModel>(responseString);
                Debug.Log(contentUser.access_token);
                form_register.transform.GetChild(1).GetComponent<InputField>().text = "";
                form_register.transform.GetChild(2).GetComponent<InputField>().text = "";
                form_register.SetActive(false);
                access_token = contentUser.access_token;
                isLoggedin();
            }
            else
            {
                register_error.SetActive(true);
                register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="Wrong username or password";
                Debug.Log("Wrong username or password");
            }
        }
    }



    /*
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
    void Update()
    {

    }
}