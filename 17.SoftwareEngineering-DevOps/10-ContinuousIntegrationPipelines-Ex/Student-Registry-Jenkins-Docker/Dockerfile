# Use the official Node.js 14 image as a parent image
FROM node:14

# Set the working directory inside the container to /app
WORKDIR /app

# Copy package.json and package-lock.json files into the container at /app
COPY package*.json ./

# Install dependencies in the container
RUN npm install

# Copy the rest of your app's source code from your host to your image filesystem.
COPY . .

# Expose the port the app runs on
EXPOSE 3030

# Define the command to run your app using CMD which defines your runtime
CMD [ "npm", "start" ]
