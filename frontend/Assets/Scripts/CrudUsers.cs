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

public class CrudUsers : MonoBehaviour
{
    public class SendToken
    {
        public string token { get; set; }
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
    public static List<UserModel> contentArray;
    public static string idUpdate;
    public static string idDelete;

    public static LoginUsers.OverUserModel contentUser = null;
    public static LoginUsers.OverUserModel getUser(){ return contentUser; }
    public static void setUser(LoginUsers.OverUserModel user){ contentUser = user; }

    public static Boolean Dark = false;

    public static Boolean getDark() { return Dark; }
    public static void setDark(Boolean valueDark) { Dark = valueDark; }

    public GameObject itemParent, item, form_create, form_update, background, bkg_create, bkg_update, bkg_delete, txt_delete, txt_username;

    void Start()
    {
        txt_username.GetComponent<Text>().text = LoginUsers.getUsername();
        contentUser = LoginUsers.getUser();
        Dark = Crud.getDark();
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
            var sendToken = new SendToken();
            sendToken.token = LoginUsers.getToken();
            //Debug.Log(sendToken.token);
            /*using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sendToken.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("http://localhost:4000/api/users");
            var responseString = await response.Content.ReadAsStringAsync();*/
            //Debug.Log(responseString);
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/users", "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Authorization", "Bearer " + sendToken.token);
            yield return request.SendWebRequest();
            contentArray = JsonConvert.DeserializeObject<List<UserModel>>(request.downloadHandler.text);
            foreach (UserModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.username;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.password;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.mail;
                tmp_item.transform.GetChild(4).GetComponent<Text>().color = Color.white;
                tmp_item.transform.GetChild(4).GetComponent<Text>().text = model.darkmode.ToString();
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
            var sendToken = new SendToken();
            sendToken.token = LoginUsers.getToken();
            //Debug.Log(sendToken.token);
            /*using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sendToken.token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("http://localhost:4000/api/users");
            var responseString = await response.Content.ReadAsStringAsync();*/
            //Debug.Log(responseString);
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/users", "GET");
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Authorization", "Bearer " + sendToken.token);
            yield return request.SendWebRequest();
            contentArray = JsonConvert.DeserializeObject<List<UserModel>>(request.downloadHandler.text);
            foreach (UserModel model in contentArray)
            {
                GameObject tmp_item = Instantiate(item, itemParent.transform);
                tmp_item.transform.GetChild(0).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(0).GetComponent<Text>().text = model.id.ToString();
                tmp_item.transform.GetChild(1).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(1).GetComponent<Text>().text = model.username;
                tmp_item.transform.GetChild(2).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(2).GetComponent<Text>().text = model.password;
                tmp_item.transform.GetChild(3).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(3).GetComponent<Text>().text = model.mail;
                tmp_item.transform.GetChild(4).GetComponent<Text>().color = Color.black;
                tmp_item.transform.GetChild(4).GetComponent<Text>().text = model.darkmode.ToString();
            }
        }
    }

    public void changeDarkness()
    {
        if (Dark)
        {
            contentUser.user.darkmode = false;
            StartCoroutine(changeDarknessI());
            Dark = false;
            Crud.setDark(Dark);
            LoginUsers.setDark(Dark);
            LoginUsers2.setDark(Dark);
            read();
        }
        else
        {
            contentUser.user.darkmode = true;
            StartCoroutine(changeDarknessI());
            Dark = true;
            Crud.setDark(Dark);
            LoginUsers.setDark(Dark);
            LoginUsers2.setDark(Dark);
            read();
        }
    }

    IEnumerator changeDarknessI()
    {
        var userUpdate = new LoginUsers.UserModel();
        userUpdate.id = contentUser.user.id;
        userUpdate.username = contentUser.user.username;
        userUpdate.password = contentUser.user.password;
        userUpdate.mail = contentUser.user.mail;
        userUpdate.isAdmin = contentUser.user.isAdmin;
        userUpdate.darkmode = contentUser.user.darkmode;
        var json = JsonConvert.SerializeObject(userUpdate);
        //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/users/" + userUpdate.id, byteArray);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + contentUser.access_token);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        userUpdate = null;
    }

    public void create()
    {
        StartCoroutine(createI());
    }
    IEnumerator createI()
    {
        var sendToken = new SendToken();
        sendToken.token = LoginUsers.getToken();
        var user = new UserModel();
        user.username = form_create.transform.GetChild(1).GetComponent<InputField>().text;
        user.password = form_create.transform.GetChild(2).GetComponent<InputField>().text;
        user.mail = form_create.transform.GetChild(3).GetComponent<InputField>().text;
        WWWForm form = new WWWForm();
        form.AddField("username", user.username);
        form.AddField("password", user.password);
        form.AddField("mail", user.mail);
        UnityWebRequest request = UnityWebRequest.Post("http://localhost:4000/api/users", form);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);

        /*var byteArray = System.Text.Encoding.UTF8.GetBytes($"{user.username}:{user.password}");
        string encodedText = Convert.ToBase64String(byteArray);
        var json = JsonConvert.SerializeObject(user);
        var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedText);
        client.DefaultRequestHeaders
        .Accept
        .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/users", data);
        var responseString = await response.Content.ReadAsStringAsync();*/
        //Debug.Log(responseString);
        form_create.transform.GetChild(1).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(2).GetComponent<InputField>().text = "";
        form_create.transform.GetChild(3).GetComponent<InputField>().text = "";
        read();
    }

    public void get_id_delete(GameObject obj_delete)
    {
        idDelete = obj_delete.transform.GetChild(0).GetComponent<Text>().text;
    }
    public void delete(){
        StartCoroutine(deleteI());
    }
    IEnumerator deleteI()
    {
        var sendToken = new SendToken();
        sendToken.token = LoginUsers.getToken();
        UnityWebRequest request=UnityWebRequest.Delete("http://localhost:4000/api/users/" + idDelete);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + sendToken.token);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        /*using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sendToken.token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.DeleteAsync("http://localhost:4000/api/users/" + idDelete);*/
        read();
    }

    string id_update;

    public void open_form_update(GameObject obj_update)
    {
        form_update.SetActive(true);
        form_update.transform.GetChild(1).GetComponent<InputField>().text = obj_update.transform.GetChild(1).GetComponent<Text>().text;
        form_update.transform.GetChild(2).GetComponent<InputField>().text = "new";
        form_update.transform.GetChild(3).GetComponent<InputField>().text = obj_update.transform.GetChild(3).GetComponent<Text>().text;
        idUpdate = obj_update.transform.GetChild(0).GetComponent<Text>().text;
    }
    public void update(){
        StartCoroutine(updateI());
    }
    IEnumerator updateI()
    {
        var sendToken = new SendToken();
        sendToken.token = LoginUsers.getToken();
        var userUpdate = new UserModel();
        userUpdate.id = int.Parse(idUpdate);
        userUpdate.username = form_update.transform.GetChild(1).GetComponent<InputField>().text;
        userUpdate.password = form_update.transform.GetChild(2).GetComponent<InputField>().text;
        userUpdate.mail = form_update.transform.GetChild(3).GetComponent<InputField>().text;
        var json = JsonConvert.SerializeObject(userUpdate);
        //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
        UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/users/"+idUpdate,byteArray);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + sendToken.token);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        /*using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sendToken.token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.PutAsync("http://localhost:4000/api/users/" + idUpdate, updateData);*/
        read();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
