#!/bin/bash
echo '*********************************************************************'
echo "Generating kubernetes template for this release"
echo "Release Tag: ${SUPPORT_TICKET_RELEASE_TAG}"
echo "Template Path:  ${1}"
echo "Output Path: ${2}"
echo '*********************************************************************'

envsubst < ${1} > ${2}

cat ${2}

echo "...Done!"


