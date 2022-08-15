using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using NUnit.Framework;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModellerCSharp.Utilities;
using Utilities;

namespace TestModellerCSharp.Pages
{
    public class DesktopActions : BasePage
    {
        protected Window currentWindow { get; set; }

        public DesktopActions(FlaUIApplication app) : base(app)
        {
            this.app = app;
        }

        /**
         * Launches an application.
         * @name Open Application
         * @param appName Relative or absolute path to executable to launch
         */
        public void OpenApplication(String appName)
        {
            app.app = Application.LaunchStoreApp(appName);

            UseMainWindow();

            passStepWithScreenshot("Opening application " + appName);
        }

        /**
         * Use main window
         * @name Use Main Window
         */
        public void UseMainWindow()
        {
            currentWindow = app.app.GetMainWindow(new UIA3Automation());

            System.Threading.Thread.Sleep(2000);
        }

        /**
         * Inputs value to a textbox module.
         * @name Enter Text
         * @param objectName Object identifier
         * @param text Value to set to textbox
         */
        public void EnterText(String objectName, String text)
        {
            var textBox = getElementForObject(objectName).AsTextBox();
            textBox.Text = text;

            passStepWithScreenshot("Enter text '" + text + "' with automatation ID " + objectName);
        }

        public void AssertLabelText(String objectName, String text)
        {
            var resultLabel = getElementForObject(objectName).AsLabel();

            Assert.True(resultLabel.Text.Contains(text));
        }

        /**
         * Closes the attached application.
         * @name Close Application
         */
        public void CloseApplication()
        {
            app.app.Close(true);
        }

        /**
         * Click to element.
         * @name Click
         */
        public void Click(String objectName)
        {
            var button1 = getElementForObject(objectName);
            button1.Click();

            passStepWithScreenshot( "Click button by automatation ID " + objectName);
        }

        /**
         * Right click to element.
         * @name Right Click
         */
        public void RightClick(String objectName)
        {
            var button1 = getElementForObject(objectName);
            button1.RightClick();

            passStepWithScreenshot("Right click button by automatation ID " + objectName);
        }

        /**
         * Double click to element.
         * @name Double Click
         */
        public void DoubleClick(String objectName)
        {
            var button1 = getElementForObject(objectName);
            button1.DoubleClick();

            passStepWithScreenshot("Double click button by automatation ID " + objectName);
        }


        /**
         * Selects item from combobox with given index number. Combobox will be automatic collapsed after selection is done.
         * @name Select Combobox Item By Index
         */
        public void SelectComboBoxByIndex(String objectName, int index)
        {
            var comboBox = getElementForObject(objectName).AsComboBox();
            comboBox.Select(index).Click();

            passStepWithScreenshot("Select Combobox with index " + index + " and automatation ID " + objectName);
        }

        /**
         * Selects item from listbox with given index number
         * @name Select Listbox Item By Index
         */
        public void SelectListBoxByIndex(String objectName, int index)
        {
            var comboBox = getElementForObject(objectName).AsListBox();
            comboBox.Select(index).Click();

            passStepWithScreenshot("Select list box with index " + index + " and automatation ID " + objectName);
        }

        /**
         * Select given radiobutton by xpath.
         * @name Select Radiobutton
         */
        public void SelectRadioButton(String objectName)
        {
            var comboBox = getElementForObject(objectName).AsRadioButton();
            comboBox.Click();

            passStepWithScreenshot("Select RadioButton with automatation ID " + objectName);
        }

        // Close Window
        public void CloseWindow()
        {
            currentWindow.Close();
        }


        /**
         * Collapse every collapsable tree items of the given tree.
         * @name Collapse All Treeitems
         */
        public void CollapseAllTreeitems(String objectName)
        {
            var tree = getElementForObject(objectName).AsTree();

            foreach (TreeItem treeItem in tree.Items)
                treeItem.Collapse();

            passStepWithScreenshot("Collapse all tree items");
        }

        /**
         * Collapse combobox.
         * @name Collapse Combobox
         */
        public void CollapseCombobox(String objectName)
        {
            var elem = getElementForObject(objectName).AsComboBox();

            elem.Collapse();

            passStepWithScreenshot("Collapse combobox");
        }

        /**
         * Checks if Combobox contains an item
         * @name Combobox Should Contain
         */
        public void ComboboxShouldContain(String objectName, String itemName)
        {
            var elem = getElementForObject(objectName).AsComboBox();

            foreach(ComboBoxItem comboItem in elem.Items)
            {
                if (comboItem.Text.Equals(itemName))
                {
                    passStep("Combox box contains item with text '" + itemName + "'");

                    return;
                }
            }

            failStep("Combox box does not contain item with text '" + itemName + "'");

        }

