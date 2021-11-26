using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine.Networking;
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

    public class TextModel{
        public int id { get; set; }
        public string content { get; set; }
        public string mail { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int? userId { get; set; }
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
    public static string getToken() { return access_token; }


    public GameObject form_login, txt_username, btn_settings, btn_login, btn_logout, btn_admin, login_error, 
    form_register, register_error, contact_window , contact2_window, contact_success;

    void Start()
    {
        closeWindows();
        isLoggedin();
    }

    public void closeWindows(){
        form_login.SetActive(false);
        login_error.SetActive(false);
        form_register.SetActive(false);
        register_error.SetActive(false);
        contact_window.SetActive(false);
        contact2_window.SetActive(false);
        contact_success.SetActive(false);
    }

    public void contact(){
        if (access_token != "")
        {
            contact2_window.SetActive(true);
        }else{
            contact_window.SetActive(true);
        }
    }

    public void sendMessage(){
        StartCoroutine(sendMessageI());
    }
    IEnumerator sendMessageI(){
        if (contact2_window.transform.GetChild(1).GetComponent<InputField>().text == "")
        {
            contact_success.SetActive(true);
            contact_success.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="You didn't write anything";
        }else{
            var text = new TextModel();
            text.content = contact2_window.transform.GetChild(1).GetComponent<InputField>().text;
            text.mail = contentUser.user.mail;
            text.userId = contentUser.user.id;
            WWWForm form = new WWWForm();
            form.AddField("content", text.content);
            form.AddField("mail", text.mail);
            form.AddField("userId", text.userId.ToString());
            /*using var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/texts", data);*/
            UnityWebRequest request=UnityWebRequest.Post("http://localhost:4000/api/texts",form);
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            //Debug.Log(request.downloadHandler.text);

            contact2_window.transform.GetChild(1).GetComponent<InputField>().text = "";

            contact_success.SetActive(true);
            contact_success.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="The message was sent!";
        }
        
    }
    public void login(){
        StartCoroutine(loginI());
    }

    IEnumerator loginI()
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
            //using var client = new HttpClient();
            UnityWebRequest request=new UnityWebRequest("http://localhost:4000/api/users/signin","POST");
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            request.SetRequestHeader("Authorization", "Basic " + encodedText);
            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);

            /*client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedText);
            client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));*/
           
            //HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/users/signin", null);
            //var responseString = await response.Content.ReadAsStringAsync();

            if (request.downloadHandler.text.StartsWith("{\"user\":{\"id\"")){
                login_error.SetActive(false);
                contentUser = JsonConvert.DeserializeObject<OverUserModel>(request.downloadHandler.text);
                //Debug.Log(contentUser.access_token);
                form_login.transform.GetChild(1).GetComponent<InputField>().text = "";
                form_login.transform.GetChild(2).GetComponent<InputField>().text = "";
                form_login.SetActive(false);
                access_token = contentUser.access_token;
                isLoggedin();
                Debug.Log(access_token);
            }
            else
            {
                login_error.SetActive(true);
                login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="Wrong username or password";
            }
        }
    }

    public void isLoggedin()
    {
        if (access_token != "")
        {
            username=contentUser.user.username;
            txt_username.GetComponent<Text>().text = username;
            btn_settings.SetActive(true);
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
        btn_settings.SetActive(false);
        contentUser = null;
        access_token = "";
        closeWindows();
        btn_logout.SetActive(false);
        btn_admin.SetActive(false);
        btn_login.SetActive(true);
    }
    public void register(){
        StartCoroutine(registerI());
    }
    IEnumerator registerI()
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
            WWWForm form = new WWWForm();
            form.AddField("username", user.username);
            form.AddField("password", user.password);
            form.AddField("mail", user.mail);
            /*var byteArray = System.Text.Encoding.UTF8.GetBytes($"{user.username}:{user.password}");
            string encodedText = Convert.ToBase64String(byteArray);
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedText);
            client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/users", data);ç
            var responseString = await response.Content.ReadAsStringAsync();*/
            //Debug.Log(responseString);
            UnityWebRequest request=UnityWebRequest.Post("http://localhost:4000/api/users",form);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return request.SendWebRequest();
            //Debug.Log(request.downloadHandler.text);

            if (request.downloadHandler.text.StartsWith("{\"user\":{\"id\"")){
                register_error.SetActive(false);
                contentUser = JsonConvert.DeserializeObject<OverUserModel>(request.downloadHandler.text);
                //Debug.Log(contentUser.access_token);
                form_register.transform.GetChild(1).GetComponent<InputField>().text = "";
                form_register.transform.GetChild(2).GetComponent<InputField>().text = "";
                form_register.SetActive(false);
                access_token = contentUser.access_token;
                isLoggedin();
            }
            else
            {
                register_error.SetActive(true);
                register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text="Something went wrong";
                //Debug.Log("Wrong username or password");
            }
        }
    }
    void Update()
    {

    }
}