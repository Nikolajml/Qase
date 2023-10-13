pipeline {
    agent {label 'agent1'}


 parameters {
        string(
        name: 'TestFilter', 
        defaultValue: '',
        description: """ --filter 'FullyQualifiedName~YourNamespace.YourTestClass.YourTestMethod'
--filter 'Name=YourTestMethod'""")
    gitParameter branchFilter: 'origin/(.*)', defaultValue: 'main', name: 'Branch', type: 'PT_BRANCH'
  }  

  stages {
        stage('Set env variables') {
            steps {
               script{
               bat 'set BEARER=${Bearer}'
               }
            }
        }

        stages {
        stage('Checkout') {
            steps {
               git branch: "${Branch}", url: 'https://github.com/Nikolajml/Qase.git'
            }
        }

        stage('Build') {
            steps {
                bat "dotnet build"
            }
        }

        stage('Test') {
            steps {
                bat "dotnet test ${TestFilter}"
            }
            post {
                always {
                    allure includeProperties: false, jdk: '', results: [[path: 'Tests/bin/Debug/net7.0/allure-results'], [path: 'Tests/bin/Release/net7.0/allure-results']]
                }
            }
        }
    }
}