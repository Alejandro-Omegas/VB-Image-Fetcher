# VB-Image-Fetcher

Just a small Windows GUI program that stores in a table (MySQL) names and their corresponding URLs for an image, and it can fetch the image from the URL stored and display it on the GUI.

I originally made this just for fun, looking to interact with a DB and fetch images from the Internet with Visual Basic. The original idea was fetching images of female characters I like (this is why the naming of some of the components), but technically, it can fetch any image.

Because I did not touch Visual Basic in quite some time, I got assistance from both ChatGPT and DeepSeek to refresh my memory, learn some stuff and troubleshooting. An interesting thing with these two AI's is the way their examples fetch images and check if the URL belongs to an image:
- ChatGPT provides examples with the deprecated WebClient and the example for checking the URL does not work.
- DeepSeek, on the other hand, provides a more modern approach with HttpClient and its checking actually works. I implemented this solution on the second Windows form where you can insert rows.

## Navigation

- The application has a main Windows form where you can select (through a combo box) pre-loaded names.
- You can click the 'Click me' button to fetch the image from the web.
- You can click the delete button (❌) to delete from the DB the option selected in the combo box.
- You can click the insert button (🖊️) to open a second form to insert a record (name and image URL).

| Main Form (Default) | Main Form (Loaded) | Second Form |
|---------|---------|---------|
|![image](https://github.com/user-attachments/assets/92cedcb2-5933-40b1-af84-b6d0c4ddfeca)|![image](https://github.com/user-attachments/assets/518c6c2e-cdcc-47cb-a0a5-3c400a7ec6d4)|![Screenshot 2025-02-23 004940](https://github.com/user-attachments/assets/7d0c7eb2-98e2-4b5e-80a6-dc31c3b129c7)


The application will attempt to connect to a local MySQL database, using the DB name (MySQL_DB), user (MySQL_User) and password (MySQL_Pass) from the Windows environment variables. The application only needs a single table named exactly like its DB with an id (int), a 'name' (varchar(100)) and 'imageURL' (varchar(4096)).

When I tried the feching option, I already had a record in the table, so I don't know how the application might behave if it attempts to read an empty table. I guess it would just have an empty combo box and the 'Click me' and delete buttons would throw an error message if clicked.

## Consideration

The [MySQL connector](https://dev.mysql.com/downloads/connector/net/) might be required to be installed and referenced in the project for this solution to work (I used version 9.2.0). You can reference it in Visual Studio in the Solution Explorer window -> righ-click on 'Dependencies' -> 'Add Project Reference...' -> 'Browse...' -> search and select `MySql.Data.dll` (in my case it was installed at `\Program Files (x86)\MySQL\MySQL Connector NET 9.2\`.) Alternatively, it seems you can use the NuGet Package Manager (also on the alt-menu of 'Dependencies') and search for 'mysql connector'.


 
