using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUWindowsFormFramework
{
    public class WindowsFormsUtility
    {
        public static void SetListBinding(ComboBox drpdwn, DataTable sourcedt, DataTable targetdt, string tablename)
        {
            drpdwn.DataSource = sourcedt;
            drpdwn.ValueMember = tablename + "Id";
            drpdwn.DisplayMember = drpdwn.Name.Substring(6);
            drpdwn.DataBindings.Add("SelectedValue", targetdt, drpdwn.ValueMember, false, DataSourceUpdateMode.OnPropertyChanged);
            Debug.Print(drpdwn.DisplayMember);

        }
        public static void SetControlBinding(Control ctrl, DataTable dt)
        { 
            string propertyname = "";
            string controlname = ctrl.Name.ToLower();
            string controltype = controlname.Substring(0, 3);
            string columnname = controlname.Substring(3);
            switch (controltype)
            {
                case "txt":
                case "lbl":
                    propertyname = "Text";
                    break;
                case "dtp":
                    propertyname = "Value";
                    break;
            }
            if (propertyname != "" && columnname != "")
            {
                ctrl.DataBindings.Add(propertyname, dt, columnname, true, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public static void FormatGridForSearchResults(DataGridView grid)
        {
            grid.AllowDrop = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
