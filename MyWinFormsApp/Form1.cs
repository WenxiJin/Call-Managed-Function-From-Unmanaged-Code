using System.Runtime.InteropServices;

namespace MyWinFormsApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private int x = 0;
    static GCHandle gch;
    public int MyCSAdd(int n, int m)
    {
      Console.WriteLine("[managed] callback!");
      ++x;
      return n + m + x;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      MYCLR.MyClrDel del = new(MyCSAdd);
      gch = GCHandle.Alloc(del);


      MYCLR.MyClr myClr = new();
      int res = myClr.MyClrAdd(del, 123, 456);
      textBox1.Text = res.ToString();
    }
  }
}