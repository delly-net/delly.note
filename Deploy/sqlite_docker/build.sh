#/bin/bash
# cd /opt/sctr
name="jip-pgsql"
server="docker.jueyun.net"
echo "[+++] $name:$1"
docker build -t $name:$1 .
docker save -o $name-$1.tar $name:$1
gzip $name-$1.tar
echo "[>>>] $server/$name:$1"
docker tag $name:$1 $server/$name:$1
docker push $server/$name:$1
echo "[---] $name:$1"
docker rmi $name:$1
docker rmi $server/$name:$1
echo "done"