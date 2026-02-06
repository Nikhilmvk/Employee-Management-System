pipeline {
    agent any
    environment {
        IMAGE_NAME = "employee-api"
    }
    stages {

        stage('Build Docker Image') {
            steps {
                // Build the Docker image for the API
                sh 'docker build -t $IMAGE_NAME .'
            }
        }

        stage('Run API Container') {
            steps {
                // Remove old container if exists
                sh 'docker rm -f employee-api || true'
                // Run new container
                sh 'docker run -d --name employee-api -p 8045:80 $IMAGE_NAME'
            }
        }

        stage('Test API') {
            steps {
                // Wait for API to start
                sh 'sleep 10'
                // Test the endpoint
                sh 'curl http://localhost:8042/employee || true'
            }
        }
    }
}
