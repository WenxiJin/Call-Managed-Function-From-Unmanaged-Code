#pragma once

typedef int(__stdcall* CB)(int, int);

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
private:
  CB _cb;
};

