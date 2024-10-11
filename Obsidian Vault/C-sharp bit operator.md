 `// Bitwise AND`
`int a = 5;  // 0101 in binary`
`int b = 3;  // 0011 in binary`
`int c = a & b;  // c = 1 (0001 in binary)`

`// Bitwise OR`
`int d = a | b;  // d = 7 (0111 in binary)`

`// Bitwise XOR`
`int e = a ^ b;  // e = 6 (0110 in binary)`

`// Bitwise NOT`
`int f = ~a;  // f = -6 (1111...1010 in binary, two's complement)`

`// Left Shift`
`int g = a << 1;  // g = 10 (1010 in binary)`

`// Right Shift`
`int h = a >> 1;  // h = 2 (0010 in binary)`

`// Unsigned Right Shift`
`uint i = 0x80000000;`
`uint j = i >>> 1;  // j = 0x40000000`

`// Compound Assignment Operators`
`a &= b;  // Equivalent to: a = a & b`
`a |= b;  // Equivalent to: a = a | b`
`a ^= b;  // Equivalent to: a = a ^ b`
`a <<= 1; // Equivalent to: a = a << 1`
`a >>= 1; // Equivalent to: a = a >> 1`