# AdvancedReality
Virtual reality project with nodejs and unity.

![image](https://user-images.githubusercontent.com/81707462/141654892-327c44ef-7191-4d8a-b430-6216b25f9c03.png)

## Description:

In the future I have to make a virtual reality tour about Galdar's technologyc park, so I made this as a practise. This is for
the company ITC(Instituto tecnológico de canarias), and the interesting part its adding to the apps they make a crud with sql.

So the app will be a webpage which lets you watch some photos and 360 spaces of Lanzarote, with users that can register, login, make
comments, and send messages to the staff. With other pleasant extras like the dark mode and user configuration. I have no idea about
unity at the start of this project but the idea is learning to be ready for the next one.

## Database models:

The first table is used for the login and register, of the users, also for the admins with the attribute "isAdmin", because the admin
and the users can do things than the guests that doesn't log in. The user writes texts and reviews, so they are related, in the texts
we save the user email apart from the id to know where to answer if needed, and in the reviews we save the username to show it in the
reviews view, so other users can see it. Finally everyone can watch the images, they have an attribute called place to represent in which
360 image they are allowed to be seen.

I will make it with XAMPP MySql.

### E/R Model:

![image](https://user-images.githubusercontent.com/81707462/145824780-522d8d45-c965-4ec5-9db3-066aa0b63d78.png)


## User requirements:

R1. Platform

    R1.1. The app will be a web page
  
R2. Is going to be mostly what they do normally, but adding sql management

R3. The users don't need to log in or register to access the app, but they will have less options

R4. The app has a main menu, from there you can access to some options and one to go to the virtual reality

    R4.1. Everyone can toggle the dark mode
    R4.1.1. Only the admins can access the full crud
    R4.1.2. If a user logs in, the dak mode value will be loaded, and it can be saved for future uses
    R4.1.3. The users can change their own email and password, only knowing the old one
    R4.1.4. The users can also erase their own account if they need it
    R4.1.5. A screen will pop up to ask again if they are sure about erasing it
    R4.2. The users can write and send a message to the staff if they are logged in
  
R5. The app has a virtual reality, in which the users can view all what the app mainly supplies

    R5.1. Still everyone can toggle the dark mode
    R5.1.1. Everyone can watch the images and reviews
    R5.1.2. But only the users can write reviews
    R5.1.3. There will be some hot spots which the users can click and read some information
  
## Cases of use:

Like I said before, guests can watch reviews and images, but you need to be a logged in user to write reviews and messages. Only admins
can manage and watch all the tables.

### UML Model:

![image](https://user-images.githubusercontent.com/81707462/145825355-704f1baa-0291-4c36-abdf-1e7c1b6ec3ac.png)

## Description of the operation of the system and technical specifications:

The frontend made in unity which you can run as a webpage, uses a nodejs backend to manage and connect to the sql database. 

Depending in the way you run the page you may need internet connection or not, In the way I show you will need it. Because it is
a web page which lets you upload and host your unity webgl build.

## Interfaces

### Design

#### Prototype:

![mockup](https://user-images.githubusercontent.com/81707462/146037980-c12dfc18-e2d7-40dd-939b-73867237b529.png)

#### Final Screenshots:

![mockup 2](https://user-images.githubusercontent.com/81707462/146038344-5bec549c-89e3-4a3d-b44f-d293e8c26faf.png)

#### Prototype vs Final Screenshots:

![prototipo 2](https://user-images.githubusercontent.com/81707462/145854130-f6971f6d-e28e-4879-84e0-f8e428d82a83.png)
![prototipo](https://user-images.githubusercontent.com/81707462/145854321-72a765b7-d08f-4695-b35a-b73e09b540f4.png)

### Usability:

After making the app now I will show some of the usability I added.

1-The app is so colorful, with the 3 colors that I repeat in the diferent pages of the project (yellow blue and orange) as
you can see:

![image](https://user-images.githubusercontent.com/81707462/146040605-7bb2b6b0-9794-402f-b9be-cc5c6026c1e5.png)

2-The options are intuitive, you can see the buttons clearly without overwhelming the most basic user, as you can see here, in the view with the most
available options, its easy to guess what you could find there.

![image](https://user-images.githubusercontent.com/81707462/146041341-91c27d95-9aea-416a-825e-65816342b3d3.png)

3-The guests are advised to make an account if they want to use the whole usage of the app, they are informed about it.

![image](https://user-images.githubusercontent.com/81707462/146042728-05d8cb82-9b87-4c66-a696-31325f9e4b9f.png)

4-When the user starts to register, they will receive advices of what they are doing wrong.

![image](https://user-images.githubusercontent.com/81707462/146048091-a37c777e-735c-47a7-8718-3ea82ec217f2.png)

5-The app shows that the user is logged in, by changing the log in button, and showing the username of the user connected.

![image](https://user-images.githubusercontent.com/81707462/146048601-535c6f11-3aa6-4888-a4a5-e6b309ef7efa.png)

6-Other time when he tries the log in again, he will be informed of the mistakes, included if the user and password don't match

![image](https://user-images.githubusercontent.com/81707462/146048897-b8d4b025-5b60-4cd9-95cb-e518fb793337.png)

7-While logged in, the app gives some configuration to the user, by letting him change the email and password.

![image](https://user-images.githubusercontent.com/81707462/146050095-dbc3b9c2-e283-4cf7-99fa-c934212917c1.png)

8-Also deleting his account with a second chance to cancel it. Also for the admins when deleting data in the tables.

![image](https://user-images.githubusercontent.com/81707462/146050239-670ac7de-275b-4a6d-b536-9eb92b663878.png)

9-Guests can toggle the darkmode, but only users can save the prefered option, it loads automatically when logging in. This
changes are visible in all the pages.

![image](https://user-images.githubusercontent.com/81707462/146051202-ec2a1a06-b574-4a5c-b076-28945ad5ffe1.png)

10-The users can send a message to staff, with some advices to notice the errors, and when it's successfully sent.

![image](https://user-images.githubusercontent.com/81707462/146051705-349cfc2a-ed43-4f49-aeb2-2eacedaacd50.png)

11-The virtual reality has a comfortable menu, you can open and close it with just one key. Which is shown to the users, also
the hotspots and arrows to travel to other places have the right size and colors to be seen.

![image](https://user-images.githubusercontent.com/81707462/146052053-9741b0fe-08c7-4b13-a827-3fb08db99d5a.png)




## Instructions

To try the app use "npm install" if it's the first time, and "npm start" to run the backend. Don't forget the database.
Then open the frontend in unity or try it in this page https://asoret.itch.io/advanced-reality





