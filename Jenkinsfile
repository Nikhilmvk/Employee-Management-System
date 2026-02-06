pipeline {
    agent any

    stages {

        stage('Checkout') {
            steps {
                git 'https://github.com/Nikhilmvk/Employee-Management-System.git'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o publish'
            }
        }

        stage('Deploy') {
            steps {
                sh '''
                  sudo mkdir -p /var/www/employee-api
                  sudo cp -r publish/* /var/www/employee-api/
                '''
            }
        }
    }
}
