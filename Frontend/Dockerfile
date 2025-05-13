FROM node:18-alpine AS builder
WORKDIR /app


COPY package*.json ./
RUN npm install
COPY . .

RUN npm run build --configuration=production


FROM nginx:stable-alpine AS runner

RUN rm -rf /usr/share/nginx/html/*
COPY --from=builder /app/dist/* /usr/share/nginx/html

RUN mkdir -p /var/cache/nginx /var/run /run \
    && chown -R nginx:nginx /var/cache/nginx /var/run /run /usr/share/nginx/html

USER nginx
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
