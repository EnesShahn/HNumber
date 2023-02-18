# Huge Number Libray

This library was specifically made for games where numbers go infinitly.

A while ago I've made an Idle/Incremental game and I used the built-in data types which offcourse had its limits. After a while players started approaching the limits so I've made this library to solve that problem.

The way the types in this library work is simple, You have a Mantissa and an exponent (e.g. 984x10^8) the mantissa is using the BigInteger type which can hold infinite number of digits depending on the machine's memory, this was a problem since as players grow stronger the digit count will grow as well which will result in poor performance specially if its an online game where you store these numbers in a database for example and process many at a time. The solution is pretty easy, restrict the mantissa's precision which will be user-defined.

I've not tested the performance of HNumber thoroughly yet, but I believe the performance change is negligible for most games as long as you don't go high with Mantissa's precision.
