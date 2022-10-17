FROM node:18-alpine as builder
WORKDIR /app
COPY . .
RUN npm ci 
RUN npm run build

FROM nginx:1.21.0-alpine as develop
ENV NODE_ENV develop
COPY --from=builder /app/build /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]