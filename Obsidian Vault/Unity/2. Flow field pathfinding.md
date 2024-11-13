- Is a `navigation technique` widely used in RTS game
- Step to implements:
	- Divided world into a grid (cells).
	- Each cell stores a `direction vector` - `Flow field`
	- Three main phases:
		- Cos field generation: Each cell is assigned a `movement cost` based on obstacles, terrain or other factors (wall have high cost).
		- Integration field calculation: Start from the target, a `distance field` (or integration field) is computed to assign values representing the cost to reach the target from each cell.
		- Flow field creation: Using the integration field, each cell computes the `direction` to move toward the target with the lowest accumulated cost.
	- Unit movement: Read the vector from the flow field to determine the direction to move on each frame, leading to smooth, coordinated movement.

| Feature                           | Flow Field Pathfinding  | A* Pathfinding         |
| :-------------------------------- | :---------------------: | ---------------------- |
| Use case                          | Multi-agent pathfinding | Individual pathfinding |
| Path optimality                   |        Moderate         | High                   |
| Performance (Many agents)         |          Fast           | Slow                   |
| Memory usage                      |          High           | Low                    |
| Adaptability (Dynamic Enviroment) |           Low           | High                   |
| Example game types                |   RTS, Tower Defense    | Turn-based, RPGs       |
Document and examples:
- https://www.youtube.com/watch?v=tSe6ZqDKB0Y&t=1240s