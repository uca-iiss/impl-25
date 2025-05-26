FROM jenkins/jenkins:lts-jdk11

USER root

# Instalar Python 2.7 como versión principal
RUN apt-get update && \
    apt-get install -y python2.7 python-pip && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Configurar Python 2.7 como predeterminado
RUN update-alternatives --install /usr/bin/python python /usr/bin/python2.7 1 && \
    update-alternatives --install /usr/bin/pip pip /usr/bin/pip2 1

# Instalar dependencias adicionales
RUN apt-get update && apt-get install -y git && apt-get clean

USER jenkins

# Instalar plugins necesarios
RUN jenkins-plugin-cli --plugins "workflow-aggregator git"

# Copiar el Jenkinsfile
COPY aspectos.python-RITCHIE.Jenkinsfile /var/jenkins_home/Jenkinsfile