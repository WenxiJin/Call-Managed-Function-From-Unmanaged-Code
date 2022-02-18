using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MyWinFormsApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      InitializeBackgroundWorker();
      _del = new(MyCSAdd);
      gch = GCHandle.Alloc(_del);
      myClr = new(_del);
    }

    static GCHandle gch;
    private int x = 0;
    private int y = 0;
    private MYCLR.MyClrDel _del;
    private MYCLR.MyClr myClr;

    public int MyCSAdd(int n, int m)
    {
      Console.WriteLine("[managed] callback!");
      ++x;

      WorkerReportProgress(y++);
      return n + m + x;
    }

    private void WorkerReportProgress(int n)
    {
      backgroundWorker1.WorkerReportsProgress = true;
      backgroundWorker1.ReportProgress(n*10);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int res = myClr.MyClrAdd(123, 456);
      textBox1.Text = res.ToString();
    }


    // Set up the BackgroundWorker object by
    // attaching event handlers.
    private void InitializeBackgroundWorker()
    {
      backgroundWorker1.DoWork +=
          new DoWorkEventHandler(backgroundWorker1_DoWork);
      backgroundWorker1.RunWorkerCompleted +=
          new RunWorkerCompletedEventHandler(
      backgroundWorker1_RunWorkerCompleted);
      backgroundWorker1.ProgressChanged +=
          new ProgressChangedEventHandler(
      backgroundWorker1_ProgressChanged);
    }

    // This event handler is where the actual,
    // potentially time-consuming work is done.
    private void backgroundWorker1_DoWork(object sender,
        DoWorkEventArgs e)
    {
      // Get the BackgroundWorker that raised this event.
      BackgroundWorker? worker = sender as BackgroundWorker;

      // Assign the result of the computation
      // to the Result property of the DoWorkEventArgs
      // object. This is will be available to the
      // RunWorkerCompleted eventhandler.
      myClr.MyClrLongFunc();
    }

    // This event handler deals with the results of the
    // background operation.
    private void backgroundWorker1_RunWorkerCompleted(
        object sender, RunWorkerCompletedEventArgs e)
    {
      // First, handle the case where an exception was thrown.
      if (e.Error != null)
      {
        MessageBox.Show(e.Error.Message);
      }
      else if (e.Cancelled)
      {
        // Next, handle the case where the user canceled
        // the operation.
        // Note that due to a race condition in
        // the DoWork event handler, the Cancelled
        // flag may not have been set, even though
        // CancelAsync was called.
        MessageBox.Show("Cancelled");
      }
      else
      {
        // Finally, handle the case where the operation
        // succeeded.
        MessageBox.Show("Finished");
      }
    }

    // This event handler updates the progress bar.
    private void backgroundWorker1_ProgressChanged(object sender,
        ProgressChangedEventArgs e)
    {
      this.progressBar1.Value = e.ProgressPercentage;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      backgroundWorker1.RunWorkerAsync();
    }
  }
}