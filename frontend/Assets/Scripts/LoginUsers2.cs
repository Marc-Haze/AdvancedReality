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

public class LoginUsers2 : MonoBehaviour
{
    public static string content;
    public static LoginUsers.OverUserModel contentUser = null;
    public static string access_token = "";
    public static string username = "";
    public static Boolean Dark = false;
    public static LoginUsers.OverUserModel getUser(){ return contentUser; }
    public static void setUser(LoginUsers.OverUserModel user){ contentUser = user; }
    public static string getUsername() { return username; }
    public static void setUsername(string usern) { username = usern; }
    public static Boolean getDark() { return Dark; }
    public static void setDark(Boolean valueDark) { Dark = valueDark; }
    public static string getToken() { return access_token; }


    public GameObject form_login, txt_username, txt_mail, btn_settings, btn_login, btn_logout, login_error,
    form_register, register_error, password_window, password_error, user_settings,
    email_window, email_error, delete_window, main_menu_white, main_menu_black, places;

    void Start()
    {
        closeWindows();
        contentUser=LoginUsers.getUser();
        if(contentUser != null){
            access_token = contentUser.access_token;
        }else{
            access_token = "";
        }
        isLoggedin();
        settingDarkness();
    }

    public void closeWindows()
    {
        form_login.SetActive(false);
        login_error.SetActive(false);
        form_register.SetActive(false);
        register_error.SetActive(false);
        user_settings.SetActive(false);
        password_window.SetActive(false);
        password_error.SetActive(false);
        email_window.SetActive(false);
        email_error.SetActive(false);
        delete_window.SetActive(false);
    }

    public void changePassword()
    {
        StartCoroutine(changePasswordI());
    }
    IEnumerator changePasswordI()
    {
        if (password_window.transform.GetChild(1).GetComponent<InputField>().text == "")
        {
            password_error.SetActive(true);
            password_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Missing the old password";
        }
        else if (password_window.transform.GetChild(1).GetComponent<InputField>().text != contentUser.user.password)
        {
            password_error.SetActive(true);
            password_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Wrong old password";
        }
        else if (password_window.transform.GetChild(2).GetComponent<InputField>().text == "")
        {
            password_error.SetActive(true);
            password_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Enter a new password";
        }
        else if (password_window.transform.GetChild(2).GetComponent<InputField>().text != password_window.transform.GetChild(3).GetComponent<InputField>().text)
        {
            password_error.SetActive(true);
            password_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Passwords don't match";
        }
        else if (password_window.transform.GetChild(2).GetComponent<InputField>().text == contentUser.user.password)
        {
            password_error.SetActive(true);
            password_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "That isn't a new password";
        }
        else
        {
            var userUpdate = new LoginUsers.UserModel();
            userUpdate.id = contentUser.user.id;
            userUpdate.username = contentUser.user.username;
            userUpdate.password = password_window.transform.GetChild(2).GetComponent<InputField>().text;
            userUpdate.mail = contentUser.user.mail;
            userUpdate.isAdmin = contentUser.user.isAdmin;
            userUpdate.darkmode = contentUser.user.darkmode;
            var json = JsonConvert.SerializeObject(userUpdate);
            //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
            UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/users/" + userUpdate.id, byteArray);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + access_token);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            password_window.transform.GetChild(1).GetComponent<InputField>().text = "";
            password_window.transform.GetChild(2).GetComponent<InputField>().text = "";
            password_window.transform.GetChild(3).GetComponent<InputField>().text = "";
            password_error.SetActive(true);
            password_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "The password was changed";
            contentUser.user.password = userUpdate.password;
            userUpdate = null;
        }
    }

