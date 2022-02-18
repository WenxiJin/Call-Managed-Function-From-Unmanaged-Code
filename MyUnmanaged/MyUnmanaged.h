#pragma once
#pragma unmanaged

typedef int(__stdcall* CB)(int, int);

namespace MY_UNMANAGED
{
  class MyUnmanaged
  {
  public:
    int MyAdd(CB fp, int n, int m)
    {
      _cb = fp;
      if (_cb)
      {
        return _cb(n, m);
      }
      return -1;
    }

    void MyLongFunc(CB fp);
  private:
    CB _cb;
  };
}
