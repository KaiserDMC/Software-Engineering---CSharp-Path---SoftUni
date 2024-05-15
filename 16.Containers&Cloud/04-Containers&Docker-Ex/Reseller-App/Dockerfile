# Use the official OpenJDK image as the base image
FROM openjdk:11-jre-slim

# Set metadata about the mainatiner of the image
LABEL maintainer="kaiserDMC"

# Copy the compiled jar file into the image
ARG JAR_FILE=target/*.jar
COPY ${JAR_FILE} app.jar

# Expose the port the app runs on
EXPOSE 8080

ENTRYPOINT [ "java", "-jar", "/app.jar" ]