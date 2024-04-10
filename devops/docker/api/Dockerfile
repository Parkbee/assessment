FROM --platform=linux/amd64 node:20-alpine

WORKDIR /usr/src/app

COPY ./app.js ./
COPY ./package.json ./
COPY ./package-lock.json ./

RUN npm install

EXPOSE 4000

ENV NODE_ENV production

CMD ["node", "app.js"]
