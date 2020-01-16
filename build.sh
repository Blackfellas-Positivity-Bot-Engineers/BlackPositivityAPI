# Initializing Variables
_env=$1
_imagetag=blackpositivityapi-$_env
echo $_imagetag

#Stop container
docker stop $_imagetag

#Remove container
docker rm --force $_imagetag

#Remove image
docker rmi $_imagetag

#Build new image
docker build --no-cache --build-arg ASPNETCORE_ENVIRONMENT=$_env -t "$_imagetag" ./BlackPositivity.Api

#Run new image
docker run -d -p 3000:80 --name "$_imagetag" $_imagetag

echo $_imagetag new version up! 

exit 0