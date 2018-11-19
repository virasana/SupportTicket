###################################################################################
# base image - use as a base for the other two images.  
# Also use this one for dev.  
# In Dev:
#     - By using volume mounts, we can work with the source on Windows an run the site
#     - in the Linux container
#     - Note: it uses chokidar to enable hot module reloading (HMR)

FROM node:11.1.0 as streactbase

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY package.json /usr/src/app/package.json
RUN npm install 
RUN npm install react-scripts@1.1.1 -g 

# start app
CMD ["npm", "start"]

###################################################################################

# build image - this one creates a build folder on streactbase, located at /usr/src/app/build
FROM streactbase as streactbuild
COPY . /usr/src/app
RUN npm run build

###################################################################################

# prod image - copy the build artifacts from builder
FROM streactbuild as streactprod
COPY --from=streactbuild /usr/src/app/build /usr/share/nginx/html
EXPOSE 3000

