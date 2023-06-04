[![.NET](https://github.com/aimenux/WcfExceptionHandlingDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/WcfExceptionHandlingDemo/actions/workflows/ci.yml)

# WcfExceptionHandlingDemo
```
Using various ways to handle wcf exceptions
```

In this repo, i m using various ways in order to handle wcf exceptions :

:black_nib: **Example01** : the `Api` may throw .net exceptions and the `App` catch them as unhandled fault exceptions.

:black_nib: **Example02** : the `Api` may throw soap exceptions and the `App` catch them as custom fault exceptions.

:black_nib: **Example03** : the `Api` use a global error handler and the `App` catch them as custom fault exceptions.

**`Tools`** : net 6.0, wcf-core