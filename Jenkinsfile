pipeline {
    agent { label 'my-slave-label-onWhich-i-will-choose-to-run-the-pipeline-on-it' }
    stages {
        stage('build') {
            steps {
                echo 'build'
                script {
                    withCredentials([usernamePassword(credentialsId: 'my-docker-hub-cred', usernameVariable: 'MY_USERNAME', passwordVariable: 'MY_PASSWORD')]) {
                        sh """
                            docker login -u ${MY_USERNAME} -p ${MY_PASSWORD}
                            docker build -t mohamedsamirebrahim/dotnetcoreapp${BRANCH_NAME}:v${BUILD_NUMBER} .
                            docker push mohamedsamirebrahim/dotnetcoreapp${BRANCH_NAME}:v${BUILD_NUMBER}
                        """
                    }
                }
            }
        }
        stage('deploy') {
            steps {
                echo 'deploy'
                script {
                    withCredentials([string(credentialsId: 'database-password-secret', variable: 'DATABASE_PASSWORD')]) {
                        withCredentials([file(credentialsId: 'kubeconfig-for-my-slave', variable: 'MY_KUBECONFIG')]) {
                            def namespaceExists = sh(returnStdout: true, script: "kubectl get ns --kubeconfig ${MY_KUBECONFIG} | grep ${BRANCH_NAME} | wc -l").trim()
                            if (namespaceExists == "1") 
                            {
                                echo "Namespace ${BRANCH_NAME} already exists, skipping creation step."
                            } else {
                                sh "kubectl create namespace ${BRANCH_NAME} --kubeconfig ${MY_KUBECONFIG}"
                            }
                            sh """
                                # Check if release already exists
                                if helm status ${BRANCH_NAME} --kubeconfig ${MY_KUBECONFIG} >/dev/null 2>&1; then
                                    helm upgrade ${BRANCH_NAME} ./Deployment -f ./Deployment/${BRANCH_NAME}values.yaml --set image.repository=mohamedsamirebrahim/dotnetcoreapp${BRANCH_NAME},image.tag=${BUILD_NUMBER},databasepassword=${DATABASE_PASSWORD} --kubeconfig ${MY_KUBECONFIG}
                                else
                                    helm install ${BRANCH_NAME} ./Deployment -f ./Deployment/${BRANCH_NAME}values.yaml --set image.repository=mohamedsamirebrahim/dotnetcoreapp${BRANCH_NAME},image.tag=${BUILD_NUMBER},databasepassword=${DATABASE_PASSWORD} --kubeconfig ${MY_KUBECONFIG}
                                fi
                            """
                        }
                    }
                }
            }
        }
    }
}
