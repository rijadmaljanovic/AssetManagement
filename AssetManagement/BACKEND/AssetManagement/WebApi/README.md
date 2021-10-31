AUTHENTICATION
-run project
-send user credentials to api/Login/Authenticate
-if successful copy token from response

AUTHORIZATION
-find authorize button on swagger
-insert "Bearer " + token
-click login
-if successful use authorized methods