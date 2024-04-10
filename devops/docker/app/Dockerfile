# Use the official Node.js 18 image as a parent image
FROM --platform=linux/amd64 node:20-alpine

WORKDIR /usr/src/app

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 80

CMD ["node", "server.js"]
