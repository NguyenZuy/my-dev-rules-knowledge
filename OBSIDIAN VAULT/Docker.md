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

### Volume
- Is a mechanism for persisting and sharing data generated and used by Docker containers. Unlike data stored in a container's writable layer, volume provide several key advantages:
	- Data persistence:
		- Volumes exist independently of container lifecycles
		- Data in volumes remains even after a container is deleted
		- Allows you to preserve important data like databases, configuration files, or application data
	- Types of volumes:
		- Named Volumes: Managed by Docker, stored in a part of the host filesystem managed by Docker
		- Bind Mounts: Mapping a host directory to a container directory
		- Tmpfs Mounts: Temporary storage that exists only in the host system's memory
	- Key Benefits
		-  Better performance compared to storing data in the container's writable layer
		- Easy to share data between multiple containers
		- Can be managed independently of containers
		- Supports volume drivers for storing data on remote hosts or cloud providers
- `sudo docker volume ls` for list all volumes
- Delete volume:
		- Stop docker container if volume is cur using: `sudo docker-compose down`
		- Remove the volume `sudo docker volume rm custom-nakama_data`
