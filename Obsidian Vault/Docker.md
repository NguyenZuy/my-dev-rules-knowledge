### Image
- List all local Images: `sudo docker images`
- Remove local image: `sudo docker rmi <name-or-id>`
### Container
- List container:
	- Running: `sudo docker ps`
	- All: `sudo docker ps -a`
	- By image name: `sudo docker ps -s --filter "ancestor=<image-name>"`
- Stop: `sudo docker stop <name-or-id>`
- Remove: `sudo docker rm <name-or-id>`