using System;
using bitLab.Log;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace bitLab.ViewModel
{
  public class CConsoleVM: CBaseVM, ILogListener
  {
    public event EventHandler<string> ExecuteCommand;

    public CConsoleVM()
    {
      Lines = new ObservableCollection<CConsoleLineVM>();
      ExecuteCommandCommand = new CDelegateCommand(mExecuteCommandCommand);
      Logger.Register(this);
    }

    public ObservableCollection<CConsoleLineVM> Lines { get; private set; }
    public CDelegateCommand ExecuteCommandCommand { get; private set; }
    private void mExecuteCommandCommand(object arg)
    {
      var textToUse = mText;
      Text = null;
      if (ExecuteCommand != null)
        ExecuteCommand(this, textToUse);
    }
    private string mText;
    public string Text
    {
      get
      {
        return mText;
      }
      set
      {
        SetAndNotify(ref mText, value);
      }
    }

    public void LogMessage(LogMessage message)
    {
      AddConsoleLine(new CConsoleLineVM(message.Message, CColors.Orange));
    }

    private void AddConsoleLine(CConsoleLineVM line)
    {
      Invoke(() => Lines.Add(line));
      RemoveLineWithDelay(line, 5000);
    }

    private void RemoveLineWithDelay(CConsoleLineVM line, int delayMillisec)
    {
      Task.Factory.StartNew(() =>
      {
        Thread.Sleep(delayMillisec);
        Invoke(() => Lines.Remove(line));
      });
    }
  }
}
