### PrintScreenManager.cs (PrintScreenManager) 
 File responsible to the screenshots takinh 
### FSHelper.cs (FSHelper) 
 File Responsible to the FileSystem in the application 
 Defines the OutputFolder, used on the app 
 Also is responsible to save the Image files and the MD files. 
 Import implementation: 
 
``` cs
private String outputFolder = "";
        public void setOutputFolder(String outputFolder)
       {
           if (outputFolder[outputFolder.Length - 1] == @"\"[0]) 
           {
               this.outputFolder = outputFolder;
           }
           else
           {
               this.outputFolder = outputFolder + @"\" ;
           }
       }
       // 
```
### KeyboardMouseClickManager.cs (MouseClickManager and KeyboardClickManager) 
 File Responsible to the user input Hooks in the application 
 Defines the Mouse and Keyboard Hooks, used on the app 
 Also is responsible to trigger the Screenshots and capturing the text. 
 Import implementation (MouseClick screenshot trigger): 
 
``` cs
if (System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Left)
                   {
                       
                       MDFileExporter.getInstance().addEventToMDString(this.history.getHistory());
                       PrintScreenManager.getInstance().Execute();
                       this.history.resetHistory();
                   }
                    if (System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Right)
                   {
                        MDFileExporter.getInstance().addEventToMDString(this.history.getHistory());
                       PrintScreenManager.getInstance().Execute();
                       this.history.resetHistory();
                   }
                    if (System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Middle)
                   {
                        MDFileExporter.getInstance().addEventToMDString(this.history.getHistory());
                       PrintScreenManager.getInstance().Execute();
                       PrintScreenManager.getInstance().Execute();
                       this.history.resetHistory();
                   }
                   // 
```
 Import implementation (Keyboard screenshot trigger / Text Saving): 
 
``` cs
if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
           {
               int vkCode = Marshal.ReadInt32(lParam);
               string keyChar = GetKeyCharacter(vkCode);
                if (keyChar == "ENTER")
               {
                   // Print, save writeHistory to md
                   MDFileExporter.getInstance().addEventToMDString(writeHistory.getHistory());
                   PrintScreenManager.getInstance().Execute();
                   writeHistory.resetHistory();
                   return CallNextHookEx(_hookId, nCode, wParam, lParam);
               }
               if (keyChar == "BACKSPACE")
               {
                   writeHistory.backspace();
               }
               else { writeHistory.setHistory(keyChar); }
               
           }
           return CallNextHookEx(_hookId, nCode, wParam, lParam);
           // 
```
### StringHistoryHelper.cs (StringHistoryHelper) 
 File is used to be a single data repository for the KeyboardMouseClickManager Threads 
### MDFileExporter.cs (MDFileExporter) 
 File Responsible to the .md File in the application 
 Defines how the program stores the data in the markdown 
 Import implementation: 
 
``` cs
public void addPrintToMDString(string filename) {
           MDString = MDString + "  \n" + $"![{filename}](./{filename})";
       }
       public void addEventToMDString(string eventStringData) {
           MDString = MDString + "  \n" + eventStringData;
           return; 
       }
       // 
```
