#!/bin/bash
echo '*********************************************************************'
echo "Generating kubernetes template for this release"
echo "Release Tag: ${SUPPORT_TICKET_REACT_IMAGE}"
echo "Template Path:  ${1}"
echo "Output Path: ${2}"
echo '*********************************************************************'


echo "==> Copying template to ${1} to ${1}.temp"
cp ${1} "${1}.temp"

envsubst < "${1}.temp" > "${2}"

echo "==> Removing temporary file ${1}.temp"
rm "${1}.temp"

echo "==> Display contents"
cat ${2}

echo "...Done!"


