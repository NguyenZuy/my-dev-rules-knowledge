# Unity C# Naming

## Variables
- **Public:** Lowercase first letter, no underscores
  - Example: `public float speed;`
- **Private:** Starts with an underscore
  - Example: `private float _speed;`
- **Protected:** Starts with m_, uppercase first letter
  - Example: `protected float m_Speed;`
- **Getter, Setter:** Upcase first letter
  - Exampel: `public float Speed{ get{ return speed; } set{ speed = value; }}`

## Image
- Starts with img_, lowercase first letter
  - Example: `Image avatarImg;`

## Sprite
- Starts with spr_, lowercase first letter
  - Example: `Sprite avatarSprite;`

## TextMeshProUGUI, TextMeshPro
- Starts with txt_, lowercase first letter
  - Example: `TextMeshProUGUI nameTxt;`

## Button
- Starts with btn_, lowercase first letter
  - Example: `Button submitBtn;`

## Input Field
- Starts with ip_, lowercase first letter
  - Example: `TMP_InputField nameIp;`

## GameObject
- Starts with obj_, lowercase first letter
  - Example: `GameObject playerObj;`

## ScriptableObject
- Starts with so_, lowercase first letter
  - Example: `CharacterSO characterSO;`

## Bool
- Starts with is, uppercase first letter
  - Example: `bool isRunning;`

## Static Variables
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
    ``` C#
    enum CatsColor {
        BlackCat
    }
    ```

## Sprite
- Prefix: function or position,...
- Suffix: diff size, state,... 
- Lowercase all character
- Use `_` between words, prefix, suffix
- Use number for multiple version
- Example:
``` C#
bg_forest.png
btn_play.png
char_warrior.png
icon_health.png
btn_play_normal.png
btn_play_hover.png
btn_play_disabled.png
char_knight_idle.png
char_knight_attack.png
item_sword_gold.png
bg_sky_01.png
bg_sky_02.png
ui_panel_settings.png
```

## Subscene
- Start with `Sub_`
- Follow snake_case
- Example: `Sub_Local_Player`

## Elements in Hierarchy
- **UI element**: Start with `UI_`
  - Example: `UI_MainView`, `UI_HealthBar`