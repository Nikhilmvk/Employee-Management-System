pipeline {
    agent any

    stages {
        stage('Build Docker Image') {
            steps {
                sh 'docker build -t employee-api .'
            }
        }

        stage('Run Container') {
            steps {
                sh '''
                  docker rm -f employee-api || true
                  docker run -d -p 8040:8080 --name employeee-api employee-api
                '''
            }
        }
    }
}
