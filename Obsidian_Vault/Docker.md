### Image
- List all local Images: `sudo docker images`
- Remove local image: `sudo docker rmi <name-or-id>`
- Delete all local images:
	  - Remove all stopped containers: `docker container prune -f`
	  - Force remove all local images: `sudo docker rmi $(sudo docker images -aq) -f`
### Container
- List container:
	- Running: `sudo docker ps`
	- All: `sudo docker ps -a`
	- By image name: `sudo docker ps -s --filter "ancestor=<image-name>"`
- Stop: `sudo docker stop <name-or-id>`
- Remove: `sudo docker rm <name-or-id>`
- Stop all containers: `sudo docker stop $(sudo docker ps -q)`
- Stop and remove exsiting containers :`sudo docker-compose down --remove-orphans`