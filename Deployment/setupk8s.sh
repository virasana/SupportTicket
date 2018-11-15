echo "*** GENERATING SSH KEYS ***"

ssh-keygen -q -t rsa -N '' -f /tmp/id_rsa 

echo "*** EXPORT KOPS STATE ***"
export KOPS_STATE_STORE=s3://kops-state-karunasoft

#echo "*** AWS CONFIGURE ***"
#aws configure 

#exit

echo "*** CREATING CLUSTER ***"
kops create cluster \
    --name=kubernetes.ticket-track.com \
	--state=s3://kops-state-karunasoft \
    --zones=eu-west-1a \
	--node-count=2 \
	--node-size=t2.micro \
	--master-size=t2.micro --dns-zone=kubernetes.ticket-track.com \
	--ssh-public-key=/tmp/id_rsa.pub \

echo "*** UPDATING CLUSTER ***"
kops update cluster \
    --name=kubernetes.ticket-track.com \
	--state=s3://kops-state-karunasoft \
	--ssh-public-key=/tmp/id_rsa.pub \
	--yes


echo "*** You need to create an S3 bucket (Amazon Service) - mine is called kops-state-karunasoft (use an aws-globally unique name)" 
echo "*** Set up Route53 hosted zones ***" 
echo "*** Create Name Server 'A' Records on Kubernetes Domain - you will need to have your own hosted domain - e.g. GoDaddy.  Add additional records pointing to Route53 name servers on the Route 53 hosted zones ***"
echo "*** If you delete and recreate the cluster, you may need to empty and/or recreate the bucket in Amazon S3."
echo "*** run the container like so (this will get your ssh keys securely from OUTSIDE the container: docker run -itv C:\Temp\Keys:/tmp virasana/linux-devops"
echo "*** TODO: rebuild the image.  Start the container as above and commit the image. Change the location of the /tmp folder"