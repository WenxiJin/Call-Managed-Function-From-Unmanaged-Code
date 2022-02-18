#include "MyUnmanaged.h"
#include <windows.h>
#pragma unmanaged
void MY_UNMANAGED::MyUnmanaged::MyLongFunc(CB fp)
{
  for (int i = 0; i < 5; i++)
  {
    Sleep(5000);
    fp(123, 456 + i*10);
  }
}