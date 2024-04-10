#!/bin/sh

# Replace placeholders with environment variable values
sed -i "s|%%API_HOST%%|${API_HOST}|g" /app/public/index.html
sed -i "s|%%API_PORT%%|${API_PORT}|g" /app/public/index.html

# Execute the passed command (e.g., http-server)
exec "$@"
