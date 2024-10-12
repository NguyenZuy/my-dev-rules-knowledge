# Graphics performance fundamental
- CPU cost of rendering: The greatest contributor is the cost of sending `rendering commands` to the GPU.
- Rendering commands: include draw calls (command to draw geometry) and commands to change the settings on the GPU before draw geometry.
	👀 Reduce the number objects that Unity renders:
		👉 Reduce the overall number of objects in the scene: for example, use `Skybox` to create the effect of distant geometry.
		👉 Perform more rigorous culling, draw fewer objects: for example, use `Occlusion culling`, `far clip plane of camera` or`separate layers and cull distance with Camera.layerCullDistance`.
	👀 Reduce the number of times that Unity renders each object:
		👉 Use `lightmapping | bakelight` it increases build time, runtime memory usage and  storage space, but can improve runtime performance.
		👉 If app uses `Forward rendering`, reduce the number of per-pixel real time lights that affect objects.
		👉 Trouble shooting the `Realtime Shadow`.
		👉 If app use `Reflection Probes`, ensure optimize their usage.
	👀 Reduce amount of work that Unity do to prepare and send rendering commands:
		👉 Sending them to the GPU in more effcient "batches".
- GPU cost of rendering: time to render a frame, 3 main reasons 
	👀 Limited by fill rate - GPU try to draw more pixels per frame than it can handle:
		👉 Reduce `Overdraw`: the most common distributors to overdraw are overlapping transparent elements, such as UI, particles and sprites.
		👉 Reduce the execution cost of fragment shaders (main on shader - HLSL).
		👉 If using Unity's built-in shaders, pick ones from the `Mobile` or `Unlit` categories for more performance.
		👉 Consider to use `Dynamic Resolution` - for auto reduce workload on GPU.
	👀 Limited by memory bandwidth - GPU try to read and write more data to its dedicated memory than it can handle in a frame - usually have too many textures or that textures are too large.
		👉 Enable `mipmaps` for texture - multiple texture for multiple distance, this increase memory usage an storage space but can improve GPU runtime performance.
		👉 Use suitable `Compression formats` to decrease the size of texture in memory.
	👀 Limited by vertex processing - GPU try to process more verticles than it can handle in a frame:
		👉 Reduce the execution cost of `vertex shaders`.
		👉 Optimize the geometry (reduce `triangles`, few materials, use single skinned mesh, few bones, ...)
		👉 LOD
- Consider to reduce FPS: Use `OnDemandRendering`

# Optimize draw call
- Draw calls: is the command Unity send to graphic API to draw geometry, each draw call  contains all the information such as texture, shaders and buffers. Draw calls can be resource intensive, but often the preparation for a draw call is more resource intensive than the draw call itself.
- CPU setups resources and changes internal setting  on the GPU. These settings are collectively called the `render state`. 
- Change the `render state` (switch material) is the most resource-intensive operations.
	👉 Reduce the total number of draw calls.
	👉 Reduce the number of changes to the render state, if the graphics API can use same render state to perform multiple draw call, it can group draw call together and not need to perform as many render-state changes.
	✅ Reduces the amount of electricty your application requires.
	✅ Reduces the amount of heat a device when running the application.
	✅ Improves maintainability of future development on your application.
- Several methods in Unity to optimize draw call:\
	👀 GPU instancing: Render multiple copy of the same mesh at the same time, useful for drawing geometry that appears multiple times in a scene (tree , bushes, etc...).
	👀 Draw call batching: Combine meshs to reduce draw calls.
		👉 Static batching: Combine meshs of `static` gameObject in advance. Unity sends the combined data to GPU.
		👉 Dynamic batching: Tranform vertices on the CPU, group vertices that share the same configuration and render them in one draw call (position, normal, etc...).
	👀 Manually combining meshes: Combine into a single mesh, like using `Mesh.CombineMesh` function. Unity will render a single mesh in a draw call instead of one draw call per mesh.
	👀 SRP Batcher (Scriptable Render Pipeline): reduce the CPU time Unity require to prepare and dispatch calls for material that use the same shader variant.
	😱 Can use multiple optimization methods, but Unity prioritizes draw call optimizations in the following order: `SRP Batcher and static batching -> GPU instancing -> Dynamic batching.`

- DOTS Instancing: a new shader instancing mode of BRG (BatchRendererGroup)

|                                                                                   Traditional                                                                                   |                                                                                                                                                   DOTS instancing                                                                                                                                                    |
| :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| passed an array for each instanced property in a constant or uniform buffer, such that each element in each array contains the property value for a single instance in the draw | passes one 32-bit integer to the shader for each DOTS Instanced property. This 32-bit integer is called a metadata value. This integer can represent anything you want, but typically it represents an offset in the buffer from where the shader loads property data for the instance that the shader is rendering. |
|                                                                  setup all data for every instance every frame                                                                  |                                                                     stored in a GraphicBuffer and remains persistent on GPU -> don't need setup again each time it render the new instance -> only setup again when an instance actually changes                                                                     |
|                                                                                                                                                                                 |                                 setting up instance data is separate from setting up the draw call -> make draw call setup lightweight and efficient -> does a minimal amount of work for each draw call -> reponsibility for this work moves to you (what will render, when,etc...)                                 |
|                                                             limited by instance data in constant or uniform buffer                                                              |                                                                                                   fewer data for each of instance -> more instances counts with a single draw call (`still limit` but no problem)                                                                                                    |
|                                                                                                                                                                                 |                                                                                    load all instances if have same value for a given property -> save memory and number of GPU cycle spent duplicating the value of each instance                                                                                    |
