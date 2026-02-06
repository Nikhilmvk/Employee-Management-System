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
                  docker run -d -p 8091:8080 --name employee-api employee-api
                '''
            }
        }
    }
}
