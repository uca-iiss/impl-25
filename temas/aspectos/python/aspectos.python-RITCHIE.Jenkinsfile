pipeline {
    agent any   // Usar cualquier agente disponible

    stages {
        // Etapa para comprobar la versión de Python y pip
        stage('Comprobar versiones') {
            steps {
                sh 'python --version'
                sh 'pip --version'
            }
        }

        // Etapa para instalar las dependencias necesarias del proyecto
        stage('Instalar Dependencias') {
            steps {
                sh '''
                    virtualenv --python=python2.7 venv
                    . venv/bin/activate
                    pip install -r temas/aspectos/python/requirements.txt
                '''
            }
        }

        // Etapa para ejecutar los tests
        stage('Ejecutar Test') {
            steps {
                script {
                    withEnv(["PATH+VENV=${env.WORKSPACE}/venv/bin"]) {
                        sh '''
                        . venv/bin/activate
                        python -m pytest temas/aspectos/python/tests/ -v
                        '''
                    }
                }
            }
        }

        // Etapa para ejecutar el script principal del proyecto
        stage('Ejecutar Main') {
            steps {
                script {
                    withEnv(["PATH+VENV=${env.WORKSPACE}/venv/bin"]) {
                        sh '''
                        . venv/bin/activate
                        python temas/aspectos/python/src/main.py
                        '''
                    }
                }
            }
        }
    }

    post {
        always {
            sh 'echo "Pipeline completado - Ver resultados en consola"'
        }
    }
}