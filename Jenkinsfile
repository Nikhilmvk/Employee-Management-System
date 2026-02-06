pipeline {
    agent any

    environment {
        DOTNET_ROOT = "C:\\Program Files\\dotnet"
    }

    stages {

        stage('Checkout') {
            steps {
                git 'https://github.com/Nikhilmvk/Employee-Management-System.git'
            }
        }

        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o publish'
            }
        }

        stage('Deploy') {
            steps {
                bat 'xcopy publish C:\\Deploy\\DotNetSqlJenkins /E /Y /I'
            }
        }
    }
}
