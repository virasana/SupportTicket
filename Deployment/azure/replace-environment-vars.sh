#!/bin/bash
echo "Generating kubernetes template for this release"
echo "Release Version ${SUPPORT_TICKET_VERSION}"
echo "File output: ./support-ticket-k8s.yaml"

envsubst < ./_support-ticket-k8s.yaml > ./support-ticket-k8s.yaml

cat ./support-ticket-k8s.yaml

echo "...Done!"


