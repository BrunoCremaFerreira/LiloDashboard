FROM nginx:latest
MAINTAINER Bruno Crema Ferreira
COPY /docker/config/nginx.conf /etc/nginx/nginx.cong
EXPOSE 80 443
ENTRYPOINT["nginx"]
CMD ["-g", "daemon off;"]
