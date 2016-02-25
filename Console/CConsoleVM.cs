using System;
using bitLab.Log;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace bitLab.ViewModel
{
  public class CConsoleVM: CBaseVM, ILogListener
  {
    public event EventHandler<string> ExecuteCommand;

    public CConsoleVM()
    {
      Lines = new ObservableCollection<LogMessage>();
      ExecuteCommandCommand = new CDelegateCommand(mExecuteCommandCommand);

      Logger.Register(this);
    }

    public ObservableCollection<LogMessage> Lines { get; private set; }

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

    void ILogListener.LogMessage(LogMessage message)
    {
      AddConsoleLine(message);
    }

    private void AddConsoleLine(LogMessage line)
    {
      Invoke(() => Lines.Add(line));
      //RemoveLineWithDelay(line, 5000);
    }

    private void RemoveLineWithDelay(LogMessage line, int delayMillisec)
    {
      Task.Factory.StartNew(() =>
      {
        Thread.Sleep(delayMillisec);
        Invoke(() => Lines.Remove(line));
      });
    }
  }
}
