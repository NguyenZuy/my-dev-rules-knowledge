# 🚀 Directory Structure

## Unity DOTS

	Assets/
		└── Project/
		    ├── Arts/
		    ├── Data/
		    ├── Materials/
		    ├── Prefabs/
		    ├── SO/
		    ├── Scripts/
		    │   ├── DOTS/
		    │   │   ├── Authorings/
		    │   │   ├── Components/
		    │   │   ├── Constant/
		    │   │   ├── Jobs/
		    │   │   ├── Systems/
		    │   │   └── Utils/
		    │   │       ├── Helper/
		    │   │       └── Util/
		    │   ├── Editor/
		    │   ├── Hybrid/
		    │   ├── Mono/
		    │   │   ├── Constant/
		    │   │   ├── Entities/
		    │   │   ├── Managers/
		    │   │   ├── SOs/
		    │   │   ├── UI/
		    │   │   └── Utils/
		    │   │       ├── Helper/
		    │   │       └── Util/
		    │   └── Shared/
		    │       ├── Constants/
		    │       └── Utils/
		    ├── Shaders/
		    └── Sounds/
            
## Unity Traditional

	Assets/
	└── Project/
	    ├── Arts/
	    ├── Data/
	    ├── Materials/
	    ├── Prefabs/
	    ├── SO/
	    ├── Scripts/
	    │   ├── Constants/
	    │   ├── Editor/
	    │   ├── Entities/
	    │   ├── Managers/
	    │   ├── SOs/
	    │   ├── UI/
	    │   └── Utils/
	    │       ├── Helper/
	    │       └── Util/
	    ├── Shaders/
	    └── Sounds/

# 🚀 Assembly Dependencies

## Unity DOTS

	DOTS -- DOTS.asmdef -> Shared
	Editos -- Editor.asmdef -> DOTS, Mono, Shared
	Hybrid -- Hybrid.asmdef -> DOTS, Mono, Shared
	Mono -- Mono.asmdef -> Shared
	Shared -- Shared.asmdef
## Unity Traditional
