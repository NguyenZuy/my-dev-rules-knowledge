# My Naming Conventions in Unity C#

### Variables
- **Public:** Lowercase first letter, no underscores
  - Example: `public float speed;`
- **Private:** Starts with an underscore
  - Example: `private float _speed;`
- **Protected:** Starts with m_, lowercase first letter
  - Example: `protected float m_speed;`
- **Getter, Setter:** Upcase first letter
  - Exampel: `public float Speed{ get{ return speed; } set{ speed = value; }}`

### Image
- Starts with img_, lowercase first letter
  - Example: `Image img_avatar;`

### Sprite
- Starts with spr_, lowercase first letter
  - Example: `Sprite spt_avatar;`

### TextMeshProUGUI, TextMeshPro
- Starts with txt_, lowercase first letter
  - Example: `TextMeshProUGUI txt_name;`

### Button
- Starts with btn_, lowercase first letter
  - Example: `Button btn_submit;`

### Input Field
- Starts with ip_, lowercase first letter
  - Example: `TMP_InputField ip_name;`

### GameObject
- Starts with obj_, lowercase first letter
  - Example: `GameObject obj_player;`

### ScriptableObject
- Starts with so_, lowercase first letter
  - Example: `CharacterSO so_character;`

### Bool
- Starts with is, uppercase first letter
  - Example: `bool isRunning;`

### Getter and Setter
- Same as original but uppercase first letter
  - Example:
    ```csharp
    GameManager GameManager {
        get { return gameManager; }
        set { gameManager = value; }
    }
    ```

### Static Variables
- All uppercase with underscores between words
  - Example: `static GameManager GAME_MANAGER;`

## Functions
- Uppercase first letter
- Event handling functions start with `OnClick`

## Classes
- Uppercase first letter
- Use `Manager` suffix for manager classes
- Use `Util` suffix for utility classes

## Namespaces
- PascalCase
  - Example: `QWorld.Utils`

## Abstract Classes
- Start with `Abstract`
  - Example: `AbstractCharacter`

## Interfaces
- Start with `I`
  - Example: `ICharacter`

## Scriptable Objects
- Ends with `SO`
  - Example: `CharacterMoveSO`

## Enums
- Enum names are lowercase
- Enum values are uppercase with underscores between words
  - Example:
    ```csharp
    enum CatsColor {
        BLACK_CAT
    }
    ```

## Unity Project Structure (Assets)

### Scripts
- **Core/**: Contains core elements like `GameManager`, `AudioManager`, `SceneManager`
- **Managers/**: Contains management scripts like `InputManager`, `UIManager`
- **Controllers/**: Contains controllers like `PlayerController`, `EnemyController`, `NPCController`
- **Utilities/**: General utility scripts

### Art
- **Models/**: 3D models
- **Textures/**: Textures
- **Materials/**: Materials
- **Animations/**: Animation assets

### Audio
- **Music/**: Background music
- **SFX/**: Sound effects

### Prefabs
- Folder for prefabs

### Scenes
- Folder for scene files

### UI
- **Prefabs/**: UI prefabs
- **Sprites/**: UI sprites

## Example Unity Project Structure

```plaintext
Assets/
├── Art/
│   ├── Models/
│   │   ├── player.fbx
│   │   ├── enemy.fbx
│   │   └── environment.fbx
│   ├── Textures/
│   │   ├── player_diffuse.png
│   │   ├── enemy_diffuse.png
│   │   └── environment_diffuse.png
│   ├── Materials/
│   │   ├── player.mat
│   │   ├── enemy.mat
│   │   └── environment.mat
│   └── Animations/
│       ├── player_run.anim
│       ├── player_jump.anim
│       └── enemy_attack.anim
├── Audio/
│   ├── Music/
│   │   ├── background_music.mp3
│   │   └── battle_theme.mp3
│   └── SFX/
│       ├── jump.wav
│       ├── attack.wav
│       └── death.wav
├── Prefabs/
│   ├── player.prefab
│   ├── enemy.prefab
│   └── environment.prefab
├── Scenes/
│   ├── MainMenu.unity
│   ├── Level1.unity
│   └── Level2.unity
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── AudioManager.cs
│   │   └── SceneManager.cs
│   ├── Managers/
│   │   ├── InputManager.cs
│   │   ├── UIManager.cs
│   │   └── SaveManager.cs
│   ├── Controllers/
│   │   ├── PlayerController.cs
│   │   ├── EnemyController.cs
│   │   └── NPCController.cs
│   └── Utilities/
│       ├── MathUtil.cs
│       ├── StringUtil.cs
│       └── TimeUtil.cs
└── UI/
    ├── Prefabs/
    │   ├── MainMenuUI.prefab
    │   ├── PauseMenuUI.prefab
    │   └── HUDUI.prefab
    └── Sprites/
        ├── button_play.png
        ├── button_pause.png
        └── button_exit.png
