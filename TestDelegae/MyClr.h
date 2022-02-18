#pragma once
using namespace System;
using namespace System::Runtime::InteropServices;
#include "../MyUnmanaged/MyUnmanaged.h"

namespace MYCLR
{
  // declare a delegate
  typedef int(__stdcall* CB)(int, int);
  public delegate int MyClrDel(int, int);

  public ref class MyClr
  {
  public:
    MyClr() {
      _pMyUnmanaged = new MyUnmanaged();
    };
    int MyClrAdd(MyClrDel^ myClrDel, int n, int m)
    {
      CB cb = static_cast<CB>(Marshal::GetFunctionPointerForDelegate(myClrDel).ToPointer());
      return _pMyUnmanaged->MyAdd(cb, n, m);
    }
  private:
    class MyUnmanaged* _pMyUnmanaged;
  };
}


