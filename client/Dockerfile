#stage 1
FROM node:13-alpine as builder

WORKDIR /app

ARG API_URL
ENV VUE_APP_API_URL=$API_URL

COPY ./ /app

RUN yarn install
RUN yarn build

#stage 2
FROM nginx:alpine

COPY --from=builder /app/dist /usr/share/nginx/html

CMD /usr/sbin/nginx -g "daemon off;"