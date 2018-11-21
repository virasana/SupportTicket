#!/bin/bash
echo "Generating kubernetes template for this release"
echo "Release Tag ${SUPPORT_TICKET_RELEASE_TAG}"

echo "File output: ./support-ticket-k8s.yaml"

envsubst < ./template-support-ticket-k8s.yaml > ./support-ticket-k8s.yaml

cat ./support-ticket-k8s.yaml

echo "...Done!"


