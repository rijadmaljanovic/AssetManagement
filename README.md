# AssetManagement

During summer internship in Meta Software Solutions (https://mss.ba/) we were creating an app used for Asset management. This app is used to record and track an asset through its life cycle. It provides information like where certain assets are located, who is using them and details about the asset. The asset management software is used for management of both software and hardware assets. It also provides additional functions like: 

*storing vendor info 
*storing products info 
*access to assets location 
*table view of a certain report with a possibility of review in pdf format 
*keeping track of employees and their assignements

Link to review the application: https://internship2021.mss.ba/login
Login info:
*Username: admin
*Password: 12345678

Link to check the APIs through swagger: https://internship2021-api.mss.ba/swagger/index.html

I worked on the back end side of the project and these are some of my tasks I did:
*creating Database CRUD functionalities
*creating and maintaining a microservice for storing coordinates in the database from queue(rabbitMQ)
**APIs: https://internship2021-gw.mss.ba/swagger/index.html , rabbitmq: https://rabbitmq-internship2021.mss.ba/#/ (riki:kikiriki)
*creating and maintaining a mailservice to send push notifications
*creating and maintaining dockerfiles for the microservices and WebApp