        /**
         * Clicks and hold the item with start_identifier and drops it at item with end_identifier.
         * @name Drag And Drop
         */
        public void DragAndDrop(String fromObject, String endObject)
        {

            var sourceCoordinates = new System.Drawing.Point(getElementForObject(fromObject).Properties.ClickablePoint.Value.X, getElementForObject(fromObject).Properties.ClickablePoint.Value.Y);
            var targetCoordinates = new System.Drawing.Point(getElementForObject(endObject).Properties.ClickablePoint.Value.X, getElementForObject(endObject).Properties.ClickablePoint.Value.Y);

            Mouse.DragVertically(sourceCoordinates, targetCoordinates.Y - sourceCoordinates.Y, MouseButton.Left);
        }

        /**
         * Checks if element is visible. If element is visible True will be returned otherwise False.
         * @name Element Should Be Visible
         */
        public void ElementShouldBeVisible(String objectName)
        {
            var elem = getElementForObject(objectName);

            if (elem.IsOffscreen)
            {
                failStep("Element is off screen");
            }
            else
            {
                passStepWithScreenshot("Element is on the screen");
            }
        }

        /**
         * Checks if element exists. If element exists True will be returned otherwise False.
         * @name Element Should Exist
         */
        public void ElementShouldExist(String objectName)
        {
            var elem = getElementForObject(objectName, false);

            if (elem == null)
            {
                failStep("Element does not exist");
            } else
            {
                passStepWithScreenshot("Element exists");
            }
        }

        /**
         * Checks if element is visible.
         * @name Element Should Not Be Visible
         */
        public void ElementShouldNotBeVisible(String objectName)
        {
            var elem = getElementForObject(objectName);

            if (elem.IsOffscreen)
            {
                passStepWithScreenshot("Element is off the screen");
            }
            else
            {
                failStep("Element is on screen");
            }
        }

        /**
         * Checks if element exists. If element exists False will be returned otherwise True. 
         * @name Element Should Not Exist
         */
        public void ElementShouldNotExist(String objectName)
        {
            var elem = getElementForObject(objectName, false);

            if (elem == null)
            {
                passStepWithScreenshot("Element does not exist");
            }
            else
            {
                failStep("Element exists");
            }
        }

        /**
         * Expands every expandable Tree Items items of the given tree.
         * @name Expand All Treeitems
         */
        public void ExpandAllTreeitems(String objectName)
        {
            var tree = getElementForObject(objectName).AsTree();

            foreach (TreeItem treeItem in tree.Items)
                treeItem.Expand();

            passStepWithScreenshot("Expand all tree items");
        }

        /**
         * Expand combobox.
         * @name Expand Combobox
         */
        public void ExpandCombobox(String objectName)
        {
            var elem = getElementForObject(objectName).AsComboBox();

            elem.Expand();

            passStepWithScreenshot("Expand combobox");
        }

        /**
         * Expands item from tree by hybrid pointers, series of indexes and names.
         * @name Expand Treeitem
         */
        public void ExpandTreeitem(String objectName)
        {
            var elem = getElementForObject(objectName).AsTreeItem();

            elem.Expand();

            passStepWithScreenshot("Expand tree item");
        }

        /**
         * Try to focus element.
         * @name Focus
         */
        public void Focus(String objectName)
        {
            var elem = getElementForObject(objectName);

            elem.Focus();

            passStepWithScreenshot("Focused on item");
        }

        /**
         * Return actual checked state from checkbox.
         * @name Get Checkbox State
         */
        public Boolean GetCheckboxState(String objectName)
        {
            var elem = getElementForObject(objectName).AsCheckBox();

            return elem.IsChecked.Value;
        }

        /**
         * Return actual count of items in combobox.
         * @name Get Combobox Items Count
         */
        public int GetComboboxItemsCount(String objectName)
        {
            var elem = getElementForObject(objectName).AsComboBox();

            return elem.Items.Count();
        }

        /**
         * Return count of rows from data grid.
         * @name Get Grid Rows Count
         */
        public int GetGridRowsCount(String objectName)
        {
            var elem = getElementForObject(objectName).AsDataGridView();

            return elem.Rows.Count();
        }

        /**
         * Return count of rows in listbox.
         * @name Get Listbox Items Count
         */
        public int GetListboxItemsCount(String objectName)
        {
            var elem = getElementForObject(objectName).AsListBox();

            return elem.Items.Count();
        }

        /**
         * Return name value from element.
         * @name Get Name From Element
         */
        public String GetNameFromElement(String objectName)
        {
            var elem = getElementForObject(objectName);

            return elem.Name;
        }

        /**
         * Return actual state from radiobutton.
         * @name Get Radiobutton State
         */
        public Boolean GetRadiobuttonState(String objectName)
        {
            var elem = getElementForObject(objectName).AsRadioButton();

            return elem.IsChecked;
        }

        /**
         * Return count of items in the first level of the tree.
         * @name Get Root Treeitems Count
         */
        public int GetRootTreeitemsCount(String objectName)
        {
            var elem = getElementForObject(objectName).AsTree();

            return elem.Items.Count();
        }


        /**
         * Return text from textbox element.
         * @name Get Text From Textbox
         */
        public String GetTextFromTextbox(String objectName)
        {
            var elem = getElementForObject(objectName).AsTextBox();

            return elem.Text;
        }

