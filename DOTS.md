# 🌟 Unity Data-Oriented Technology Stack (DOTS) 🌟

## I. Overview of DOTS 🏁

### 1. What is DOTS? 🧐

- **Unity DOTS** is the implementation of the Entity Component System (ECS) architecture.
- Designed to help developers build high-performance games that can efficiently scale across multiple CPU cores.


### 2. Key Benefits of DOTS 💡

- **High Performance**: Optimized for modern hardware.
- **Scalability**: Efficiently handles large amounts of data and entities.
- **Concurrency**: Leverages multi-core processors for maximum performance.


## II. Unity DOTS Packages 📦
- Unity DOTS use several package for help to create high-performance code.

### 1. Entities (Version: 1.2.3) 🧩

- The core of DOTS, **Entities** package implements the **Entity-Component-System (ECS)** pattern.

- **Key Concepts**: 

  - **Entity**:
    - Represents discrete elements (e.g., characters, effects, UI).
    - Acts as an ID linking components.
    - Lightweight and doesn't contain behavior or code.

  - **World**: 
    - A collection of entities.
    - Managed by an EntityManager.

  - **EntityManager**:
    - Responsible for creating, destroying, and managing entities.
    - **Common Methods**:
      - `CreateEntity`: Creates a new entity.
      - `Instantiate`: Copies an existing entity.
      - `DestroyEntity`: Destroys an entity.
      - `AddComponent`: Adds a component to an entity.
      - `RemoveComponent`: Removes a component.
      - `GetComponent`: Retrieves a component's value.
      - `SetComponent`: Sets a component's value.

  - **Component**:
    - Contains data for entities (e.g., position, health).
    - Marked using the `IComponentData` interface.
    - Ideally should contain **pure data** (unmanaged).

  - **Archetype**: 
    - Represents entities with the same combination of components.
    - Stored in chunks (16KB blocks).

- **Visual: Entity System Overview**
- **System Types**:
  - **Managed System**: Slower but easier to use (`SystemBase`).
  - **Unmanaged System**: Faster and more flexible (`ISystem`).

### 2. C# Job System (Unity Version 2022.3) 🛠️

- **Purpose**: Fast, safe, multi-threaded code for handling tasks across all CPU cores.

- Leverages **Burst Compiler** and **Safety System** to ensure efficiency and prevent race conditions.

- **Core Concepts**: 
  - **Job System**: Breaks tasks into small chunks for parallel execution.
  - **Work Stealing**: When a worker finishes a task early, it steals from other threads to maximize efficiency.
  - **Safety**: Ensures no race conditions when jobs access data.

- **Native Containers**:
  - **Types**:
      - `NativeArray`, `NativeSlice`, etc (used in jobs).
      - `Allocator` options: `Temp`, `TempJob`, and `Persistent`.

- **Best Practices**:
  - Call `Schedule` early, use `Complete` only when necessary.
  - Break large tasks into smaller, dependent jobs.
  - Avoid writing to the same data in parallel jobs.

### 3. Burst Compiler (Version: 1.8.17) ⚡
- The **Burst Compiler** optimizes code performance y generating highly optimized machine code.

- **Key Features**:
  - **AOT Compiler** for build/run applications.
  - **JIT Compiler** for editor play mode.
  - **Attributes**:
    - `BurstCompile`: Applies Burst to a method.
    - `BurstDiscard`: Discards methods that shouldn't be Burst-compiled.
    

### 4. Collections (Version: 2.4.2) 🗃️
- **Native Collections** enable safe, efficient handling of data, particularly in multi-threaded environments.
- **Types**:
  - **Thread-Safe**: e.g., `NativeList, NativeHashMap`.
  - **Unsafe**: More efficient, but lacks safety checks (use with caution).
  

### 5. Mathematics (Version: 1.3.2) ➗
- A **math library** optimized for Burst-compiled code. Do not use with the **Mono** compiler—use `Mathf` instead.


### 6. Unity Physics 🔵
- **Stateless & Deterministic**: Physics calculations are based entirely on the current frame's data.
- **Use cases**: Simple physics interactions for high performance (lower complexity).

### 7. Havok Physics for Unity ⚙️
- **Stateful & Deterministic**: Maintains internal state between frames for more complex and realistic physics interactions.
- **Use cases**: More realistic simulations, but with higher computational overhead.

### 8. Netcode for Entities 🌐
- A **client-server solution** built for Unity DOTS entities, designed for multiplayer games.

### 9. Entities Graphics 🎨
- **Graphics**: Uses the **Scriptable Render Pipeline (SRP)** to render entities.
- **Optimized**: Designed for high-performance rendering of large numbers of entities.