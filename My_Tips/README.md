# My Tips In Unity C#

- Use `[MethodImpl(MethodImplOptions.AggressiveInlining)]` for small or frequently used methods to encourage the compiler to inline them (replace the method call with the method's content), which can improve performance and reduce overhead.

- `readonly` can only assigned a value when it is declared or in the constructor of the containing class. After that, the value cannot be changed anyway.