    public void changeEmail()
    {
        StartCoroutine(changeEmailI());
    }
    IEnumerator changeEmailI()
    {
        if (email_window.transform.GetChild(2).GetComponent<InputField>().text == "")
        {
            email_error.SetActive(true);
            email_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Enter a new email";
        }
        else if (email_window.transform.GetChild(2).GetComponent<InputField>().text == contentUser.user.mail)
        {
            email_error.SetActive(true);
            email_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "That isn't a new email";
        }
        else
        {
            var userUpdate = new LoginUsers.UserModel();
            userUpdate.id = contentUser.user.id;
            userUpdate.username = contentUser.user.username;
            userUpdate.password = contentUser.user.password;
            userUpdate.mail = email_window.transform.GetChild(2).GetComponent<InputField>().text;
            userUpdate.isAdmin = contentUser.user.isAdmin;
            userUpdate.darkmode = contentUser.user.darkmode;
            var json = JsonConvert.SerializeObject(userUpdate);
            //var updateData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var byteArray = System.Text.Encoding.UTF8.GetBytes(json);
            UnityWebRequest request = UnityWebRequest.Put("http://localhost:4000/api/users/" + userUpdate.id, byteArray);
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + access_token);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            email_window.transform.GetChild(1).GetComponent<InputField>().text = "";
            email_window.transform.GetChild(2).GetComponent<InputField>().text = "";
            email_error.SetActive(true);
            email_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "The email was changed";
            contentUser.user.mail = userUpdate.mail;
            txt_mail.GetComponent<Text>().text = contentUser.user.mail;
            userUpdate = null;
        }
    }

    public void deleteUser()
    {
        StartCoroutine(deleteUserI());
    }
    IEnumerator deleteUserI()
    {
        UnityWebRequest request = UnityWebRequest.Delete("http://localhost:4000/api/users/" + contentUser.user.id);
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + access_token);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        logout();
        closeWindows();
    }
    
    public void login()
    {
        StartCoroutine(loginI());
    }

    IEnumerator loginI()
    {
        if (form_login.transform.GetChild(1).GetComponent<InputField>().text == "")
        {
            login_error.SetActive(true);
            login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "You didn't enter the username";
        }
        else if (form_login.transform.GetChild(2).GetComponent<InputField>().text == "")
        {
            login_error.SetActive(true);
            login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "You didn't enter the password";
        }
        else
        {
            var user = new LoginUsers.UserModel();
            user.username = form_login.transform.GetChild(1).GetComponent<InputField>().text;
            user.password = form_login.transform.GetChild(2).GetComponent<InputField>().text;
            var byteArray = System.Text.Encoding.UTF8.GetBytes($"{user.username}:{user.password}");
            string encodedText = Convert.ToBase64String(byteArray);
            //using var client = new HttpClient();
            UnityWebRequest request = new UnityWebRequest("http://localhost:4000/api/users/signin", "POST");
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            request.SetRequestHeader("Authorization", "Basic " + encodedText);
            yield return request.SendWebRequest();
            //Debug.Log(request.downloadHandler.text);

            /*client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedText);
            client.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));*/

            //HttpResponseMessage response = await client.PostAsync("http://localhost:4000/api/users/signin", null);
            //var responseString = await response.Content.ReadAsStringAsync();

            if (request.downloadHandler.text.StartsWith("{\"user\":{\"id\""))
            {
                login_error.SetActive(false);
                contentUser = JsonConvert.DeserializeObject<LoginUsers.OverUserModel>(request.downloadHandler.text);
                //Debug.Log(contentUser.access_token);
                contentUser.user.password = form_login.transform.GetChild(2).GetComponent<InputField>().text;
                form_login.transform.GetChild(1).GetComponent<InputField>().text = "";
                form_login.transform.GetChild(2).GetComponent<InputField>().text = "";
                form_login.SetActive(false);
                access_token = contentUser.access_token;
                setUser(contentUser);
                isLoggedin();
            }
            else
            {
                login_error.SetActive(true);
                login_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Wrong username or password";
            }
        }
    }

    public void isLoggedin()
    {
        if (access_token != "")
        {
            username = contentUser.user.username;
            txt_username.GetComponent<Text>().text = username;
            txt_mail.GetComponent<Text>().text = contentUser.user.mail;
            email_window.transform.GetChild(1).GetComponent<InputField>().text = txt_mail.GetComponent<Text>().text;
            btn_settings.SetActive(true);
            btn_logout.SetActive(true);
            btn_login.SetActive(false);
            Dark = contentUser.user.darkmode;
            settingDarkness();
        }

    }
    public void logout()
    {
        username = "";
        txt_username.GetComponent<Text>().text = username;
        btn_settings.SetActive(false);
        contentUser = null;
        setUser(contentUser);
        LoginUsers.setUser(contentUser);
        access_token = "";
        closeWindows();
        btn_logout.SetActive(false);
        btn_login.SetActive(true);
    }
    public void register()
    {
        StartCoroutine(registerI());
    }
    IEnumerator registerI()
    {
        if (form_register.transform.GetChild(1).GetComponent<InputField>().text == "")
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "You didn't enter the username";
        }
        else if (form_register.transform.GetChild(2).GetComponent<InputField>().text == "" ||
        form_register.transform.GetChild(3).GetComponent<InputField>().text == "")
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "You didn't enter the password";
        }
        else if (form_register.transform.GetChild(2).GetComponent<InputField>().text !=
       form_register.transform.GetChild(3).GetComponent<InputField>().text)
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Passwords don't match";
        }
        else if (form_register.transform.GetChild(4).GetComponent<InputField>().text == "")
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "You didn't enter the email";
        }
        else if (!form_register.transform.GetChild(4).GetComponent<InputField>().text.Contains("@") ||
       !form_register.transform.GetChild(4).GetComponent<InputField>().text.Contains(".") ||
       form_register.transform.GetChild(4).GetComponent<InputField>().text.Length < 5)
        {
            register_error.SetActive(true);
            register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Enter a valid email";
        }
        else
        {
            var user = new LoginUsers.UserModel();
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
            UnityWebRequest request = UnityWebRequest.Post("http://localhost:4000/api/users", form);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            yield return request.SendWebRequest();
            //Debug.Log(request.downloadHandler.text);

            if (request.downloadHandler.text.StartsWith("{\"user\":{\"id\""))
            {
                register_error.SetActive(false);
                contentUser = JsonConvert.DeserializeObject<LoginUsers.OverUserModel>(request.downloadHandler.text);
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
                register_error.transform.GetChild(0).GetComponent<Image>().transform.GetChild(0).GetComponent<Text>().text = "Something went wrong";
                //Debug.Log("Wrong username or password");
            }
        }
    }

    public void changeDarkness()
    {
        if (Dark)
        {
            if (access_token != "")
            {
                contentUser.user.darkmode = false;
                StartCoroutine(changeDarknessI());

            }
            Dark = false;
            LoginUsers.setDark(Dark);
            settingDarkness();
        }
        else
        {
            if (access_token != "")
            {
                contentUser.user.darkmode = true;
                StartCoroutine(changeDarknessI());

            }
            Dark = true;
            LoginUsers.setDark(Dark);
            settingDarkness();
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
        request.SetRequestHeader("Authorization", "Bearer " + access_token);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        userUpdate = null;
    }

    public void settingDarkness()
    {
        Crud.setDark(Dark);
        var white = new Color32(255, 255, 255, 255);
        var black = new Color32(52, 52, 55, 255);
        if (Dark)
        {
            places.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().color = black;
            places.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = black;
            places.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = black;
            places.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = black;
            main_menu_black.SetActive(true);
            main_menu_white.SetActive(false);
            form_login.transform.GetChild(0).GetComponent<Image>().color = black;
            form_login.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = white;
            form_login.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = white;
            form_login.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().color = white;
            txt_mail.GetComponent<Text>().color = white;
            form_register.transform.GetChild(0).GetComponent<Image>().color = black;
            form_register.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = white;
            form_register.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = white;
            form_register.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().color = white;
            form_register.transform.GetChild(0).transform.GetChild(4).GetComponent<Text>().color = white;
            if (access_token != "")
            {
                user_settings.transform.GetChild(0).GetComponent<Image>().color = black;
                user_settings.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = white;
                user_settings.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().color = white;
                user_settings.transform.GetChild(0).transform.GetChild(5).GetComponent<Text>().color = white;
                password_window.transform.GetChild(0).GetComponent<Image>().color = black;
                password_window.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = white;
                password_window.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = white;
                email_window.transform.GetChild(0).GetComponent<Image>().color = black;
                email_window.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = white;
                email_window.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = white;
                delete_window.transform.GetChild(0).GetComponent<Image>().color = black;
                delete_window.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = white;
            }
        }
        else
        {
            places.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().color = white;
            places.transform.GetChild(1).transform.GetChild(0).GetComponent<Image>().color = white;
            places.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().color = white;
            places.transform.GetChild(3).transform.GetChild(0).GetComponent<Image>().color = white;
            main_menu_black.SetActive(false);
            main_menu_white.SetActive(true);
            form_login.transform.GetChild(0).GetComponent<Image>().color = white;
            form_login.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = black;
            form_login.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = black;
            form_login.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().color = black;
            txt_mail.GetComponent<Text>().color = black;
            form_register.transform.GetChild(0).GetComponent<Image>().color = white;
            form_register.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = black;
            form_register.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = black;
            form_register.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().color = black;
            form_register.transform.GetChild(0).transform.GetChild(4).GetComponent<Text>().color = black;
            if (access_token != "")
            {
                user_settings.transform.GetChild(0).GetComponent<Image>().color = white;
                user_settings.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = black;
                user_settings.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>().color = black;
                user_settings.transform.GetChild(0).transform.GetChild(5).GetComponent<Text>().color = black;
                password_window.transform.GetChild(0).GetComponent<Image>().color = white;
                password_window.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = black;
                password_window.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = black;
                email_window.transform.GetChild(0).GetComponent<Image>().color = white;
                email_window.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = black;
                email_window.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().color = black;
                delete_window.transform.GetChild(0).GetComponent<Image>().color = white;
                delete_window.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().color = black;
            }
        }
    }

    void Update()
    {

    }
}