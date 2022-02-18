#pragma once
#include <vcclr.h>
using namespace System;
using namespace System::Runtime::InteropServices;
#include "../MyUnmanaged/MyUnmanaged.h"

#pragma managed
namespace MYCLR
{
  // declare a delegate
  typedef int(__stdcall* CB)(int, int);
  public delegate int MyClrDel(int, int);

  public ref class MyClr
  {
  public:
    MyClr(MyClrDel^ myClrDel) {
      _pMyUnmanaged = new MY_UNMANAGED::MyUnmanaged();
      _cb = static_cast<CB>(Marshal::GetFunctionPointerForDelegate(myClrDel).ToPointer());

    };
    int MyClrAdd(int n, int m)
    {
      return _pMyUnmanaged->MyAdd(_cb, n, m);
    }
    void MyClrLongFunc()
    {
      _pMyUnmanaged->MyLongFunc(_cb);
    }
  private:
    class MY_UNMANAGED::MyUnmanaged* _pMyUnmanaged;
    CB _cb;
  };
}


