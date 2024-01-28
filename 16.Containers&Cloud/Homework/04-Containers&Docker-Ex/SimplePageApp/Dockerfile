# Use an official Python runtime as a parent image
FROM python:3.8-slim-buster

# Set the working directory in the container to /app
WORKDIR /app

# Set environment variables
ENV PYTHONDONTWRITEBYTECODE=1
ENV PYTHONUNBUFFERED 1

# Install any needed packages specified in requirements.txt
COPY requirements.txt /app/
RUN pip install --no-cache-dir -r requirements.txt

# Copy the current directory contents into the contaienr at /app
COPY . /app/

# Set the static files directory
RUN mkdir /app/staticfiles

# Copy the static files
COPY static /app/staticfiles

# Expose the port the app runs on
EXPOSE 8000

# Run command to start the application
CMD [ "gunicorn", "SimplePageApp.wsgi:application", "--bind", "0.0.0.0:8000" ]