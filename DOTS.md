# UNITY DATA-ORIENTED TECHNOLOGY STACK (DOTS)

## I. SUMMARY

### 1. Define
- Unity DOTS is implementation of the Entity Component System (ECS) architecture.
- To help Developer to create a high-performance game.

### 2. Benefits
- High performance.
- Scalability.
- Concurrency: maximizing the use of modern multi-core processors.

## II. FURTHER DOTS UNITY PACKAGE
- Unity DOTS use several package for help to create high-performance code.

### 1. Entities `Version: 1.2.3`
- An implementation of the Entity, Component, System (ECS) pattern.
- Entity concepts:
  - Entity:
    - 👉 Represents a discrete element in your program (e.g., character, visual effect, UI element).
    - 👉 Acts as an ID that associates unique components together.
    - 👉 Similar to an unmanaged, lightweight GameObject but does not contain code or serve as a container for components.
  - World:
    - A collection of entities.
    - Managed by an EntityManager.
  - EntityManager:
    - Manages all entities within the world.
    - Common methods:
      - 👉 `CreateEntity`: Creates a new entity.
      - 👉 `Instantiate`: Copies an existing entity to create a new one.
      - 👉 `DestroyEntity`: Destroys an existing entity.
      - 👉 `AddComponent`: Adds a component to an entity.
      - 👉 `RemoveComponent`: Removes a component from an entity.
      - 👉 `GetComponent`: Retrieves the value of an entity's component.
      - 👉 `SetComponent`: Overrites the value of an entity's component.
    - An entity doesn't have a type, instead have the `archetype`.
    - `Structual change` when you create or destroy entities, which will impact the performance of application.
