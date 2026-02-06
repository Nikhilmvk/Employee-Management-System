pipeline {
    agent any
    environment {
        IMAGE_NAME = "employee-api"
    }
    stages {
        stage('Build .NET Project') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build -c Release'
                sh 'dotnet publish -c Release -o ./publish'
            }
        }
        stage('Build Docker Image') {
            steps {
                sh 'docker build -t $IMAGE_NAME .'
            }
        }
        stage('Run API Container') {
            steps {
                sh 'docker rm -f employee-api || true'
                sh 'docker run -d --name employee-api -p 8042:80 $IMAGE_NAME'
            }
        }
        stage('Test API') {
            steps {
                sh 'sleep 10'
                sh 'curl http://localhost:8043/employee || true'
            }
        }
    }
}
