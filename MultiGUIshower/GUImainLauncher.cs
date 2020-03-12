using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using NXOpen;
using NXOpen.BlockStyler;

namespace MultiGUIshower
{
    public class GUImainLauncher
    {
        //class members
        private static Session theSession = null;
        private static UI theUI = null;
        private string theDlxFileName;
        private NXOpen.BlockStyler.BlockDialog theDialog;
        private NXOpen.BlockStyler.Group group0;// Block type: Group
        private NXOpen.BlockStyler.Enumeration enum0;// Block type: Enumeration

        //------------------------------------------------------------------------------
        //Constructor for NX Styler class
        //------------------------------------------------------------------------------
        public GUImainLauncher()
        {
            try
            {
                theSession = Session.GetSession();
                theUI = UI.GetUI();
                theDlxFileName = "GUImainLauncher.dlx";
                theDialog = theUI.CreateDialog(theDlxFileName);
                theDialog.AddApplyHandler(new NXOpen.BlockStyler.BlockDialog.Apply(apply_cb));
                theDialog.AddOkHandler(new NXOpen.BlockStyler.BlockDialog.Ok(ok_cb));
                theDialog.AddUpdateHandler(new NXOpen.BlockStyler.BlockDialog.Update(update_cb));
                theDialog.AddInitializeHandler(new NXOpen.BlockStyler.BlockDialog.Initialize(initialize_cb));
                theDialog.AddDialogShownHandler(new NXOpen.BlockStyler.BlockDialog.DialogShown(dialogShown_cb));
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                throw ex;
            }
        }
        //------------------------------- DIALOG LAUNCHING ---------------------------------
        //
        //    Before invoking this application one needs to open any part/empty part in NX
        //    because of the behavior of the blocks.
        //
        //    Make sure the dlx file is in one of the following locations:
        //        1.) From where NX session is launched
        //        2.) $UGII_USER_DIR/application
        //        3.) For released applications, using UGII_CUSTOM_DIRECTORY_FILE is highly
        //            recommended. This variable is set to a full directory path to a file 
        //            containing a list of root directories for all custom applications.
        //            e.g., UGII_CUSTOM_DIRECTORY_FILE=$UGII_BASE_DIR\ugii\menus\custom_dirs.dat
        //
        //    You can create the dialog using one of the following way:
        //
        //    1. Journal Replay
        //
        //        1) Replay this file through Tool->Journal->Play Menu.
        //
        //    2. USER EXIT
        //
        //        1) Create the Shared Library -- Refer "Block UI Styler programmer's guide"
        //        2) Invoke the Shared Library through File->Execute->NX Open menu.
        //
        //------------------------------------------------------------------------------
        public static void Main()
        {
            GUImainLauncher theGUImainLauncher = null;
            try
            {
                theGUImainLauncher = new GUImainLauncher();
                // The following method shows the dialog immediately
                theGUImainLauncher.Show();
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
            finally
            {
                if (theGUImainLauncher != null)
                    theGUImainLauncher.Dispose();
                theGUImainLauncher = null;
            }
        }
        //------------------------------------------------------------------------------
        // This method specifies how a shared image is unloaded from memory
        // within NX. This method gives you the capability to unload an
        // internal NX Open application or user  exit from NX. Specify any
        // one of the three constants as a return value to determine the type
        // of unload to perform:
        //
        //
        //    Immediately : unload the library as soon as the automation program has completed
        //    Explicitly  : unload the library from the "Unload Shared Image" dialog
        //    AtTermination : unload the library when the NX session terminates
        //
        //
        // NOTE:  A program which associates NX Open applications with the menubar
        // MUST NOT use this option since it will UNLOAD your NX Open application image
        // from the menubar.
        //------------------------------------------------------------------------------
        public static int GetUnloadOption(string arg)
        {
            //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);
            return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);
            // return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
        }

        //------------------------------------------------------------------------------
        // Following method cleanup any housekeeping chores that may be needed.
        // This method is automatically called by NX.
        //------------------------------------------------------------------------------
        public static void UnloadLibrary(string arg)
        {
            try
            {
                //---- Enter your code here -----
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
        }

        //------------------------------------------------------------------------------
        //This method shows the dialog on the screen
        //------------------------------------------------------------------------------
        public NXOpen.UIStyler.DialogResponse Show()
        {
            try
            {
                theDialog.Show();
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
            return 0;
        }

        //------------------------------------------------------------------------------
        //Method Name: Dispose
        //------------------------------------------------------------------------------
        public void Dispose()
        {
            if (theDialog != null)
            {
                theDialog.Dispose();
                theDialog = null;
            }
        }

        //------------------------------------------------------------------------------
        //---------------------Block UI Styler Callback Functions--------------------------
        //------------------------------------------------------------------------------

        //------------------------------------------------------------------------------
        //Callback Name: initialize_cb
        //------------------------------------------------------------------------------
        public void initialize_cb()
        {
            try
            {
                group0 = (NXOpen.BlockStyler.Group)theDialog.TopBlock.FindBlock("group0");
                enum0 = (NXOpen.BlockStyler.Enumeration)theDialog.TopBlock.FindBlock("enum0");
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
        }

        //------------------------------------------------------------------------------
        //Callback Name: dialogShown_cb
        //This callback is executed just before the dialog launch. Thus any value set 
        //here will take precedence and dialog will be launched showing that value. 
        //------------------------------------------------------------------------------
        public void dialogShown_cb()
        {
            try
            {
                //---- Enter your callback code here -----
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
        }

        //------------------------------------------------------------------------------
        //Callback Name: apply_cb
        //------------------------------------------------------------------------------
        public int apply_cb()
        {
            int errorCode = 0;
            try
            {
                //---- Enter your callback code here -----
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                errorCode = 1;
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
            return errorCode;
        }

        //------------------------------------------------------------------------------
        //Callback Name: update_cb
        //------------------------------------------------------------------------------
        public int update_cb(NXOpen.BlockStyler.UIBlock block)
        {
            try
            {
                if (block == enum0)
                {
                    //---------Enter your code here-----------
                }
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
            return 0;
        }

        //------------------------------------------------------------------------------
        //Callback Name: ok_cb
        //------------------------------------------------------------------------------
        public int ok_cb()
        {
            int errorCode = 0;
            try
            {
                errorCode = apply_cb();
                //---- Enter your callback code here -----
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                errorCode = 1;
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
            return errorCode;
        }

        //------------------------------------------------------------------------------
        //Function Name: GetBlockProperties
        //Returns the propertylist of the specified BlockID
        //------------------------------------------------------------------------------
        public PropertyList GetBlockProperties(string blockID)
        {
            PropertyList plist = null;
            try
            {
                plist = theDialog.GetBlockProperties(blockID);
            }
            catch (Exception ex)
            {
                //---- Enter your exception handling code here -----
                theUI.NXMessageBox.Show("Block Styler", NXMessageBox.DialogType.Error, ex.ToString());
            }
            return plist;
        }
    }
}
