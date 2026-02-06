pipeline {
    agent any

    stages {
        stage('Build Docker Image') {
            steps {
                sh 'docker build -t employee-api:${BUILD_NUMBER} .'
            }
        }

        stage('Run Container') {
            steps {
                sh '''
                docker stop employee-api || true
                docker rm employee-api || true

                docker run -d \
                --name employee-api \
                -p 8042:80 \
                employee-api:${BUILD_NUMBER}
                '''
            }
        }
    }
}
