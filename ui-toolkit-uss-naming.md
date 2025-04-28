# 🎨 UI Toolkit Uss Naming Conventions

### 🧩 Naming Rules According to BEM (Block Element Modifier) (Main Rule)

- **Structure**: `block__element--modifier`

  - **Block**: an independent and reusable component in the user interface
    * **Example**: `.button, .header`

  - **Element**: a part of the block that cannot exist independently outside the block, separated by two underscores '__'
    * **Example**: `.button__icon, .header__title`

  - **Modifier**: a variant of the block or element, used to change their appearance or behavior, separated by two dashes '--'
    * **Example**: `.button--large, .menu__item--active`


### 🖋️ Use '-' to separate words in the name
- **Example**: `.header-container`, `#main-content`


### 🚫 Avoid using numbers at the beginning of the name

- **Rule**: Do not start names with numbers
  - **Example**:
    - **Incorrect**: `.2_columns`
    - **Correct**: `.two-columns`


### 🔍 Avoid using overly long names (But they must be clear and meaningful)
- **Example**: do not use `.navigation-bar-for-main-menu`, should use `.nav-main-menu`


### ⚠️ Avoid generic names
- **Example**: do not use `.red, .big, .small`, should use `.error-message, .btn-large`