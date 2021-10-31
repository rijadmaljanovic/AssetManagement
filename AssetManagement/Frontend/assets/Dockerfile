#### BUILD STAGE ####
#Creating an image with node
FROM node:lts-alpine as build-stage

#Making a directory where our app will be placed. This may not be necessary
RUN mkdir -p /app

#Change directory
WORKDIR /app

#Copy dependency definitions
COPY package*.json ./

#Install dependencies using npm
RUN npm install


#Get all the code
COPY . /app
#Build the app
RUN npm run build

#### PRODUCTION STAGE ####
#Create image based on nginx 
FROM nginx:stable-alpine as production-stage

#RUN ls .
COPY --from=build-stage /app/dist/ /usr/share/nginx/html

RUN rm /etc/nginx/conf.d/default.conf

COPY nginx/nginx.conf /etc/nginx/conf.d

#EXPOSE the port
EXPOSE 80

#RUN the nginx cmd
CMD ["nginx","-g","daemon off;"] 

