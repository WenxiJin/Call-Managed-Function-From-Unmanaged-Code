# Call-Managed-Function-From-Unmanaged-Code

## Scope
Winforms(C#) -> CLR -> unmanaged C++ is quite common nowadays for windows GUI application based on old C++ code. For time consuming C++ function, we would like to report progress on the GUI. Therefore a callback comes handy.
****
## Projects
* MyUnmanaged

   Here the unmanaged code is going to call the callback func defined in C#.
* TestDelegate (MyClr), compiled with /clr, and change "Conformance mode" to NO

   Open TestDelegate.sln in Visual Studio (tested on 2022). It contains 3 projects.
   Essentially, this is the place converts the delegate to function pointer.

* MyWinformsApp

   A simpled managed function passed down to the unmanaged C++ code via CLR wrapper.
   ```CPP
   MyCSAdd(int n, int m);
   ```