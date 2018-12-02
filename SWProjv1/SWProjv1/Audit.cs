using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWProjv1
{
    class Audit
    {
        public String name { get; set; }
        public String message { get; set; }
        public static Audit selectedAudit { get; set; }
        public ListBoxItem listboxitem { get; set; }
        public Grid grid { get; set; }
        public Audit(String name, String message)
        {
            this.name = name;
            this.message = message;
            grid = new Grid();
        }
        private void Item_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            setGrid();
            selectedAudit = this;
        }

        public void setListBoxItem()
        {
            listboxitem = new ListBoxItem();
            listboxitem.Content = name;
            listboxitem.PreviewMouseDown += Item_PreviewMouseDown;
        }
        void setGrid()
        {
            grid.Children.Clear();

            TextBlock tb = new TextBlock();
            tb.Text = name + "\n\n" + message;
            grid.Children.Add(tb);
        }
    }
}
