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

### Prototype:



### Final Screenshots:



### Prototype vs Final Screenshots:

![prototipo 2](https://user-images.githubusercontent.com/81707462/145854130-f6971f6d-e28e-4879-84e0-f8e428d82a83.png)
![prototipo](https://user-images.githubusercontent.com/81707462/145854321-72a765b7-d08f-4695-b35a-b73e09b540f4.png)

## Instructions

To try the app use "npm install" if it's the first time, and "npm start" to run the backend. Don't forget the database.
Then open the frontend in unity or try it in this page https://asoret.itch.io/advanced-reality





