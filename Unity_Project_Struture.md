# 🚀 Directory Structure

## Unity DOTS
- Assets/
	- Project/
		- `Arts`/ -- UIs, Sprites, Models, Effects,...
		- `Sounds`/ 
		- `Prefabs`/
		- Shaders/
		- Materials/
		- ScriptableObjects/
		- Scripts/
			- `DOTS/`
				- Authorings/
				- Components/
				- Systems/
				- Jobs/
				- Utils/
					- Helper/ -- Helper class for specific function.
					- Util/ -- Utility methods use for multiple function
					- Constant/ -- Constant variable/enum use for DOTS system - non Mono
			- `Mono/`
			- `Editor/`
			- `Hybrid/` -- Use the DOTS script in Mono code

- Assets/
    - Project/
        - 📦 Art/                    -- Contains all art assets like UI, Sprites, 3D Models, Effects, Textures, Materials, etc.
        - 🎶 Sound/                  -- Contains all audio assets like Music, Sound Effects, etc.
        - 🧩 Prefab/                 -- Contains Prefabs for UI, Characters, Enemies, etc.
        - 📜 ScriptableObject/       -- Contains ScriptableObjects like PlayerSO, EnemySO, MapSO, etc.
        - 🖌️ Shader/                 -- Contains custom Shaders.
        - 📁 Scripts/ 
            - ⚙️ Authoring/          -- Contains Authoring components (used to bridge traditional MonoBehaviour and DOTS entities).
            - 📦 Component/          -- Contains ECS Components (structs or data containers).
            - 🧠 System/             -- Contains ECS Systems (for processing data).
            - 🔄 Job/                -- Contains Jobs for parallel computation.
            - 🌍 Constant/           -- Contains constants (e.g., game settings, global values).
            - 🖥️ Mono/ 
                - 🏙️ Entity/         -- Contains MonoBehaviour scripts for managing entities, models, requests, responses.
                - 🎮 UI/             -- Contains UI-related MonoBehaviour scripts.
                - 🔒 Base/           -- Custom Base Interfaces, Abstract classes.
                - 🏷️ Manager/        -- Contains Manager scripts (GameManager, AudioManager, ResourceManager, etc.).
            - 🛠️ Hybrid/              -- Contains hybrid scripts or systems that combine DOTS with traditional MonoBehaviour.
            - 📝 Editor/              -- Custom editor scripts for DOTS tools and utilities.
            - ⚙️ Utility/             -- Utility functions or helper classes for ECS and MonoBehaviour integration.
            - 🧰 Helper/              -- Helper classes for various utilities (non-ECS).
            - 📜 ScriptableObject/    -- Custom ScriptableObjects (can be used by both MonoBehaviour and DOTS).
            
            
## Unity Tranditional

- Asset/
    - Project/
        - 📦 Art/                    -- Contains all art assets like UI, Sprites, 3D Models, Effects, Textures, Materials, etc.
        - 🎶 Sound/                  -- Contains all audio assets like Music, Sound Effects, etc.
        - 🧩 Prefab/                 -- Contains Prefabs for UI, Characters, Enemies, etc.
        - 📜 ScriptableObject/       -- Contains ScriptableObjects like PlayerSO, EnemySO, MapSO, etc.
        - 🖌️ Shader/                 -- Contains custom Shaders.
        - 📁 Scripts/ 
            - 🌍 Constant/           -- Contains constants and global settings (e.g., enums, constants for game rules).
            - 🏙️ Entity/             -- Contains MonoBehaviour scripts that handle entities (e.g., Player, Enemies, NPCs).
            - 🎮 UI/                 -- Contains UI-related scripts (e.g., UI controllers, UI managers).
            - 🏷️ Manager/            -- Contains Manager scripts like GameManager, AudioManager, ResourceManager, etc.
            - 🔒 Base/               -- Custom Base Interfaces, Abstract classes, or generic code.
            - ⚙️ Utility/            -- Utility functions or helper methods (e.g., mathematical utilities, string helpers).
            - 🧰 Helper/             -- Helper classes for miscellaneous functionality.
            - 📝 Editor/             -- Custom editor scripts for Unity tools and utilities.
            - 📜 ScriptableObject/   -- Custom ScriptableObjects for game data (e.g., GameSettings, Levels).


# 🚀 Assembly Dependencies

## Unity DOTS

## Unity Tranditional