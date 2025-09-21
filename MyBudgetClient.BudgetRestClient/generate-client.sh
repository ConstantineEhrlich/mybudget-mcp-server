#!/bin/bash
CONFIG_PATH="./config.nswag"
echo "Generating client code using NSwag..."

# Back to basics - try the standard command
nswag run "$CONFIG_PATH"

if [ $? -eq 0 ]; then
    echo "Client code generation completed successfully!"
else
    echo "Client code generation failed. Please check the error messages above."
    exit 1
fi