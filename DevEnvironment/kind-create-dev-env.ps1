kind create cluster --name kind-01 --config=kind-cluster-config.yaml

# https://kind.sigs.k8s.io/docs/user/quick-start/#loading-an-image-into-your-cluster
kind load docker-image groffeazuredevops.azurecr.io/apisuportemongodb:dev --name kind-01

kubectl create namespace integration-tests

kubectl apply -f .\deployment-dev-env-mongodb.yml -n integration-tests

kubectl apply -f .\secret-dev-env.yml -n integration-tests

kubectl apply -f .\deployment-dev-env-api.yml -n integration-tests