        /**
         * Verifies if element is enabled (true) or not (false).
         * @name Verify Element Enabled
         */
        public void IsElementEnabled(String objectName)
        {
            var elem = getElementForObject(objectName);

            if (elem.IsEnabled)
            {
                failStep("Element is enabled");
            }
            else
            {
                passStepWithScreenshot("Element is disabled");
            }
        }


        /**
         * Checks if the selected listbox items are same with the given ones.
         * @name Listbox Selection Should Be
         */
        public void ListboxSelectionShouldBe(String objectName, String name)
        {
            var elem = getElementForObject(objectName).AsListBox();

            var selectedItem = elem.SelectedItem;

            if (selectedItem != null && selectedItem.Name == name) {
                passStepWithScreenshot("Listbox item '" + name + "' is selected");

                return;
            }

            failStep("Listbox item '" + name + "' is not selected");
        }

        /**
         * Checks if listbox contains the given item.
         * @name Listbox Should Contain
         */
        public void ListboxShouldContain(String objectName, String name)
        {
            var elem = getElementForObject(objectName).AsListBox();

            foreach(ListBoxItem item in elem.Items)
            {
                if (item.Name == name)
                {
                    passStep("Listbox contains item '" + name + "'");
                    
                    return;
                }
            }

            failStep("Listbox does not contain item '" + name + "'");
        }

        /**
         * Move mouse cursor to given position.
         * @name Move To Position
         */
        public void MoveTo(int xPos, int yPos)
        {
            Mouse.MoveTo(xPos, yPos);
        }

        /**
         * Move mouse cursor to given element.
         * @name Move To Element
         */
        public void MoveToElement(String objectName)
        {
            var elem = getElementForObject(objectName);

            Mouse.MoveTo(elem.Properties.ClickablePoint.Value.X, elem.Properties.ClickablePoint.Value.Y);
        }

        /**
         * Verifies if element name contains to name.
         * @name Name Contains Text
         */
        public void NameContainsText(String objectName, String text)
        {
            var elem = getElementForObject(objectName);

            if (elem.Name.Contains(text))
            {
                passStepWithScreenshot("Object contains name '" + text + "'");
            } else
            {
                failStep("Object does not contain name '" + text + "'");
            }
        }

        /**
         * Verifies if name from element is equal.
         * @name Name Should Be
         */
        public void NameShouldBe(String objectName, String name)
        {
            var elem = getElementForObject(objectName);

            if (elem.Name.Equals(name))
            {
                passStepWithScreenshot("Name of object is equal to '" + name + "'");
            }
            else
            {
                failStep("Name of object is not equal to '" + name + "'");
            }

        }

        /**
         * Selects item from listbox by name.
         * @name Select Listbox Item By Name
         */
        public void SelectListboxItemByName(String objectName, String name)
        {
            var elem = getElementForObject(objectName).AsListBox();

            ListBoxItem selectedItem = null;
            foreach (ListBoxItem item in elem.Items)
            {
                if (item.Name.Equals(name))
                {
                    selectedItem = item;

                    return;
                }

            }

            selectedItem.Select();

            if (selectedItem == null)
            {
                failStep("List box does not contain an item with the name '" + name + "'");

                return;
            }

            passStepWithScreenshot("List box with name '" + name + "' is selected");
        }

        /**
         * @name Select Tab Item By Name
         */
        public void SelectTabItemByName(String objectName, String name)
        {
            var elem = getElementForObject(objectName).AsTab();

            TabItem selectedTab = null;
            foreach(TabItem item in elem.TabItems)
            {
                if (item.Name.Equals(name))
                {
                    selectedTab = item;

                    return;
                }

            }

            selectedTab.Select();

            if (selectedTab == null)
            {
                failStep("Tab does not contain an item with the name '" + name + "'");

                return;
            }

            passStepWithScreenshot("Tab with name '" + name + "' is selected");
        }

        /**
         * 
         * @name Select Treeitem
         */
        public void SelectTreeitem(String objectName)
        {
            var elem = getElementForObject(objectName).AsTreeItem();

            elem.Select();

            passStepWithScreenshot("Tree item is selected");
        }

        /**
         * Set checkbox state to True or False
         * @name Set Checkbox State
         */
        public void SetCheckboxState(String objectName, Boolean state)
        {
            var elem = getElementForObject(objectName).AsCheckBox();

            elem.IsChecked = state;
        }

        /**
         * Waits until element is responsive or timeout was reached.
         * @name Wait Until Element Is Responsive
         */
        public void WaitUntilElementIsResponsive(String objectName)
        {
            Wait.UntilResponsive(getElementForObject(objectName));
        }

        private AutomationElement getElementForObject(String objectId, Boolean failIfNotFound = true)
        {
            PropertyCondition cond = buildObjectLocator(objectId);

            return currentWindow.FindFirstDescendant(cond);
        }

        private PropertyCondition buildObjectLocator(String objectId)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            return cf.ByAutomationId(objectId);
        }
    }
}