- Component concepts:
  - Component: 
    - 👉 Contain data for entities that system can read or write.
    - 👉 Marked using `IComponentData` interface.
    - 👉 Should ideally be pure data (unmanaged data).
  - Archetype:
    - 👉 Unique sets of an entity's components.
    - 👉 Stored in 16KiB memory block called chunks (~13.4 KB)
  - Types:![image](https://github.com/user-attachments/assets/09d5737a-1975-4b5b-9d8c-ca01db989e1b)
  - Additional `Aspect` is useful for organizing component code and simplifying queries in your systems.
- System concepts:
  - System provides the logic that transforms component data from its current state to its next state.
  - Run on the main thread once per frame.
  - Can only process entities in one world, so a system is asscociated with a particular world.
  - Have two create:
    - 👉 `Managed system`:
    - 👉 `Unmanaged system`:
  - System types:
    - 👉 `SystemBase`: Provides a base class for managed systems, slower than `ISystem`.
    - 👉 `ISystem`: Provides an interface for unmanaged systems, faster than `SystemBase`.
    - 👉 `EntityCommandBufferSystem`: Provides entity command bufferinstances for other systems. This allows you to group structural changes together to improve the performance of your application.
    - 👉 `ComponentSystemGroup`: Provides a nested organization and update order for systems.
      ![image](https://github.com/user-attachments/assets/c2e545a5-768c-423b-b68e-e0e3d51cd375)
- World concepts:
  - World is a collection of entities
  - Entity's ID number is only unique within its own world.
  - Have an `EntityManager` struct, which you use to create, destroy, and modify the entiies with in the world.
  - Owns a set of systems - usually only accesses the entities within that same world.
  - Additionally, a set of entities within a world which have same set of component types are stored together in an `archetype`.
  - In Play mode, Unity auto creates a `World` instance and adds every system to this default world (can add manual with class implementing the `ICustom Bootstrap`).
- Archetype concepts:
  - A unique identifier for all the entities in a world that have the same unique combination of component types.
  - An archetype is only destroyed when its world is destroyed.
- Structural change concepts:
  - Operations that cause Unity to reorganize chunks of memory or the contents of chunks in memory (craete or destroying an entity, add or remove components, setting a shared component value).
  - IMPORTANT: Avoid sync points.
- Safety in Entities:

### 2. C# Job System `Unity Version 2022.3`
- A solution for fast, safe, multi-threaded code.
- Lets you create multithreaded code using all CPU cores to execute.
- Use `Burst Compiler` + `Unity's Job System` to increase performance & reduce the battery consumption.
- `Work stealing` 👉 when a worker thread finishes the tasks faster than others, it will process the task in another worker thread queue.
- Use `Safety System` protects you from the race condition (Ex: When job A & B reading & writing to data at the same time, this scenario creates a race condition 👉 to solve it, the `Job Sytem` will copy of a data on rather than the reference).
- A small unit does a task, similar method, it can be self-contained or depend on other jobs.
- In Unity, a job refer to any `struct` implements the `IJob` interface.
- Only the main thread can schedule and complete jobs.
- When use with `Burst Compiler`, must use the `blittable type` or `NativeContainer` objects (belong to `Unity.Collections`) to access data in jobs.
- `NativeContainer` objects allow a job to access data shared by main thread, it have 2 types:
  - 👉 `NativeArray`: An unmanaged array which exposes a buffer of native memory to managed code.
  - 👉 `NativeSlice`: Gets a subset of a `NativeArray` from a particular position to a certain length.
  - 👉 Additional `NativeContainer`, too see `Unity.Collections`.
- By default, when a job access to `NativeContainer` instance, it has both read and write access -> slow performance (because `Job System` doesn't allow you to schedule a job that has write access to a `NativeContainer` instance at the same time with another job is writing to it.
  - 👉 Mark `[ReadOnly]` attribute with the `NativeContainer` to resolve above issue.
- Create `NativeContainer`, must specify the memory allocation types (depend it lifespan)
  - 👉 `Allocator.Temp`: fastest, lifespan of one frame or fewer, use when do not pass to or store in other jobs.
  - 👉 `Allocator.TempJob`: slower than `Allocator.Temp` but faster than `Alloccator.Persistent`, lifespan of four frames (must `Dispose` in four frames), suitable for small job.
  - 👉 `Allocator.Persistent`: slowest, lifespan can last as long as you need (don't use if performance is paramount).
- If two independent scheduled jobs write to the same `NativeContainer` or a jobs try to write/read the content of `NativeContainer` before another job is writing/reading this, will throw a clearly error message (if you want to solve this issue, can use `job with dependency`).
- `NativeContainer` don't implement the `ref return` (ex: cannot update the value by `nativeArray[0]++;`).
- Best Practice:
  - 👉 Call `Schedule` as soon as you have the the data it needs.
  - 👉 Don't call `Complete` until you need the result.
  - 👉 Can schedule less important jobs in a part of the frame where they are not competing with more important jobs.
    - Ex: if have a period between the end of one frame and the beginning of the next frame where no jobs are running and a one frame latency is acceptable, you can schedule the job towards the end of a frame and use its results in the following frame.
  - 👉 Breaking the long jobs into multiple shorter job if possible (interdependence).
- Jobs dependencies:
  - 👉 One job can depend on more than one job.
- Parallel jobs: use `ParallelFor` to perform the same operation on a lot of objects.

### 3. Burst Compiler `Version: 1.8.17`
- A C# compiler that generates highly optimized code.
- Mode compiler:
  - 👉 Editor Play mode: JIT compiler (just-in-time).
  - 👉 Build & run application to player: AOT compiler (ahead-of-time).
- Improve the performance of Burst: extend the attribute `[BurstCompile]`.
- When have codes inside the `[BurstCompile]` but not running in Burst use `[BurstDiscard]` (but cannot have a return value).
- Exist issue when compile the Generic jobs.
- Doesn't support the managed objects.
- `Asynchronous compilation` use when:
  - 👉 A long running job that only run once.
  - 👉 Profiling a Burst Job & want to test the code from the Burst compiler
  - 👉 Debugging the difference between managed and Burst compiled code.

### 4. Collections `Version: 2.4.2`
- A set of unmanaged collection types, such as List and Hashmap, useful in Jobs and Burst-compiler because they can only access unmanaged data.
- Fall into two main categories:
  - 👉 Have safety checks: use in thread safe way, in the `Unity.Collections` namespace and their names start with `Native`.
  - 👉 Don't have safety checks: in the `Unity.Collections.LowLevel.Unsafe` namespace and their names start with `Unsafe`.
- Most `Native` collections are implemented as wrapper of their `Unsafe` counterparts.
- Several of the collection types support write & read in parallel.
- Although `ParallelWriter` & `ParralelReader` ensure the safety of concurrent writes & reads, the order of the concurrent writes & reads is indeterminsics.
- Allocator: ![image](https://github.com/user-attachments/assets/9bf82962-9a86-4a53-8a86-20813120731f)

### 5. Mathematics `Version: 1.3.2`
- A math library which is specially optimized in Burst-compiled code.
- Don't use with the Mono compiler (recommend use Mathf).

### 6. (Extend) Unity Physics
- A stateless and deterministic physics system for entities.
- Stateless: does not maintain any internal state between frames 👉 essy to find reason and debug because the state is entirely determined by the current frame's data.
- Lower complex interactions and lower realistic simulations (compare to Havox Physics for Unity).

### 7. (Extend) Havok Physics for Unity 
- A stateful and deterministic physics system for entities.
- Stateful: maintain any internal state between frames 👉 allow for more complex interactions and more realistic simulations.

### 8. (Extend) Netcode for Entities
- A client-server solution for Entities.

### 9. (Extend) Entities Graphics
- Uses the scriptable render pipeline (SRP) to render entities.

# TESTING PERFORMANCE OF DOTS
## Animated Unit Handle
- [Video test](https://www.youtube.com/watch?v=QXfFk3wdD0c)
- Result: ![image](https://github.com/user-attachments/assets/141da2cb-9e6b-4104-ab98-c2be57f4a0fd)
- 👉 PC: the best solution is GPU ECS Animations
- 👉 Steam Deck: the best solution still is GPU ECS Animations

