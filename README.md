# Incremental Numbers Libray

---UNDER DEVELOPMENT = NOT READY FOR PRODUCTION---

This library was specifically made for games where numbers go infinitly.

A while ago I've made an Idle/Incremental game and I used the built-in data types which offcourse had its limits. After a while players started approaching the limits so I've made this library to solve that problem.

The way the types in this library work is simple, You have a Mantissa and an exponent (e.g. 984x10^8) the mantissa is using the BigInteger type which can hold infinite number of digits depending on the machine's memory, this was a problem since as players grow stronger the digit count will grow as well which will result in poor performance specially if its an online game where you store these numbers in a database for example and process many at a time. The solution is pretty easy, restrict the mantissa's precision whcih will be user-defined.

I've not tested the performance of the code thoroughly yet, but I believe it will perform almost as fast as the built-in data types if precision is around 20.




```
            DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
                    Version 2, December 2004

 Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>

 Everyone is permitted to copy and distribute verbatim or modified
 copies of this license document, and changing it is allowed as long
 as the name is changed.

            DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
   TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION

  0. You just DO WHAT THE FUCK YOU WANT TO.
```
